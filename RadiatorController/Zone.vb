Imports RelayController

Public Class Zone
    Private mName As String
    Private mRadiator As IRadiator
    Private mSensor As ITemperatureSensor
    Private mTimes As New TemperatureSettings()

    Sub New(name As String, radiator As IRadiator, sensor As ITemperatureSensor)
        mName = name
        mRadiator = radiator
        mSensor = sensor
    End Sub

    Public Sub EvaluateTimeAndTemperature(ByVal currentTime As DateTime)
        Dim desiredTemperature = mTimes.GetDesiredTemperature(currentTime)

        If desiredTemperature = 0 Then
            mRadiator.EnsureOff()
            Return
        End If

        If ShouldRadiatorBeOn(mRadiator.IsOn, desiredTemperature, mSensor.Reading) Then
            mRadiator.EnsureOn()
        Else
            mRadiator.EnsureOff()
        End If
    End Sub

    Private Function ShouldRadiatorBeOn(ByVal currentlyOn As Boolean, ByVal desiredTemperature As Integer, ByVal currentTemperature As Integer) As Boolean
        If currentlyOn Then

            Dim switchOffTemperature = desiredTemperature + 1

            If currentTemperature >= switchOffTemperature Then
                Return False
            Else
                Return True
            End If

        Else

            Dim switchOnTemperature = desiredTemperature

            If currentTemperature <= switchOnTemperature Then
                Return True
            Else
                Return False
            End If

        End If
    End Function
End Class
