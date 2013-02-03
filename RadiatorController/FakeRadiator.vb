Imports RadiatorController

''' <summary>
''' Provides a fake implementation of a radiator.
''' </summary>
''' <remarks></remarks>
Public Class FakeRadiator
    Implements IRadiator

    Public Event IsOnChanged(sender As Object, e As EventArgs) Implements IRadiator.IsOnChanged

    Private mIsOn As Boolean

    Public Sub EnsureOff() Implements IRadiator.EnsureOff
        mIsOn = False
        RaiseIsOnChanged(EventArgs.Empty)
    End Sub

    Public Sub EnsureOn() Implements IRadiator.EnsureOn
        mIsOn = True
        RaiseIsOnChanged(EventArgs.Empty)
    End Sub

    Public ReadOnly Property IsOn As Boolean Implements IRadiator.IsOn
        Get
            Return mIsOn
        End Get
    End Property

    Protected Overridable Sub RaiseIsOnChanged(ByVal e As EventArgs)
        RaiseEvent IsOnChanged(Me, e)
    End Sub
End Class
