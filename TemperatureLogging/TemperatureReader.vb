Public Class TemperatureReader
    Public Event ReadingObserved As EventHandler(Of TemperatureDataReceivedEventArgs)

    Private ReadOnly mBaseDate As New DateTime(1899, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc)
    Private mTemp As New TemperatureServerLib.TempMeterServer()
    Private mTimer As New Threading.Timer(AddressOf DoRead, Nothing, 0, 15 * 1000)
    Private mLastReading As DateTime = DateTime.MinValue

    Public Sub New()

    End Sub

    Private Sub DoRead(ByVal state As Object)
        Dim startDate As DateTime = mLastReading
        Dim endDate As DateTime = DateTime.UtcNow

        For Each device As TemperatureServerLib.DeviceInfo In mTemp.GetDevices()
            DoReadDevice(device, startDate, endDate)
        Next

        mLastReading = DateTime.UtcNow
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
    End Sub
End Class
