Imports RelayController

Public Class RadiatorController
    Private WithEvents mTimer As New System.Windows.Forms.Timer() With {
        .Interval = 10 * 1000,
        .Enabled = True
    }

    Private mRadiators As New List(Of Zone)()

    Public Function AddZone(ByVal name As String, radiator As IRadiator, ByVal sensor As ITemperatureSensor) As Zone
        Dim zone As New Zone(name, radiator, sensor)
        mRadiators.Add(zone)
        Return zone
    End Function

    Private Sub mTimer_Tick(sender As Object, e As System.EventArgs) Handles mTimer.Tick
        For Each radiator In mRadiators
            radiator.EvaluateTimeAndTemperature()
        Next
    End Sub
End Class
