Imports TemperatureDataCore
Imports System.Collections.ObjectModel

Class MainWindow
    Private mDevicesById As New Dictionary(Of Integer, SensorAndRelayModel)()
    Private mDevicesForBinding As New ObservableCollection(Of SensorAndRelayModel)()

    Private mDevices As Devices
    Private mSettingsReader As SenseAndReact
    Private mAggregator As TemperatureAggregater

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mDevices = New Devices(MySettings.Default.Database, MySettings.Default.TemperatureTable, MySettings.Default.DeviceTable)
        mSettingsReader = New SenseAndReact(MySettings.Default.Database, MySettings.Default.TemperatureTable, MySettings.Default.DeviceTable, mDevices)
        mAggregator = New TemperatureAggregater(MySettings.Default.Database, MySettings.Default.TemperatureTable, MySettings.Default.DeviceTable)

        LoadSettings()
        UpdateDesiredReadings()
        UpdateActualReadings()
    End Sub

    Public ReadOnly Property Devices As ObservableCollection(Of SensorAndRelayModel)
        Get
            Return mDevicesForBinding
        End Get
    End Property

    Private Sub LoadSettings()
        For Each device In mDevices.DeviceListing.Values
            Dim model As New SensorAndRelayModel(device)
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
        For Each reading In mSettingsReader.GetDeviceExpectedTemperatures()
            Dim model As SensorAndRelayModel = Nothing

            If Not mDevicesById.TryGetValue(reading.Key, model) Then
                Continue For
            End If

            model.DesiredTemperature = reading.Value
        Next
    End Sub
End Class
