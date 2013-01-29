Imports RadiatorController

''' <summary>
''' Provides a fake implementation of a temperature sensor.
''' </summary>
''' <remarks></remarks>
Public Class FakeSensor
    Implements ITemperatureSensor

    Private mReading As Double

    Public Sub New()
    End Sub

    Public Sub SetReading(ByVal newReading As Double)
        mReading = newReading
    End Sub

    Public ReadOnly Property Reading As Double Implements ITemperatureSensor.Reading
        Get
            Return mReading
        End Get
    End Property
End Class