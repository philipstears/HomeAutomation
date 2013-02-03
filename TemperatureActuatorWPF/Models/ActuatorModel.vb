Imports System.Collections.ObjectModel
Imports System.Threading
Imports RadiatorController
Imports TemperatureDataCore
Imports System.IO.Ports
Imports RelayController

Public Class ActuatorModel
    Private mDevicesById As New Dictionary(Of Integer, SensorAndRelayModel)()
    Private mDevicesForBinding As New ObservableCollection(Of SensorAndRelayModel)()

    Private mRadiatorManager As IIndexedRadiatorManager
    Private mRegisteredDevices As Devices
    Private mTemperatureUserSettings As SenseAndReact
    Private mAggregator As TemperatureAggregater

    Private mTimer As New Timer(Sub()
                                    Refresh()
                                    QueueNextUpdate()
                                End Sub)

    Public Sub New()
        mRadiatorManager = GetRadiatorManager()
        mRegisteredDevices = New Devices(MySettings.Default.Database, MySettings.Default.TemperatureTable, MySettings.Default.DeviceTable)
        mTemperatureUserSettings = New SenseAndReact(MySettings.Default.Database, MySettings.Default.TemperatureTable, MySettings.Default.DeviceTable, mRegisteredDevices)
        mAggregator = New TemperatureAggregater(MySettings.Default.Database, MySettings.Default.TemperatureTable, MySettings.Default.DeviceTable)
        LoadSettings()
        QueueNextUpdate()
    End Sub

    Private Shared Function GetRadiatorManager() As IIndexedRadiatorManager
        Dim name = MySettings.Default.RadiatorComPort

        If Not name.Equals("FAKE", StringComparison.OrdinalIgnoreCase) Then
            Try
                Dim port As New SerialPort(name)
                port.Open()

                Return New DenkoviRadiatorManager(New DenkoviRelayBoard(port))
            Catch ex As Exception
                MessageBox.Show(String.Format("Couldn't connect to the Denkovi Relay Board using the specified communication port {0}. A fake radiator controller will be used instead. {1}", name, ex.Message), "Radiator Manager", MessageBoxButton.OK, MessageBoxImage.Warning)
            End Try
        End If

        Return New FakeRadiatorManager()
    End Function

    Public ReadOnly Property Devices As ObservableCollection(Of SensorAndRelayModel)
        Get
            Return mDevicesForBinding
        End Get
    End Property

    Public Sub Refresh()
        UpdateDesiredReadings()
        UpdateActualReadings()
        ApplyRadiatorSettings()
    End Sub

    Private Sub QueueNextUpdate()
        mTimer.Change(TimeSpan.FromSeconds(5), TimeSpan.FromMilliseconds(-1))
    End Sub

    Private Sub LoadSettings()
        For Each device In mRegisteredDevices.DeviceListing.Values

            ' DB/UI is 1-based, but radiator manager is 0-based
            Dim radiator = mRadiatorManager.GetRadiator(device.Relay - 1)
            Dim model As New SensorAndRelayModel(device, radiator)
            mDevicesById(device.DeviceID) = model
            mDevicesForBinding.Add(model)
        Next
    End Sub

    Private Sub UpdateActualReadings()
        For Each reading In mAggregator.GetDeviceTemperatures().Values
            Dim model As SensorAndRelayModel = Nothing

            If Not mDevicesById.TryGetValue(reading.DeviceId, model) Then
                Continue For
            End If

            model.CurrentTemperature = reading.Temperature
        Next
    End Sub

    Private Sub UpdateDesiredReadings()
        For Each reading In mTemperatureUserSettings.GetDeviceExpectedTemperatures()
            Dim model As SensorAndRelayModel = Nothing

            If Not mDevicesById.TryGetValue(reading.Key, model) Then
                Continue For
            End If

            model.DesiredTemperature = reading.Value
        Next
    End Sub

    Private Sub ApplyRadiatorSettings()
        For Each device In mDevicesForBinding
            If device.DesiredRelayStatus.HasValue AndAlso device.DesiredRelayStatus <> device.CurrentRelayStatus Then
                Dim shouldBeOn = device.DesiredRelayStatus.Value = RelayController.RelayStatus.On

                If shouldBeOn Then
                    device.Radiator.EnsureOn()
                Else
                    device.Radiator.EnsureOff()
                End If
            End If
        Next
    End Sub
End Class
