Public Class MainForm

    Dim WithEvents ts As TemperatureServerLib.TempMeterServer ' = New TemperatureServerLib.TempMeterServer  ' get instance of the temperatureserver


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        ' ts = New TemperatureServerLib.TempMeterServer

        ' Enumerate()

        ' AddHandler ts.OnMeasurement, AddressOf ts_OnMeasurement                 ' Connect our event handler  

    End Sub

    Public Sub Enumerate()

        Dim devs As TemperatureServerLib.DeviceInfoCollection
        Dim devinfo As TemperatureServerLib.DeviceInfo
        Dim i As Integer

        devs = ts.GetDevices                ' get the collection of devices
        For i = 1 To devs.Count             ' loop thru the collection 
            devinfo = devs(i)               ' get next device info

            Dim startDate As Date = Date.Now.Subtract(TimeSpan.FromDays(1))
            Dim endDate As Date = Date.Now

            Dim dates As Double() = Nothing
            Dim values As Single() = Nothing

            Debug.Print("{0} ({1}, {2})", devinfo.Name, devinfo.GetUniqueID(), devinfo.idDevice)       ' use the information

            devinfo.GetLogRange(startDate, endDate)

            devinfo.GetLog(startDate, endDate, Nothing, dates, values)

            Dim J As Integer

            For J = 0 To dates.Length - 1

                Debug.Print(Date.FromOADate(dates(J)).ToString & " - " & values(J))
            Next





        Next
    End Sub

    Private Sub ts_OnDatasetUpdated(idDevice As UInteger, typeDevice As UInteger) Handles ts.OnDatasetUpdated

    End Sub

    Private Sub ts_OnDeviceRemoved(idDevice As UInteger, typeDevice As UInteger) Handles ts.OnDeviceRemoved

    End Sub

    Private Sub ts_OnError(strErr As String) Handles ts.OnError

    End Sub

    Private Sub ts_OnMeasurement(type As UInteger, v As Object) Handles ts.OnMeasurement
        Dim s As String
        s = type.ToString() + " " + v(0).ToString() + " " + v(1).ToString() + " " + v(2).ToString()
        Debug.Print(s)


    End Sub
End Class
