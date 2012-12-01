Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports RadiatorController
<TestClass()> _
Public Class TemperatureSettingsTest

    <TestMethod()>
    Public Sub EvaluateCurrentSetting_OverrideIsApplied()
        Dim settings As New TemperatureSettings()
        settings.AddSetting(New TemperatureSetting(#10:00:00 AM#, 20))
        settings.AddSetting(New TemperatureSetting(#8:00:00 PM#, 25))

        settings.Override = 10

        Dim result = settings.GetDesiredTemperature(#11:00:00 AM#)

        Assert.AreEqual(10, result)
    End Sub

    <TestMethod()>
    Public Sub EvaluateCurrentSetting_OverrideIsReset()
        Dim settings As New TemperatureSettings()
        settings.AddSetting(New TemperatureSetting(#10:00:00 AM#, 20))
        settings.AddSetting(New TemperatureSetting(#8:00:00 PM#, 25))

        settings.Override = 10

        Dim resultWithOverride = settings.GetDesiredTemperature(#11:00:00 AM#)

        Assert.AreEqual(10, resultWithOverride)

        Dim resultAfterReset = settings.GetDesiredTemperature(#8:00:00 PM#)

        Assert.AreEqual(25, resultAfterReset)
        Assert.AreEqual(Nothing, settings.Override)
    End Sub

    <TestMethod()>
    Public Sub EvaluateCurrentSetting_ReturnsCorrectResult()
        Dim settings As New TemperatureSettings()
        settings.AddSetting(New TemperatureSetting(#10:00:00 AM#, 20))
        settings.AddSetting(New TemperatureSetting(#8:00:00 PM#, 25))

        Dim result = settings.GetDesiredTemperature(#11:00:00 AM#)
        Assert.AreEqual(20, result)
    End Sub

    <TestMethod()>
    Public Sub EvaluateCurrentSetting_CanGetSettingFromPreviousDay()
        Dim settings As New TemperatureSettings()
        settings.AddSetting(New TemperatureSetting(#10:00:00 AM#, 20))
        settings.AddSetting(New TemperatureSetting(#8:00:00 PM#, 25))

        Dim result = settings.GetDesiredTemperature(#3:00:00 AM#)
        Assert.AreEqual(25, result)
    End Sub
End Class
