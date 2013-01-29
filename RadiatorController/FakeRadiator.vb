Imports RadiatorController

''' <summary>
''' Provides a fake implementation of a radiator.
''' </summary>
''' <remarks></remarks>
Public Class FakeRadiator
    Implements IRadiator

    Private mIsOn As Boolean

    Public Sub EnsureOff() Implements IRadiator.EnsureOff
        mIsOn = False
    End Sub

    Public Sub EnsureOn() Implements IRadiator.EnsureOn
        mIsOn = True
    End Sub

    Public ReadOnly Property IsOn As Boolean Implements IRadiator.IsOn
        Get
            Return mIsOn
        End Get
    End Property
End Class
