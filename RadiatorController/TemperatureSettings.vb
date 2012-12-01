Imports RelayController

Public Class TemperatureSettings
    Private mSettings As New List(Of TemperatureSetting)()
    Private mLastSetting As TemperatureSetting
    Private mOverride As Integer?

    Public Sub AddSetting(ByVal setting As TemperatureSetting)
        mSettings.Add(setting)
        mSettings.Sort()
    End Sub

    Public Property Override As Integer?
        Get
            Return mOverride
        End Get
        Set(value As Integer?)
            mOverride = value
        End Set
    End Property

    Public Function GetDesiredTemperature(ByVal currentTime As DateTime) As Integer
        Dim previousSetting = mLastSetting
        Dim currentSetting = FindCurrentSetting(currentTime)
        mLastSetting = currentSetting

        If mOverride.HasValue Then
            Dim hasEvaluatedPreviously = previousSetting IsNot Nothing
            Dim hasChanged = hasEvaluatedPreviously AndAlso currentSetting IsNot previousSetting

            If hasChanged Then
                mOverride = Nothing
            Else
                Return mOverride.Value
            End If
        End If

        If currentSetting Is Nothing Then
            Return 0
        Else
            Return currentSetting.DesiredTemperature
        End If
    End Function

    Private Function FindCurrentSetting(ByVal currentTime As DateTime) As TemperatureSetting

        ' Find the last setting whose start time is before the current time
        For i As Integer = mSettings.Count - 1 To 0 Step -1
            Dim setting = mSettings(i)

            If setting.StartTime <= currentTime Then
                Return setting
            End If
        Next

        ' If the doesn't work, then the applicable setting must be the
        ' last one from the previous day, ergo, the last setting
        Return mSettings.Last
    End Function
End Class
