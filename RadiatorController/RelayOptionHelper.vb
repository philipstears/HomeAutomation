Public NotInheritable Class RelayOptionHelper
    Private Sub New()
    End Sub

    Public Shared Function ToIndex(ByVal relay As RelayOption) As Integer
        Dim bitIndex = CInt(Math.Log(CInt(relay), 2))
        Return BitIndexToLinearIndex(bitIndex)
    End Function

    Public Shared Function FromIndex(ByVal index As Integer) As RelayOption
        Dim bitIndex = LinearIndexToBitIndex(index)
        Return CInt(Math.Pow(2, bitIndex))
    End Function

    Private Shared Function BitIndexToLinearIndex(ByVal index As Integer) As Integer
        If index <= 7 Then
            Return 7 - index
        Else
            Return 8 + (15 - index)
        End If
    End Function

    Private Shared Function LinearIndexToBitIndex(ByVal index As Integer) As Integer
        If index <= 7 Then
            Return 7 - index
        Else
            Return 8 + (15 - index)
        End If
    End Function
End Class