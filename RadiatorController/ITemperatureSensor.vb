''' <summary>
''' Represents a temperature sensor.
''' </summary>
''' <remarks></remarks>
Public Interface ITemperatureSensor

    ''' <summary>
    ''' Gets the current reading from the sensor in degrees celsius.
    ''' </summary>
    ReadOnly Property Reading() As Double
End Interface
