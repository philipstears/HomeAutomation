Imports RelayController
Imports RelayController.Support

Public Class DenkoviRadiatorManager
    Private mBoard As DenkoviRelayBoard
    Private mLastStatus As RelayOption
    Private mThrottle As New Throttle(TimeSpan.FromSeconds(2))

    Public Sub New(ByVal board As DenkoviRelayBoard)
        mBoard = board
        UpdateBoardStatus()
    End Sub

    Public Function GetRadiator(ByVal relay As RelayOption) As DenkoviRadiator
        Return New DenkoviRadiator(Me, relay, mLastStatus.HasFlag(relay))
    End Function

    Friend Sub EnsureOn(radiator As DenkoviRadiator)
        EnsureStatus(radiator, RelayStatus.On)
    End Sub

    Friend Sub EnsureOff(radiator As DenkoviRadiator)
        EnsureStatus(radiator, RelayStatus.Off)
    End Sub

    Private Sub EnsureStatus(radiator As DenkoviRadiator, ByVal status As RelayStatus)
        UpdateBoardStatus()

        ' See if the board is already in the target status
        Dim isOn = mLastStatus.HasFlag(radiator.RelayId)
        Dim shouldBeOn = If(status = RelayStatus.On, True, False)

        If isOn = shouldBeOn Then
            Return
        End If

        ' Update the board status
        mThrottle.WaitUntilReady()
        mBoard.SetRelays(radiator.RelayId, status)
        mLastStatus = mBoard.GetStatus()

        ' Make sure the status was properly applied
        isOn = mLastStatus.HasFlag(radiator.RelayId)

        If Not isOn = shouldBeOn Then
            OnEnsureStatusFailed(radiator, status)
        End If
    End Sub

    Private Sub OnEnsureStatusFailed(ByVal radiator As DenkoviRadiator, ByVal status As RelayStatus)
        ' TODO: Log? Report? Try again?
    End Sub

    Private Sub UpdateBoardStatus()
        mLastStatus = mBoard.GetStatus()
    End Sub
End Class
