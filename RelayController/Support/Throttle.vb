﻿Imports System.Threading

Namespace Support

    ''' <summary>
    ''' Provides support for throttling sequences of operations.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Throttle
        Private mMinimumInterval As TimeSpan
        Private mLast As DateTime

        Public Sub New(ByVal minimumTimeBetweenCalls As TimeSpan)
            mMinimumInterval = minimumTimeBetweenCalls
        End Sub

        Public Sub WaitUntilReady()
            Dim timeSinceLastCommand = DateTime.UtcNow.Subtract(mLast)

            If timeSinceLastCommand < mMinimumInterval Then
                Thread.Sleep(mMinimumInterval.Subtract(timeSinceLastCommand))
            End If

            mLast = DateTime.UtcNow
        End Sub
    End Class
End Namespace