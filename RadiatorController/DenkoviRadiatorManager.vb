Imports RelayController
Imports RelayController.Support

Public Class DenkoviRadiatorManager
    Implements IIndexedRadiatorManager

    Private mBoard As DenkoviRelayBoard
    Private mLastStatus As RelayOption
    Private mThrottle As New Throttle(TimeSpan.FromSeconds(2))
    Private mRadiators As New Dictionary(Of Integer, DenkoviRadiator)()

    Public Sub New(ByVal board As DenkoviRelayBoard)
        mBoard = board
        UpdateBoardStatus()
    End Sub

    Public Function GetRadiator(index As Integer) As IRadiator Implements IIndexedRadiatorManager.GetRadiator
        Return GetRadiatorCore(RelayOptionHelper.FromIndex(index), index)
    End Function

    Public Function GetRadiator(ByVal relay As RelayOption) As DenkoviRadiator
        Return GetRadiatorCore(relay, RelayOptionHelper.ToIndex(relay))
    End Function

    Private Function GetRadiatorCore(ByVal relay As RelayOption, ByVal index As Integer) As DenkoviRadiator
        Dim radiator As DenkoviRadiator = Nothing

        If Not mRadiators.TryGetValue(index, radiator) Then
            radiator = New DenkoviRadiator(Me, relay, mLastStatus.HasFlag(relay))
            mRadiators.Add(index, radiator)
        End If

        Return radiator
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

        For Each radiator In mRadiators.Values
            Dim isOn = mLastStatus.HasFlag(radiator.RelayId)
            radiator.UpdateStatus(isOn)
        Next
    End Sub
End Class
