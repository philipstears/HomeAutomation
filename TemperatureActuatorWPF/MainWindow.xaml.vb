Imports TemperatureDataCore
Imports System.Collections.ObjectModel
Imports RadiatorController

Class MainWindow
    Private mRadiatorManager As New FakeRadiatorManager()
    Private mActuatorModel As New ActuatorModel(mRadiatorManager)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
    End Sub

    Public ReadOnly Property Model As ActuatorModel
        Get
            Return mActuatorModel
        End Get
    End Property
End Class
