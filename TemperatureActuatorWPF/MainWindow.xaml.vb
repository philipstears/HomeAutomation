Imports TemperatureDataCore
Imports System.Collections.ObjectModel

Class MainWindow
    Private mActuatorModel As New ActuatorModel()

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
