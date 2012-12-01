Imports RelayController

Public Class Program
    Private mController As New RadiatorController()

    Public Sub Main()
        Dim board = DenkoviRelayBoard.Open(5)
        Dim radiatorManager = New DenkoviRadiatorManager(board)

        Dim livingRoom = mController.AddZone("Living Room", radiatorManager.GetRadiator(RelayOption.Relay0), New TemperatureSensor(KnownSensors.LivingRoom))

        Dim kitchen = mController.AddZone("Kitchen", radiatorManager.GetRadiator(RelayOption.Relay1), New TemperatureSensor(KnownSensors.Kitchen))
    End Sub
End Class
