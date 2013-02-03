Imports RelayController

Public Class RelayControllerForm
    Dim mRelayBoard As DenkoviRelayBoard = DenkoviRelayBoard.Open(5)

    Private Sub MainForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'mRelayBoard.SetRelays(RelayOption.Relay4 Or RelayOption.Relay5 Or RelayOption.Relay6, RelayStatus.Off)

        'Dim radiatorManager As New DenkoviRadiatorManager(mRelayBoard)

        'Dim radiator0 = radiatorManager.GetRadiator(RelayOption.Relay0)
        'Dim radiator1 = radiatorManager.GetRadiator(RelayOption.Relay1)
        'Dim radiator2 = radiatorManager.GetRadiator(RelayOption.Relay2)
        'Dim radiator3 = radiatorManager.GetRadiator(RelayOption.Relay3)
        'Dim radiator4 = radiatorManager.GetRadiator(RelayOption.Relay4)
        'Dim radiator5 = radiatorManager.GetRadiator(RelayOption.Relay5)
        'Dim radiator6 = radiatorManager.GetRadiator(RelayOption.Relay6)

        'radiator0.EnsureOn()
        'radiator1.EnsureOn()
        'radiator2.EnsureOn()
        'radiator3.EnsureOn()

        'radiator4.EnsureOn()
        'radiator5.EnsureOn()
        'radiator6.EnsureOn()
    End Sub

    Private Sub FirstOn_Click(sender As System.Object, e As System.EventArgs) Handles FirstOn.Click
        mRelayBoard.SetRelays(RelayOption.Relay0, RelayStatus.On)
    End Sub

    Private Sub FirstOff_Click(sender As System.Object, e As System.EventArgs) Handles FirstOff.Click
        mRelayBoard.SetRelays(RelayOption.Relay0, RelayStatus.Off)
    End Sub

    Private Sub SecondOn_Click(sender As System.Object, e As System.EventArgs) Handles SecondOn.Click
        mRelayBoard.SetRelays(RelayOption.Relay1, RelayStatus.On)
    End Sub

    Private Sub SecondOff_Click(sender As System.Object, e As System.EventArgs) Handles SecondOff.Click
        mRelayBoard.SetRelays(RelayOption.Relay1, RelayStatus.Off)
    End Sub

    Private Sub AllOn_Click(sender As System.Object, e As System.EventArgs) Handles AllOn.Click
        mRelayBoard.SetRelays(RelayOption.All, RelayStatus.On)
    End Sub

    Private Sub AllOff_Click(sender As System.Object, e As System.EventArgs) Handles AllOff.Click
        mRelayBoard.SetRelays(RelayOption.All, RelayStatus.Off)
    End Sub

    Private Sub FirstAndSecondOn_Click(sender As System.Object, e As System.EventArgs) Handles FirstAndSecondOn.Click
        mRelayBoard.SetRelays(RelayOption.Relay0 Or RelayOption.Relay1, RelayStatus.On)
    End Sub

    Private Sub FirstAndSecondOff_Click(sender As System.Object, e As System.EventArgs) Handles FirstAndSecondOff.Click
        mRelayBoard.SetRelays(RelayOption.Relay0 Or RelayOption.Relay1, RelayStatus.Off)
    End Sub

    Private Sub ReadStatus_Click(sender As System.Object, e As System.EventArgs) Handles ReadStatus.Click
        MessageBox.Show(mRelayBoard.GetStatus().ToString())
    End Sub
End Class
