Imports TemperatureDataCore
Imports RelayController

Public Class SensorAndRelayModel
    Private mLocation As String
    Private mRelayIndex As Integer
    Private mSensorId As Integer
    Private mIsControlled As Boolean

    Private mCurrentTemperature As Double?
    Private mDesiredTemperature As Double?

    Private mCurrentRelayStatus As RelayStatus?
    Private mDesiredRelayStatus As RelayStatus?

    Public Event IsControlledChanged As EventHandler
    Public Event CurrentTemperatureChanged As EventHandler
    Public Event DesiredTemperatureChanged As EventHandler
    Public Event CurrentRelayStatusChanged As EventHandler
    Public Event DesiredRelayStatusChanged As EventHandler

    Public Sub New(ByVal details As DeviceDetail)
        mLocation = details.Location
        mRelayIndex = details.Relay
        mSensorId = details.DeviceID
        mIsControlled = details.ControlLocation
    End Sub

    Public ReadOnly Property Location As String
        Get
            Return mLocation
        End Get
    End Property

    Public ReadOnly Property RelayIndex As Integer
        Get
            Return mRelayIndex
        End Get
    End Property

    Public ReadOnly Property SensorId As Integer
        Get
            Return mSensorId
        End Get
    End Property

    Public Property IsControlled As Boolean
        Get
            Return mIsControlled
        End Get
        Set(value As Boolean)
            mIsControlled = value
            RaiseEvent IsControlledChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property CurrentTemperature As Double?
        Get
            Return mCurrentTemperature
        End Get
        Set(value As Double?)
            mCurrentTemperature = value
            RaiseEvent CurrentTemperatureChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property DesiredTemperature As Double?
        Get
            Return mDesiredTemperature
        End Get
        Set(value As Double?)
            mDesiredTemperature = value
            RaiseEvent DesiredTemperatureChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property CurrentRelayStatus As RelayStatus?
        Get
            Return mCurrentRelayStatus
        End Get
        Set(value As RelayStatus?)
            mCurrentRelayStatus = value
            RaiseEvent CurrentRelayStatusChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property DesiredRelayStatus As RelayStatus?
        Get
            Return mDesiredRelayStatus
        End Get
        Set(value As RelayStatus?)
            mDesiredRelayStatus = value
            RaiseEvent DesiredTemperatureChanged(Me, EventArgs.Empty)
        End Set
    End Property
End Class
