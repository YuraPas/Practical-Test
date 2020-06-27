using System;

namespace TDDMicroExercises.TelemetrySystem
{
    public interface ITelemetryClient : IDisposable
    {
        bool IsServerConnected { get; set; }

        void ConnectToServer(string connectionString);

        void SendMessage(string messageToServer);

        string ReceiveResponse();

        void DisconnectServer();
    }
}
