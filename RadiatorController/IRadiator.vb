''' <summary>
''' Represents a radiator.
''' </summary>
''' <remarks></remarks>
Public Interface IRadiator

    ''' <summary>
    ''' Raised when the value of the <see cref="IsOn" /> property changes.
    ''' </summary>
    ''' <remarks></remarks>
    Event IsOnChanged As EventHandler

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
