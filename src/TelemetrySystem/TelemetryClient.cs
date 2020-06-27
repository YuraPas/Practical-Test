using System;
using System.Text;

namespace TDDMicroExercises.TelemetrySystem
{
    public class TelemetryClient : ITelemetryClient
    {
        public bool IsServerConnected { get; set; }

        public const string DiagnosticMessage = "AT#UD";

        private bool _isDiagnosticSent;

        private readonly Random _genericSimulator;

        public TelemetryClient()
        {
            _genericSimulator = new Random();
        }

        public void ConnectToServer(string telemetryServerConnectionString)
        {
            ValidateStringParam(telemetryServerConnectionString, "TelemetryConnectionString");

            IsServerConnected = _genericSimulator.Next(1, 10) <= 2;
        }

        
        public void SendMessage(string messageToServer)
        {
            ValidateStringParam(messageToServer, "SendMessage");

             _isDiagnosticSent = messageToServer == DiagnosticMessage;
        }

        public string ReceiveResponse()
        {
            string responseMessage;

            if (_isDiagnosticSent)
            {
                responseMessage = TelemeryClientConsts.GenericDiagnosticMessage;
                _isDiagnosticSent = false;
            }
            else
            {
                responseMessage = GetResponseMessage();
            }

            return responseMessage;
        }

        public void DisconnectServer()
        {
            IsServerConnected = false;
        }

        public void Dispose()
        {
            DisconnectServer();
        }

        private void ValidateStringParam(string value, string paramName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(paramName, $"Incorrect input value for {paramName}");
            }
        }

        private string GetResponseMessage()
        {
            var messageBuilder = new StringBuilder();

            int messageLength = _genericSimulator.Next(50, 110);
            for (int i = messageLength; i > 0; --i)
            {
                messageBuilder.Append((char)_genericSimulator.Next(40, 126));
            }

            return messageBuilder.ToString();
        }
    }
}
