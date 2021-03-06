Imports RelayController

<DebuggerDisplay("{StartTime,nq} - {DesiredTemperature,nq}�C")>
Public Class TemperatureSetting
    Implements IComparable(Of TemperatureSetting)

    Private mStartTime As DateTime
    Private mDesiredTemperature As Double

    Public Sub New(ByVal startTime As DateTime, ByVal desiredTemperature As Double)
        mStartTime = startTime
        mDesiredTemperature = desiredTemperature
    End Sub

    Public ReadOnly Property StartTime As DateTime
        Get
            Return mStartTime
        End Get
    End Property

    Public ReadOnly Property DesiredTemperature As Double
        Get
            Return mDesiredTemperature
        End Get
    End Property

    Public Function CompareTo(other As TemperatureSetting) As Integer Implements System.IComparable(Of TemperatureSetting).CompareTo
        Return mStartTime.CompareTo(other.mStartTime)
    End Function
End Class
