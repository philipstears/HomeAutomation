Imports System.IO.Ports
Imports System.Threading

Public Class RelayController
    Private Const MIN_RESPONSE_LENGTH_SET_SINGLE_PORT As Integer = 4
    Private Const MIN_RESPONSE_LENGTH_SET_ALL_PORTS As Integer = 4
    Private Const MIN_RESPONSE_LENGTH_SET_MANY_PORTS As Integer = 4
    Private Const MIN_COMMAND_DELAY_MS = 5

    Private mPort As SerialPort
    Private mThrottle As New Throttle(TimeSpan.FromMilliseconds(MIN_COMMAND_DELAY_MS))

    Public Shared Function Open(ByVal portNumber As Integer) As RelayController
        Return New RelayController(GetPort(portNumber))
    End Function

    Private Shared Function GetPort(ByVal portNumber As Integer) As SerialPort
        Dim port = New SerialPort("COM" & portNumber.ToString(), 9600, Parity.None)
        port.Open()
        Return port
    End Function

    Public Sub New(ByVal port As SerialPort)
        mPort = port
    End Sub

    Public Sub SetRelays(ByVal relays As RelayOption, ByVal status As RelayStatus)
        mThrottle.WaitUntilReady()

        ' Set all the relays at once?
        If relays = RelayOption.All Then
            SetAllRelays(status)
            Return
        End If

        ' Only got a single relay to set?
        Dim singleRelayIndex = RelayOptionHelper.ToIndex(relays)
        Dim isSingleOptionSet = RelayOptionHelper.FromIndex(singleRelayIndex) = relays

        If isSingleOptionSet Then
            SetSingleRelay(singleRelayIndex, status)
            Return
        End If

        ' Got at least two relays to set, set as a batch
        SetMultipleRelays(relays, status)
        Return
    End Sub

    Private Sub SetMultipleRelays(ByVal relays As RelayOption, ByVal status As RelayStatus)

        ' Need to get the existing status to start with
        Dim current = Me.GetStatus()

        ' Combine with the incoming relay status
        If status = RelayStatus.On Then
            relays = current Or relays
        Else
            relays = current And Not relays
        End If

        ' Get the bit pattern that controls which relays to drive
        Dim relaysBytes = BitConverter.GetBytes(CUShort(relays))

        ' The order of bits expected by the relay board is the opposite of what we'd expect, so flip the bytes
        relaysBytes(0) = BitHelper.Flip(relaysBytes(0))
        relaysBytes(1) = BitHelper.Flip(relaysBytes(1))

        ' Write the command to flip the states
        mPort.Write("x")
        mPort.Write(relaysBytes, 0, 2)
        mPort.Write("//")

        ' Read the response
        ReadResponse(MIN_RESPONSE_LENGTH_SET_MANY_PORTS)
    End Sub

    Private Sub SetAllRelays(ByVal status As RelayStatus)

        ' Send the command
        Dim commandPart = If(status = RelayStatus.On, "on//", "off//")
        mPort.Write(commandPart)

        ' Read the response
        ReadResponse(MIN_RESPONSE_LENGTH_SET_ALL_PORTS)
    End Sub

    Private Sub SetSingleRelay(ByVal index As Integer, ByVal status As RelayStatus)

        ' Build the command
        Dim portPart = (index + 1).ToString("00")
        Dim commandPart = If(status = RelayStatus.On, "+//", "-//")

        ' Send it
        mPort.Write(portPart & commandPart)

        ' Read the response
        ReadResponse(MIN_RESPONSE_LENGTH_SET_SINGLE_PORT)
    End Sub

    Public Function GetStatus() As RelayOption
        mThrottle.WaitUntilReady()

        mPort.Write("ask//")

        ' Read the status bytes
        Dim data = ReadResponse(2)

        ' The order of bits expected by the relay board is the opposite of what we'd expect, so flip the bytes
        data(0) = BitHelper.Flip(data(0))
        data(1) = BitHelper.Flip(data(1))

        Return DirectCast(CInt(BitConverter.ToUInt16(data, 0)), RelayOption)
    End Function

    Private Function ReadResponse(ByVal minLength As Integer) As Byte()

        ' Read the response
        While mPort.BytesToRead < minLength
            Thread.Yield()
        End While

        Dim length As Integer = mPort.BytesToRead
        Dim data(0 To length) As Byte

        mPort.Read(data, 0, length)

        Return data
    End Function
End Class