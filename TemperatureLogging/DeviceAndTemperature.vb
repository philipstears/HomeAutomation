Public Class DeviceAndTemperature
    Private mDeviceId As Integer
    Private mTemperature As Double

    Public Sub New(ByVal deviceId As Integer, ByVal temperature As Double)
        mDeviceId = deviceId
        mTemperature = temperature
    End Sub

    Public ReadOnly Property DeviceId As Integer
        Get
            Return mDeviceId
        End Get
    End Property

    Public Property Temperature As Double
        Get
            Return mTemperature
        End Get
        Set(value As Double)
            mTemperature = value
        End Set
    End Property
End Class