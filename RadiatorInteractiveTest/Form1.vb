Imports RadiatorController
Imports RelayController

Public Class Form1
    Dim sensor0 As New FakeSensor()
    Dim radiator0 As New FakeRadiator()
    Dim radiator1 As New FakeRadiator()
    Dim ready As Boolean = False

    Dim mRelayBoard As DenkoviRelayBoard = DenkoviRelayBoard.Open(5)
    Dim radiatorManager As New DenkoviRadiatorManager(mRelayBoard)
    Dim realRadiator0 = radiatorManager.GetRadiator(RelayOption.Relay0)
    Dim realRadiator1 = radiatorManager.GetRadiator(RelayOption.Relay1)


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SetStatus0(False)

        UpdateTime()
        Apply()

        ready = True
    End Sub


    Private Sub SetStatus0(IsOn As Boolean)

        If IsOn Then
            picLampOn0.Visible = True
            picLampOff0.Visible = False
            lblCurrentStatus0.Text = "On"
        Else
            picLampOn0.Visible = False
            picLampOff0.Visible = True
            lblCurrentStatus0.Text = "Off"
        End If
    End Sub

    Private Sub Apply()
        If Not ready Then
            Return
        End If

        Dim zone0 As New Zone("The Zone", realRadiator0, sensor0)
        Dim zone1 As New Zone("The Zone 2", realRadiator1, sensor0)

        zone0.Settings.AddSetting(New TemperatureSetting(#1:00:00 AM#, Double.Parse(txtDesiredTemp0.Text)))
        zone0.Settings.AddSetting(New TemperatureSetting(#6:00:00 AM#, Double.Parse(txtDesiredTemp1.Text)))
        zone0.Settings.AddSetting(New TemperatureSetting(#1:00:00 PM#, Double.Parse(txtDesiredTemp2.Text)))
        zone0.Settings.AddSetting(New TemperatureSetting(#10:00:00 PM#, Double.Parse(txtDesiredTemp3.Text)))

        zone1.Settings.AddSetting(New TemperatureSetting(#1:00:00 AM#, Double.Parse(txtDesiredTemp0.Text)))
        zone1.Settings.AddSetting(New TemperatureSetting(#6:00:00 AM#, Double.Parse(txtDesiredTemp1.Text)))
        zone1.Settings.AddSetting(New TemperatureSetting(#1:00:00 PM#, Double.Parse(txtDesiredTemp2.Text)))
        zone1.Settings.AddSetting(New TemperatureSetting(#10:00:00 PM#, Double.Parse(txtDesiredTemp3.Text)))

        sensor0.SetReading(numCurrentTemp0.Value)

        zone0.EvaluateTimeAndTemperature(GetTime())
        zone1.EvaluateTimeAndTemperature(GetTime())

        SetStatus0(realRadiator0.IsOn)
    End Sub

    Private Function GetTime() As DateTime
        Dim currentMinute = TimeTrack.Value
        Dim currentTime = New DateTime(0).Add(TimeSpan.FromMinutes(currentMinute))
        Return currentTime
    End Function

    Private Sub UpdateTime()
        TimeLabel.Text = GetTime().ToLongTimeString()
    End Sub

    Private Sub TimeTrack_Scroll(sender As System.Object, e As System.EventArgs) Handles TimeTrack.Scroll
        UpdateTime()
        Apply()
    End Sub

    Private Sub numCurrentTemp0_ValueChanged(sender As System.Object, e As System.EventArgs) Handles numCurrentTemp0.ValueChanged
        Apply()
    End Sub
End Class
