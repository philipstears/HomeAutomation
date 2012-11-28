Imports System.Data.SqlClient

Public Class Logger
    Private mConnectionString As String
    Private mTableName As String
    Private WithEvents mReader As TemperatureReader

    Public Sub New(connectionString As String, tableName As String, ByVal reader As TemperatureReader)
        mConnectionString = connectionString
        mTableName = tableName
        mReader = reader
    End Sub

    Public Sub LogReading(ByVal reading As TemperatureDataReceivedEventArgs)
        Using connection = New SqlConnection(mConnectionString)
            connection.Open()

            Using cmd = connection.CreateCommand()
                cmd.CommandText = "AddTemperatureReading"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@deviceId", reading.SensorId)
                cmd.Parameters.AddWithValue("@eventDateTimeUtc", reading.LogDateTime)
                cmd.Parameters.AddWithValue("@logDateTimeUtc", reading.ReceivedDateTime)
                cmd.Parameters.AddWithValue("@rawReading", reading.ReadingInDegrees)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub mReader_ReadingObserved(sender As Object, e As TemperatureDataReceivedEventArgs) Handles mReader.ReadingObserved
        Debug.Print("{0} (#{1}) {2} {3} {4}°C", e.SensorDescription, e.SensorId, e.LogDateTime, e.ReceivedDateTime, e.ReadingInDegrees)
        LogReading(e)
    End Sub
End Class