using System;
using System.CodeDom.Compiler;
using Moq;
using NUnit.Framework;
using TDDMicroExercises.TirePressureMonitoringSystem;

namespace TDDMicroExercises.TelemetrySystem.TelemetrySystem.Tests
{
    [TestFixture]

    public class TelemetryDiagnosticControlsTests
    {
        //check is connected after disconection and etc


        [Test]
        public void IsServerConnected_SuccessfullyConnectToTelemetryServer_True()
        {
            // Arrange
            var mockTelemetryClient = new Mock<ITelemetryClient>();
            ITelemetryClient telemetryClient = new TelemetryClient();

            mockTelemetryClient.Setup(m => m.ConnectToServer(It.IsNotNull<string>()))
                .Callback(() => telemetryClient.IsServerConnected = true);

            // Act
            mockTelemetryClient.Object.ConnectToServer("testConnectionString");

            // Assert
            Assert.True(telemetryClient.IsServerConnected);
        }

        [Test]
        public void IsServerConnected_SuccessfullyDisconnectAfterConnectingToTelemetryServer_False()
        {
            // Arrange
            var mockTelemetryClient = new Mock<ITelemetryClient>();
            ITelemetryClient telemetryClient = new TelemetryClient();

            mockTelemetryClient.Setup(m => m.ConnectToServer(It.IsAny<string>()))
                .Callback((string connectionString) => telemetryClient.IsServerConnected = true);

            mockTelemetryClient.Setup(m => m.DisconnectServer())
                .Callback(() => telemetryClient.IsServerConnected = false);

            // Act
            mockTelemetryClient.Object.ConnectToServer("testConnectionString");
            mockTelemetryClient.Object.DisconnectServer();

            // Assert
            Assert.False(telemetryClient.IsServerConnected);
        }

        [Test]
        public void SendMessage_PassNullAsArgument_ThrowsArgumentNullException()
        {
            // Arrange
            ITelemetryClient telemetryClient = new TelemetryClient();

            // Act And Assert
            Assert.Throws<ArgumentNullException>(() => telemetryClient.SendMessage(null));
        }

        [Test]
        public void SendMessage_PassEmptyStringAsArgument_ThrowsArgumentNullException()
        {
            // Arrange
            ITelemetryClient telemetryClient = new TelemetryClient();

            // Act And Assert
            Assert.Throws<ArgumentNullException>(() => telemetryClient.SendMessage(string.Empty));
        }

        [Test]
        public void ReceiveResponse_IsDiagnosticSentTrue_ReturnsGenericMessage()
        {
            // Arrange
            var diagnosticMessage = "AT#UD";
            var telemetryClient = new TelemetryClient();

            // Act
            telemetryClient.SendMessage(diagnosticMessage);
            var serverResponse = telemetryClient.ReceiveResponse();

            // Assert
            Assert.AreEqual(serverResponse, TelemeryClientConsts.GenericDiagnosticMessage);
        }
    }
}