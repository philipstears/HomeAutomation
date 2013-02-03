Imports System.Data.SqlClient

Public Class TemperatureAggregater
    Private mConnectionString As String
    Private mTemperatureTableName As String
    Private mDeviceTableName As String


    Public Sub New(connectionString As String, temperatureTableName As String, deviceTableName As String)
        mConnectionString = connectionString
        mDeviceTableName = deviceTableName
        mTemperatureTableName = temperatureTableName
    End Sub

    Public Function GetDeviceTemperatures() As Dictionary(Of Integer, DeviceAndTemperature)

        Dim currentTemperatures As New Dictionary(Of Integer, DeviceAndTemperature)
        Dim ignoreBeforeDate As DateTime = DateTime.UtcNow - New TimeSpan(0, 1, 0, 0)

        Dim deviceList As New Dictionary(Of Integer, Boolean)

        Dim controlCount As Integer = 0
        Dim controlTemperatureSum As Double = 0

        ' Get the device ids from the database
        Using connection = New SqlConnection(mConnectionString)
            connection.Open()
            Using command = connection.CreateCommand()
                command.CommandText = "SELECT DeviceID, ControlLocation from " & mDeviceTableName

                Using reader = command.ExecuteReader()
                    While reader.Read()

                        If reader.GetInt32(1) = 0 Then
                            deviceList.Add(reader.GetInt32(0), False)
                        Else
                            deviceList.Add(reader.GetInt32(0), True)
                        End If

                    End While
                End Using
            End Using

            For Each currentdevice As KeyValuePair(Of Integer, Boolean) In deviceList

                Dim tempData As New TemperatureReadings(currentdevice.Key, currentdevice.Value)

                Using command = connection.CreateCommand()

                    Dim currentTemperature As Double = 0
                    Dim readNode As Integer = 1

                    ' get the latest 10 results for this device.  Lets assume there are at least 10
                    command.CommandText = "SELECT Top 3 LogDateTimeUtc, [ProcessedReading] FROM " & mTemperatureTableName & " WHERE DeviceID = " & currentdevice.Key & " ORDER BY EntryId DESC"

                    Using reader = command.ExecuteReader()
                        While reader.Read()

                            If Not IsDBNull(reader(0)) Then

                                Dim readingTime As DateTime = reader.GetDateTime(0)

                                ' check if the reading is within our data range
                                If readingTime > ignoreBeforeDate Then

                                    ' we need to add it to the list
                                    tempData.AddData(readNode, reader.GetDecimal(1))

                                    readNode = readNode + 1

                                Else

                                    ' we have already gone before our control date, lets leave
                                    Exit While
                                End If

                            End If

                        End While
                    End Using
                End Using

                Dim deviceTemperature As Double = tempData.Temperature

                If currentdevice.Value = True And deviceTemperature > -1000 Then
                    controlCount = controlCount + 1
                    controlTemperatureSum = controlTemperatureSum + deviceTemperature
                End If

                currentTemperatures.Add(currentdevice.Key, New DeviceAndTemperature(currentdevice.Key, tempData.Temperature))

                ' based on the data we have received

            Next currentdevice

        End Using

        Dim averageControlTemperature As Double = controlTemperatureSum / controlCount

        For Each listedDevice In currentTemperatures.Values

            If listedDevice.Temperature = -1000 Then
                listedDevice.Temperature = averageControlTemperature
            End If

        Next

        Return currentTemperatures

    End Function
End Class
