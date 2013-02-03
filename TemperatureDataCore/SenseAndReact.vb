Imports System.Data.SqlClient
Imports RadiatorController

Public Class SenseAndReact

    Private mConnectionString As String
    Private mTemperatureTableName As String
    Private mDeviceTableName As String

    Private mDeviceList As New Dictionary(Of Integer, DeviceDetail)


    Public Sub New(connectionString As String, temperatureTableName As String, deviceTableName As String, devices As Devices)

        mConnectionString = connectionString
        mDeviceTableName = deviceTableName
        mTemperatureTableName = temperatureTableName

        mDeviceList = devices.DeviceListing

    End Sub

    Public Function GetDeviceExpectedTemperatures() As Dictionary(Of Integer, Double)
        Return GetDeviceExpectedTemperatures(DateTime.UtcNow)
    End Function

    Public Function GetDeviceExpectedTemperatures(ByVal forWhen As DateTime) As Dictionary(Of Integer, Double)
        Dim dayName As String = DateTime.UtcNow.DayOfWeek.ToString()
        Dim deviceTemperature As New Dictionary(Of Integer, Double)

        Using connection = New SqlConnection(mConnectionString)
            connection.Open()

            For Each device In mDeviceList

                ' Get the device entity ids from the database
                Using command = connection.CreateCommand()
                    command.CommandText = "SELECT [TimeID], [Relay], [Day], [NightStart], [MorningStart], [AfternoonStart], [EveningStart], [NightTemp], [MorningTemp], [AfternoonTemp], [EveningTemp] " &
                                            "FROM [HomeAutomationData].[dbo].[MasterTimes] WHERE [Day] = '" & dayName & "' AND Relay = " & device.Value.Relay

                    Using reader = command.ExecuteReader()
                        While reader.Read()

                            Dim settingDate1 As DateTime = DateTime.UtcNow.Date + reader.GetTimeSpan(3)
                            Dim settingtemp1 As Double = reader.GetInt32(7)
                            Dim setting1 As New TemperatureSetting(settingDate1, settingtemp1)

                            Dim settingDate2 As DateTime = DateTime.UtcNow.Date + reader.GetTimeSpan(4)
                            Dim settingtemp2 As Double = reader.GetInt32(8)
                            Dim setting2 As New TemperatureSetting(settingDate2, settingtemp2)

                            Dim settingDate3 As DateTime = DateTime.UtcNow.Date + reader.GetTimeSpan(5)
                            Dim settingtemp3 As Double = reader.GetInt32(9)
                            Dim setting3 As New TemperatureSetting(settingDate3, settingtemp3)

                            Dim settingDate4 As DateTime = DateTime.UtcNow.Date + reader.GetTimeSpan(6)
                            Dim settingtemp4 As Double = reader.GetInt32(10)
                            Dim setting4 As New TemperatureSetting(settingDate4, settingtemp4)

                            Dim tempSetting As New TemperatureSettings

                            tempSetting.AddSetting(setting1)
                            tempSetting.AddSetting(setting2)
                            tempSetting.AddSetting(setting3)
                            tempSetting.AddSetting(setting4)

                            deviceTemperature.Add(device.Key, tempSetting.GetDesiredTemperature(DateTime.UtcNow()))

                        End While
                    End Using
                End Using
            Next
        End Using

        Return deviceTemperature
    End Function

End Class
