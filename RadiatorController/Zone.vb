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

    Public ReadOnly Property Settings As TemperatureSettings
        Get
            Return mTimes
        End Get
    End Property

    Public Sub EvaluateTimeAndTemperature(ByVal currentTime As DateTime)
        Dim desiredTemperature = mTimes.GetDesiredTemperature(currentTime)

        If desiredTemperature = 0 Then
            mRadiator.EnsureOff()
            Return
        End If

        If DecisionHelper.ShouldRadiatorBeOn(mRadiator.IsOn, desiredTemperature, mSensor.Reading) Then
            mRadiator.EnsureOn()
        Else
            mRadiator.EnsureOff()
        End If
    End Sub
End Class
