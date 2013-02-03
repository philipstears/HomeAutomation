Public Class TemperatureReadings

    Private mDeviceID As Integer
    Private mControlLocation As Boolean
    Private mReadings As New Dictionary(Of Integer, Double)

    Public Sub New(deviceID As Integer, controlLocation As Boolean)

        mDeviceID = deviceID
        mControlLocation = controlLocation

    End Sub

    Public ReadOnly Property Readings As Dictionary(Of Integer, Double)
        Get
            Return mReadings
        End Get
    End Property

    Public ReadOnly Property Temperature As Double
        Get
            Return GetTemperature()
        End Get
    End Property

    Public Sub AddData(readingID As Integer, temperature As Double)

        mReadings(readingID) = temperature

    End Sub

    Private Function GetTemperature() As Double

        Dim finaltemp As Double = -1000

        Select Case mReadings.Count

            Case 0

                ' we do not, set to a silly value
                Return finaltemp
            Case 1

                ' we have one reading, lets take it
                Return mReadings(1)
            Case 2

                ' see if its more than 5 above or below - if it is, lets aggregate
                If mReadings(1) > mReadings(2) + 5 Or mReadings(1) < mReadings(2) - 5 Then

                    ' its outside the limits, take an average
                    Return (mReadings(1) + mReadings(2)) / 2

                Else

                    ' its inside the limits, take the latest reading
                    Return mReadings(1)

                End If
            Case 3

                ' see if its more than 5 above or below - if it is, lets aggregate
                If mReadings(1) > mReadings(2) + 5 Or mReadings(1) < mReadings(2) - 5 Then

                    ' see if its more than 5 above or below - if it is, lets aggregate
                    If mReadings(2) > mReadings(3) + 5 Or mReadings(2) < mReadings(3) - 5 Then

                        ' assume 2 is a rogue value
                        Return mReadings(1)

                    Else

                        ' its inside the limits, take an average of 2 and 3
                        Return (mReadings(2) + mReadings(3)) / 2

                    End If

                Else

                    ' its inside the limits, take the latest reading
                    Return mReadings(1)

                End If
            Case Else

                ' we do not, set to a silly value
                Return finaltemp
        End Select

    End Function

End Class
