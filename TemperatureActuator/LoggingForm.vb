Imports TemperatureDataCore

Public Class LoggingForm

    Private Sub LoggingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim devices As New Devices(My.MySettings.Default.Database, My.MySettings.Default.TemperatureTable, My.MySettings.Default.DeviceTable)
        Dim senseAndReact As New SenseAndReact(My.MySettings.Default.Database, My.MySettings.Default.TemperatureTable, My.MySettings.Default.DeviceTable, devices)
    End Sub
End Class
