Imports System.Windows.Forms.DataVisualization.Charting
Imports TemperatureDataCore

Public Class MainForm
    Implements ILog

    Private mConnectionString As String
    Private mTemperatureTableName As String
    Private mDeviceTableName As String
    Private WithEvents mReader As TemperatureReader
    Private mTemperatureAgregator As TemperatureAggregater

    Private mDeviceLatest As New Dictionary(Of Integer, DateTime)

    Private mDeviceList As New Dictionary(Of Integer, DeviceDetail)

    Private mRequiredTemperatures As SenseAndReact

    Public Sub New(connectionString As String, temperatureTableName As String, deviceTableName As String, reader As TemperatureReader, devices As Devices, requiredTemperatures As SenseAndReact)

        mConnectionString = connectionString
        mDeviceTableName = deviceTableName
        mTemperatureTableName = temperatureTableName

        InitializeComponent()

        mReader = reader

        mDeviceList = devices.DeviceListing

        mRequiredTemperatures = requiredTemperatures

        mTemperatureAgregator = New TemperatureAggregater(mConnectionString, mTemperatureTableName, mDeviceTableName)

    End Sub

    Private Sub UpdateGraphButton_Click(sender As System.Object, e As System.EventArgs) Handles UpdateGraphButton.Click

        Dim currentTemperatures = mTemperatureAgregator.GetDeviceTemperatures()

        Dim requiredTemps As Dictionary(Of Integer, Double)

        StatusLabel.Text = ""

        requiredTemps = mRequiredTemperatures.GetDeviceExpectedTemperatures

        ReadingGraph.Series.Item(0).Points.Clear()

        Dim bar As Integer = 1

        For Each tempPair In currentTemperatures.Values

            Dim currentTemp As New DataPoint

            Dim Devicedata As DeviceDetail = Nothing

            If mDeviceList.TryGetValue(tempPair.DeviceId, Devicedata) Then
                currentTemp.AxisLabel = Devicedata.Location
            Else
                currentTemp.AxisLabel = tempPair.DeviceId
            End If

            currentTemp.SetValueXY(bar, tempPair.Temperature)

            ReadingGraph.Series.Item(0).Points.Add(currentTemp)

            bar = bar + 1

            Dim desiredTemp As New DataPoint

            Dim desiredTemperature As Double = 0

            If requiredTemps.TryGetValue(tempPair.DeviceId, desiredTemperature) Then


            End If

            desiredTemp.SetValueXY(bar, desiredTemperature)
            desiredTemp.AxisLabel = "Desired"

            desiredTemp.Color = Color.Red

            ReadingGraph.Series.Item(0).Points.Add(desiredTemp)

            bar = bar + 1

            Dim shouldBeOn As Boolean = desiredTemperature > tempPair.Temperature

            StatusLabel.Text = StatusLabel.Text & vbCrLf & Devicedata.Location & " (Current=" & Format(tempPair.Temperature, "0.0") & " : Desired=" & desiredTemperature & ") Switch " & IIf(shouldBeOn, "On", "Off")

        Next
    End Sub

    Public Sub AddEntry(format As String, ParamArray args() As Object) Implements ILog.AddEntry
        If Me.InvokeRequired Then
            Me.Invoke(Sub() AddEntry(format, args))
            Return
        End If

        Dim description = String.Format(format, args)
        Me.EventList.Items.Insert(0, New ListViewItem(New String() {DateTime.Now.ToString(), description}))
    End Sub

    Private Sub mReader_ReadingObserved(sender As Object, e As TemperatureDataReceivedEventArgs) Handles mReader.ReadingObserved
        AddEntry("{0} (#{1}) {2} {3} {4}°C", e.SensorDescription, e.SensorId, e.LogDateTime, e.ReceivedDateTime, e.ReadingInDegrees)
    End Sub
End Class
