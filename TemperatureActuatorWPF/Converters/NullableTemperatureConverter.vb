Public Class NullableTemperatureConverter
    Implements IValueConverter

    Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As Globalization.CultureInfo) As Object Implements IValueConverter.Convert
        If value Is Nothing Then
            Return "<Pending>"
        End If

        Dim temperature = DirectCast(value, Double)
        Return temperature.ToString("#,##.00'°C'")
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class
