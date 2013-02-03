Public NotInheritable Class DecisionHelper
    Private Const THRESHOLD_IN_DEG_C As Integer = 1

    Private Sub New()
    End Sub

    Public Shared Function ShouldRadiatorBeOn(ByVal currentlyOn As Boolean, ByVal desiredTemperature As Double, ByVal currentTemperature As Double) As Boolean
        If currentlyOn Then

            Dim switchOffTemperature = desiredTemperature + THRESHOLD_IN_DEG_C

            If currentTemperature >= switchOffTemperature Then
                Return False
            Else
                Return True
            End If

        Else

            Dim switchOnTemperature = desiredTemperature

            If currentTemperature <= switchOnTemperature Then
                Return True
            Else
                Return False
            End If

        End If
    End Function
End Class
