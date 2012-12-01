''' <summary>
''' Represents a radiator.
''' </summary>
''' <remarks></remarks>
Public Interface IRadiator

    ''' <summary>
    ''' Determines whether the radiator is currently turned on.
    ''' </summary>
    ReadOnly Property IsOn() As Boolean

    ''' <summary>
    ''' Switches the radiator on.
    ''' </summary>
    ''' <remarks></remarks>
    Sub EnsureOn()

    ''' <summary>
    ''' Switches the radiator off.
    ''' </summary>
    ''' <remarks></remarks>
    Sub EnsureOff()
End Interface
