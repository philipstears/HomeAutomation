Imports System.Data.SqlClient

Public Structure DeviceDetail
    Public Location As String
    Public Relay As Integer
    Public DeviceID As Integer
    Public ControlLocation As Boolean
End Structure

Public Class Devices

    Private mConnectionString As String
    Private mTemperatureTableName As String
    Private mDeviceTableName As String

    Private mDeviceLatest As New Dictionary(Of Integer, DateTime)
    Private mDeviceList As New Dictionary(Of Integer, DeviceDetail)

    Public Sub New(connectionString As String, temperatureTableName As String, deviceTableName As String)

        ' we are going to connect to the database, we need some connection stuff
        mConnectionString = connectionString
        mDeviceTableName = deviceTableName
        mTemperatureTableName = temperatureTableName

        ' initialise device data from database (Device ID, Relay, Location Name and control device status - used to set the temp of locations whode device cannot be read)
        GetDevices()

        ' get latest temp readings from database for each device (This is used so that we don't ask the device for time/temp data we already have.
        InitialiseLatest()

    End Sub

    Public ReadOnly Property DeviceLatest As Dictionary(Of Integer, DateTime)
        Get
            Return mDeviceLatest
        End Get
    End Property

    Public ReadOnly Property DeviceListing As Dictionary(Of Integer, DeviceDetail)
        Get
            Return mDeviceList
        End Get
    End Property

    Private Sub GetDevices()

        ' Get each device row from the database.
        Using connection = New SqlConnection(mConnectionString)
            connection.Open()
            Using command = connection.CreateCommand()
                command.CommandText = "SELECT Relay, DeviceID, Location, ControlLocation from " & mDeviceTableName

                Using reader = command.ExecuteReader()
                    While reader.Read()

                        Dim deviceDetail As New DeviceDetail

                        deviceDetail.Relay = reader.GetInt32(0)
                        deviceDetail.DeviceID = reader.GetInt32(1)
                        deviceDetail.Location = reader.GetString(2)

                        If reader.GetInt32(3) = 0 Then
                            deviceDetail.ControlLocation = False
                        Else
                            deviceDetail.ControlLocation = True
                        End If

                        ' mdevice list is going to get passed arround a lot, shouldn't change though so no need to re-get
                        mDeviceList.Add(deviceDetail.DeviceID, deviceDetail)

                    End While
                End Using
            End Using
        End Using
    End Sub

    Private Sub InitialiseLatest()

        Dim initialDate As DateTime = DateTime.UtcNow - New TimeSpan(1, 0, 0, 0)

        ' Get the temp of the max (latest) entry in the database for each device
        Using connection = New SqlConnection(mConnectionString)
            connection.Open()

            For Each currentdevice In mDeviceList

                Using command = connection.CreateCommand()
                    command.CommandText = "SELECT MAX(LogDateTimeUtc) from " & mTemperatureTableName & " WHERE DeviceID = " & currentdevice.Key

                    Using reader = command.ExecuteReader()
                        While reader.Read()

                            If Not IsDBNull(reader(0)) Then
                                mDeviceLatest(currentdevice.Key) = reader.GetDateTime(0)
                            End If

                        End While
                    End Using
                End Using

            Next currentdevice

        End Using

        ' we may not have had a record (New device or database table flush) so set a value for all thoughs that don't have one
        For Each listedDevice In mDeviceList

            If Not mDeviceLatest.ContainsKey(listedDevice.Key) Then

                mDeviceLatest(listedDevice.Key) = initialDate
            End If
        Next

        ' lets see
        For Each devicelisting As KeyValuePair(Of Integer, DateTime) In mDeviceLatest

            Debug.Print("Device " & devicelisting.Key & " : Date " & devicelisting.Value.ToString)
        Next

    End Sub
End Class

