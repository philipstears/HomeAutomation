Imports TemperatureDataCore
Imports RelayController
Imports RadiatorController

Public Class SensorAndRelayModel
    Private WithEvents mRadiator As IRadiator

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

    Public Sub New(ByVal details As DeviceDetail, ByVal radiator As IRadiator)
        mLocation = details.Location
        mRelayIndex = details.Relay
        mSensorId = details.DeviceID
        mIsControlled = details.ControlLocation

        mRadiator = radiator
        LoadRadiatorStatus()
    End Sub

    Private Sub LoadRadiatorStatus()
        CurrentRelayStatus = If(mRadiator.IsOn, RelayStatus.On, RelayStatus.Off)
    End Sub

    Public ReadOnly Property Radiator As IRadiator
        Get
            Return mRadiator
        End Get
    End Property

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
            UpdateDesiredRelayStatus()
        End Set
    End Property

    Public Property DesiredTemperature As Double?
        Get
            Return mDesiredTemperature
        End Get
        Set(value As Double?)
            mDesiredTemperature = value
            RaiseEvent DesiredTemperatureChanged(Me, EventArgs.Empty)
            UpdateDesiredRelayStatus()
        End Set
    End Property

    Private Sub UpdateDesiredRelayStatus()
        If Not CurrentTemperature.HasValue OrElse Not DesiredTemperature.HasValue Then
            SetDesiredRelayStatus(Nothing)
            Return
        End If

        ' Assume it's on if not known
        Dim currentlyOn = If(CurrentRelayStatus, RelayStatus.On) = RelayStatus.On

        ' Set the desired status
        Dim desiredStatus = DecisionHelper.ShouldRadiatorBeOn(currentlyOn, DesiredTemperature.Value, CurrentTemperature.Value)
        SetDesiredRelayStatus(If(desiredStatus, RelayStatus.On, RelayStatus.Off))
    End Sub

    Public Property CurrentRelayStatus As RelayStatus?
        Get
            Return mCurrentRelayStatus
        End Get
        Set(value As RelayStatus?)
            mCurrentRelayStatus = value
            RaiseEvent CurrentRelayStatusChanged(Me, EventArgs.Empty)
            UpdateDesiredRelayStatus()
        End Set
    End Property

    Public ReadOnly Property DesiredRelayStatus As RelayStatus?
        Get
            Return mDesiredRelayStatus
        End Get
    End Property

    Private Sub SetDesiredRelayStatus(ByVal value As RelayStatus?)
        mDesiredRelayStatus = value
        RaiseEvent DesiredRelayStatusChanged(Me, EventArgs.Empty)
    End Sub

    Private Sub mRadiator_IsOnChanged(sender As Object, e As EventArgs) Handles mRadiator.IsOnChanged
        LoadRadiatorStatus()
    End Sub
End Class
