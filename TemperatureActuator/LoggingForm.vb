Imports TemperatureDataCore

Public Class LoggingForm
    Private mLocations As New Dictionary(Of Integer, ListViewItem)()
    Private mDevices As Devices
    Private mSettingsReader As SenseAndReact
    Private mAggregator As TemperatureAggregater

    Private Sub LoggingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LoadSettings()
        For Each device In mDevices.DeviceListing.Values
            Dim lvi = New ListViewItem(New String() {
                device.Location,
                device.DeviceID.ToString(),
                device.Relay.ToString(),
                "Awaiting Reading",
                "Updating",
                "Awaiting Reading"
            })

            If Not device.ControlLocation Then
                lvi.ForeColor = Color.DarkGray
            End If

            StatusList.Items.Add(lvi)
            mLocations(device.DeviceID) = lvi
        Next
    End Sub

    Private Sub UpdateActualReadings()
        For Each reading In mAggregator.GetDeviceTemperatures().Values
            Dim lvi As ListViewItem = Nothing

            If Not mLocations.TryGetValue(reading.DeviceId, lvi) Then
                Continue For
            End If

            lvi.SubItems(3).Text = DegToString(reading.Temperature)
        Next
    End Sub

    Private Sub UpdateDesiredReadings()
        For Each reading In mSettingsReader.GetDeviceExpectedTemperatures()
            Dim lvi As ListViewItem = Nothing

            If Not mLocations.TryGetValue(reading.Key, lvi) Then
                Continue For
            End If

            lvi.SubItems(4).Text = DegToString(reading.Value)
        Next
    End Sub

    Private Function DegToString(ByVal value As Double) As String
        Return value.ToString("#,##.00'°C'")
    End Function
End Class