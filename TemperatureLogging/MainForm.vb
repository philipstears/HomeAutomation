Imports System.Windows.Forms.DataVisualization.Charting
Imports TemperatureLogging.Devices

Public Class MainForm

    Private mConnectionString As String
    Private mTemperatureTableName As String
    Private mDeviceTableName As String
    Private mTemperatureAgregator As TemperatureAggregater

    Private mDeviceLatest As New Dictionary(Of Integer, DateTime)

    Private mDeviceList As New Dictionary(Of Integer, DeviceDetail)

    Private mRequiredTemperatures As SenseAndReact

    Public Sub New(connectionString As String, temperatureTableName As String, deviceTableName As String, devices As Devices, requiredTemperatures As SenseAndReact)

        mConnectionString = connectionString
        mDeviceTableName = deviceTableName
        mTemperatureTableName = temperatureTableName

        InitializeComponent()

        mDeviceList = devices.DeviceListing

        mRequiredTemperatures = requiredTemperatures

        mTemperatureAgregator = New TemperatureAggregater(mConnectionString, mTemperatureTableName, mDeviceTableName)

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Dim mCurrentTemperatures As Dictionary(Of Integer, Double) = mTemperatureAgregator.GetDeviceTemperatures()

        Dim requiredTemps As Dictionary(Of Integer, Double)

        Label1.Text = ""

        requiredTemps = mRequiredTemperatures.GetDeviceExpectedTemperatures

        Chart1.Series.Item(0).Points.Clear()

        Dim bar As Integer = 1

        For Each tempPair In mCurrentTemperatures

            Dim currentTemp As New DataPoint

            Dim Devicedata As DeviceDetail = Nothing

            If mDeviceList.TryGetValue(tempPair.Key, Devicedata) Then
                currentTemp.AxisLabel = Devicedata.Location
            Else
                currentTemp.AxisLabel = tempPair.Key
            End If

            currentTemp.SetValueXY(bar, tempPair.Value)

            Chart1.Series.Item(0).Points.Add(currentTemp)

            bar = bar + 1

            Dim desiredTemp As New DataPoint

            Dim desiredTemperature As Double = 0

            If requiredTemps.TryGetValue(tempPair.Key, desiredTemperature) Then


            End If

            desiredTemp.SetValueXY(bar, desiredTemperature)
            desiredTemp.AxisLabel = "Desired"

            desiredTemp.Color = Color.Red

            Chart1.Series.Item(0).Points.Add(desiredTemp)

            bar = bar + 1

            Dim shouldBeOn As Boolean = desiredTemperature > tempPair.Value

            Label1.Text = Label1.Text & vbCrLf & Devicedata.Location & " (Current=" & Format(tempPair.Value, "0.0") & " : Desired=" & desiredTemperature & ") Switch " & IIf(shouldBeOn, "On", "Off")

        Next
    End Sub
End Class
