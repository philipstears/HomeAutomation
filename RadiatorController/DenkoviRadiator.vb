Imports RelayController
Imports RelayController.Support

<DebuggerDisplay("{mRelayId,nq} - On = {mIsOn,nq}")>
Public Class DenkoviRadiator
    Implements IRadiator

    Public Event IsOnChanged(sender As Object, e As EventArgs) Implements IRadiator.IsOnChanged

    Private mManager As DenkoviRadiatorManager
    Private mRelayId As RelayOption
    Private mIsOn As Boolean

    Friend Sub New(ByVal manager As DenkoviRadiatorManager, ByVal relayId As RelayOption, ByVal isOn As Boolean)
        mManager = manager
        mRelayId = relayId
        mIsOn = isOn
    End Sub

    ReadOnly Property RelayId As RelayOption
        Get
            Return mRelayId
        End Get
    End Property

    ReadOnly Property IsOn As Boolean Implements IRadiator.IsOn
        Get
            Return mIsOn
        End Get
    End Property

    Public Sub EnsureOn() Implements IRadiator.EnsureOn
        mManager.EnsureOn(Me)
    End Sub

    Public Sub EnsureOff() Implements IRadiator.EnsureOff
        mManager.EnsureOff(Me)
    End Sub

    Friend Sub UpdateStatus(ByVal isOn As Boolean)
        If isOn = mIsOn Then
            Return
        End If

        mIsOn = isOn
        RaiseEvent IsOnChanged(Me, EventArgs.Empty)
    End Sub
End Class
