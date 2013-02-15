Imports System.Windows.Forms.DataVisualization.Charting
Imports TemperatureDataCore
Imports System.Collections.Concurrent

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

    Private Sub UpdateTimer_Tick(sender As Object, e As EventArgs) Handles UpdateTimer.Tick
        AddPendingItems()
        UpdateGraph()
    End Sub

    Private Sub UpdateGraph()

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

    Private Const MAX_ENTRIES As Integer = 5000
    Private Const MAX_ENTRY_INDEX As Integer = MAX_ENTRIES - 1
    Private mPendingItems As New ConcurrentQueue(Of ListViewItem)()

    Public Sub AddEntry(format As String, ParamArray args() As Object) Implements ILog.AddEntry
        mPendingItems.Enqueue(New ListViewItem(New String() {DateTime.Now.ToString(), String.Format(format, args)}))
    End Sub

    Private Sub mReader_ReadingObserved(sender As Object, e As TemperatureDataReceivedEventArgs) Handles mReader.ReadingObserved
        AddEntry("{0} (#{1}) {2} {3} {4}°C", e.SensorDescription, e.SensorId, e.LogDateTime, e.ReceivedDateTime, e.ReadingInDegrees)

        ' update the top list with the data from this reading
        UpdateLatestTimesAndTemps(sender, e)
    End Sub

    Private Sub AddPendingItems()
        Dim currentItem As ListViewItem = Nothing
        Dim modified As Boolean = False

        While mPendingItems.TryDequeue(currentItem)
            If Not modified Then
                EventList.BeginUpdate()
                modified = True
            End If

            If Me.EventList.Items.Count = MAX_ENTRIES Then
                Me.EventList.Items.RemoveAt(MAX_ENTRY_INDEX)
            End If

            EventList.Items.Insert(0, currentItem)
        End While

        If modified Then
            EventList.EndUpdate()
        End If
    End Sub

    Private Sub UpdateLatestTimesAndTemps(sender As Object, e As TemperatureDataReceivedEventArgs)

        ' Get the relay number from the devices list

        Dim relayNumber As Integer = 0
        Dim device As TemperatureDataCore.DeviceDetail = Nothing

        ' we need the relay number for this device so that we can update the correct row in the list
        If mDeviceList.TryGetValue(e.SensorId, device) Then

            ' we have one - get the relay number
            relayNumber = device.Relay

        End If

        ' make sure there is a relay number - its one based, not zero, so if its zero, it wasn't found.
        If relayNumber > 0 Then

            ' go down the list looking for the correct relay
            For Each itemInList As ListViewItem In LatestEvents.Items

                ' see if it matches the number - probably should have a better way of comparing
                If itemInList.Text = relayNumber.ToString Then

                    ' update the 3 items in the row
                    itemInList.SubItems(1).Text = e.SensorDescription
                    itemInList.SubItems(2).Text = e.LogDateTime.ToString
                    itemInList.SubItems(3).Text = e.ReadingInDegrees.ToString

                    ' we found it, quit
                    Exit For

                End If

            Next
        End If

    End Sub
End Class
