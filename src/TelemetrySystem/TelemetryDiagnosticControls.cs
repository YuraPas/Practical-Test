using System;

namespace TDDMicroExercises.TelemetrySystem
{
    public class TelemetryDiagnosticControls
    {
        private const string DiagnosticChannelConnectionString = "*111#";
        
        private readonly ITelemetryClient _telemetryClient;

        public TelemetryDiagnosticControls()
        {
            _telemetryClient = new TelemetryClient();
        }

        public string DiagnosticInfo { get; set; } = string.Empty;

        public void ProcessServerMessageTransmission()
        {
            try
            {
                using (_telemetryClient)
                {
                    while (_telemetryClient.IsServerConnected == false)
                    {
                        _telemetryClient.ConnectToServer(DiagnosticChannelConnectionString);
                    }

                    _telemetryClient.SendMessage(TelemetryClient.DiagnosticMessage);
                    DiagnosticInfo = _telemetryClient.ReceiveResponse();
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            catch (Exception)
            {
                Console.WriteLine("Unexpected internal error occured");
                throw;
            }
        }
    }
}
