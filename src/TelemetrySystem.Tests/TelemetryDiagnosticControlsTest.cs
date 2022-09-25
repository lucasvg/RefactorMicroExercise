using System;
using Moq;
using NUnit.Framework;

namespace TDDMicroExercises.TelemetrySystem.Tests
{
    [TestFixture]
    public class TelemetryDiagnosticControlsTest
    {
        class SuccessfulTelemetryClientStub : ITelemetryClient
        {
            public bool OnlineStatus                                    { get; private set; }
            public void Connect(string telemetryServerConnectionString) => OnlineStatus = true;

            public void Disconnect() => OnlineStatus = false;

            public void Send(string message) { MessageSent = message; }

            public string MessageSent { get; set; }

            public string Receive() => MessageReceived;

            public string MessageReceived = "message received!";
        }
        
        [Test]
        public void CheckTransmissionShouldSendADiagnosticMessageAndReceiveAStatusMessageResponse()
        {
            var successfulTelemetryClientStub = new SuccessfulTelemetryClientStub();
            var telemetryDiagnosticControls   = new TelemetryDiagnosticControls(successfulTelemetryClientStub);
            telemetryDiagnosticControls.CheckTransmission();
            Assert.IsTrue(successfulTelemetryClientStub.OnlineStatus);
            Assert.AreEqual(successfulTelemetryClientStub.MessageSent, TelemetryDiagnosticControls.DiagnosticChannelConnectionString);
            Assert.AreEqual(successfulTelemetryClientStub.MessageReceived, telemetryDiagnosticControls.DiagnosticInfo);
        }
        
        [Test]
        public void CheckTransmissionFailedWhenClientFailed()
        {
            var mock                          = new Mock<ITelemetryClient>();
            var telemetryDiagnosticControls   = new TelemetryDiagnosticControls(mock.Object);
            Assert.Throws<Exception>(() => telemetryDiagnosticControls.CheckTransmission());
        }
    }
}
