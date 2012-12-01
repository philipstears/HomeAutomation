Imports RelayController

Public Class TemperatureSensor
    Implements ITemperatureSensor

    Private mReading As Double

    Public Sub New(ByVal sensorId As Integer)

    End Sub

    Public ReadOnly Property Reading As Double Implements ITemperatureSensor.Reading
        Get
            Return mReading
        End Get
    End Property
End Class