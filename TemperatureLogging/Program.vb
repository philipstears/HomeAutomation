Imports TemperatureDataCore

Public Class Program
    Public Shared Sub Main()
        Dim connectionString = My.Settings.Database
        Dim temperatureTableName = My.Settings.TemperatureTable
        Dim deviceTableName = My.Settings.DeviceTable
        Dim masterTimesTableName = My.Settings.MasterTimesTable

        Dim devices As New Devices(connectionString, temperatureTableName, deviceTableName)

        Dim requiredTemperatures As New SenseAndReact(connectionString, temperatureTableName, deviceTableName, devices)

        Dim reader = New TemperatureReader(devices)
        Dim logger = New Logger(connectionString, temperatureTableName, reader)

        Application.Run(New MainForm(connectionString, temperatureTableName, deviceTableName, devices, requiredTemperatures))
    End Sub
End Class
