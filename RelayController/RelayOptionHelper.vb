Public NotInheritable Class RelayOptionHelper
    Private Sub New()
    End Sub

    Public Shared Function ToIndex(ByVal relay As RelayOption) As Integer
        Return CInt(Math.Log(CInt(relay), 2))
    End Function

    Public Shared Function FromIndex(ByVal index As Integer) As RelayOption
        Return CInt(Math.Pow(2, index))
    End Function
End Class