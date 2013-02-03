Public Class TemperatureDataReceivedEventArgs
    Inherits EventArgs

    Public ReadOnly SensorId As Integer
    Public ReadOnly SensorDescription As String
    Public ReadOnly LogDateTime As DateTime
    Public ReadOnly ReceivedDateTime As DateTime
    Public ReadOnly ReadingInDegrees As Decimal

    Public Sub New(ByVal sensorId As Integer, ByVal sensorDescription As String, ByVal logDateTime As DateTime, ByVal receivedDateTime As DateTime, ByVal readingInDegrees As Decimal)
        Me.SensorId = sensorId
        Me.SensorDescription = sensorDescription
        Me.LogDateTime = logDateTime
        Me.ReceivedDateTime = receivedDateTime
        Me.ReadingInDegrees = readingInDegrees
    End Sub
End Class