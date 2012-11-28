Public Class Program
    Public Shared Sub Main()
        Dim connectionString = My.Settings.Database
        Dim tableName = My.Settings.Table
        Dim reader = New TemperatureReader()
        Dim logger = New Logger(connectionString, tableName, reader)

        Application.Run(New MainForm())
    End Sub
End Class
