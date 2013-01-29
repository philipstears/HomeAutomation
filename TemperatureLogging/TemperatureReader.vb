Imports TemperatureDataCore

Public Class TemperatureReader
    Private ReadOnly NoPeriodicSignalling As TimeSpan = TimeSpan.FromMilliseconds(-1)
    Private ReadOnly Every15Seconds As TimeSpan = TimeSpan.FromSeconds(15)

    Public Event ReadingObserved As EventHandler(Of TemperatureDataReceivedEventArgs)

    Private ReadOnly mBaseDate As New DateTime(1899, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc)

    Private mTemp As New TemperatureServerLib.TempMeterServer()
    Private mTimer As New Threading.Timer(AddressOf DoRead, Nothing, Every15Seconds, NoPeriodicSignalling)

    ' we are making the assumption now that if a sensor has been unavailable, or the program is off, then we will go back and collect the last 24 hours of data.
    Private mLastReading As DateTime = DateTime.UtcNow - New TimeSpan(1, 0, 0, 0)

    Private mDeviceLatest As Dictionary(Of Integer, DateTime)

    Public Sub New(devices As Devices)

        mDeviceLatest = devices.Devicelatest

    End Sub

    Private Sub DoRead(ByVal state As Object)
        Dim startDate As DateTime = mLastReading
        Dim endDate As DateTime = DateTime.UtcNow

        For Each device As TemperatureServerLib.DeviceInfo In mTemp.GetDevices()

            If mDeviceLatest.ContainsKey(device.idDevice) Then

                Dim deviceStart As DateTime

                If Not mDeviceLatest.TryGetValue(device.idDevice, deviceStart) Then

                    deviceStart = startDate
                End If

                DoReadDevice(device, deviceStart, endDate)

                mDeviceLatest(device.idDevice) = endDate
            End If
        Next

        mLastReading = startDate
    End Sub

    Private Sub DoReadDevice(ByVal device As TemperatureServerLib.DeviceInfo, ByVal startDate As DateTime, ByVal endDate As DateTime)
        Dim dates As Double() = Nothing
        Dim values As Single() = Nothing

        device.GetLog(startDate, endDate, Nothing, dates, values)

        ' Null reference is returned if there is no log data
        If dates Is Nothing Then Return

        For i = 0 To dates.Length - 1
            Dim logDate = mBaseDate.AddDays(dates(i))
            Dim value = CDec(values(i))

            RaiseEvent ReadingObserved(Me, New TemperatureDataReceivedEventArgs(device.idDevice, device.Name, logDate, DateTime.UtcNow, value))
        Next

        mTimer.Change(Every15Seconds, NoPeriodicSignalling)
    End Sub
End Class
