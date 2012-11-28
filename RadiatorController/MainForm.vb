Public Class MainForm
    Dim controller As RelayController = RelayController.Open(5)

    Private Sub FirstOn_Click(sender As System.Object, e As System.EventArgs) Handles FirstOn.Click
        controller.SetRelays(RelayOption.Relay0, RelayStatus.On)
    End Sub

    Private Sub FirstOff_Click(sender As System.Object, e As System.EventArgs) Handles FirstOff.Click
        controller.SetRelays(RelayOption.Relay0, RelayStatus.Off)
    End Sub

    Private Sub SecondOn_Click(sender As System.Object, e As System.EventArgs) Handles SecondOn.Click
        controller.SetRelays(RelayOption.Relay1, RelayStatus.On)
    End Sub

    Private Sub SecondOff_Click(sender As System.Object, e As System.EventArgs) Handles SecondOff.Click
        controller.SetRelays(RelayOption.Relay1, RelayStatus.Off)
    End Sub

    Private Sub AllOn_Click(sender As System.Object, e As System.EventArgs) Handles AllOn.Click
        controller.SetRelays(RelayOption.All, RelayStatus.On)
    End Sub

    Private Sub AllOff_Click(sender As System.Object, e As System.EventArgs) Handles AllOff.Click
        controller.SetRelays(RelayOption.All, RelayStatus.Off)
    End Sub
End Class
