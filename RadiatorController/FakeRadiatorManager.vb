Public Class FakeRadiatorManager
    Implements IIndexedRadiatorManager

    Private mRadiators As New Dictionary(Of Integer, IRadiator)()

    Public Function GetRadiator(index As Integer) As IRadiator Implements IIndexedRadiatorManager.GetRadiator
        Dim radiator As IRadiator = Nothing

        If Not mRadiators.TryGetValue(index, radiator) Then
            radiator = New FakeRadiator()
            mRadiators.Add(index, radiator)
        End If

        Return radiator
    End Function
End Class
