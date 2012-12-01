Imports RadiatorController

Class FakeRadiator
    Implements IRadiator

    Private mIsOn As Boolean

    Public Sub EnsureOff() Implements RadiatorController.IRadiator.EnsureOff
        mIsOn = False
    End Sub

    Public Sub EnsureOn() Implements RadiatorController.IRadiator.EnsureOn
        mIsOn = True
    End Sub

    Public ReadOnly Property IsOn As Boolean Implements RadiatorController.IRadiator.IsOn
        Get
            Return mIsOn
        End Get
    End Property
End Class
