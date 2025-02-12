
using System;

namespace TDDMicroExercises.TelemetrySystem
{
    public class TelemetryDiagnosticControls
    {
        public const string DiagnosticChannelConnectionString = "*111#";

        readonly ITelemetryClient _telemetryClient;

        public TelemetryDiagnosticControls(ITelemetryClient telemetryClient)
        {
            _telemetryClient = telemetryClient;
            DiagnosticInfo   = string.Empty;
        }

        public string DiagnosticInfo { get; private set; }

        public void CheckTransmission()
        {
            DiagnosticInfo = string.Empty;
            _telemetryClient.Disconnect();
            var retryLeft = 3;
            while (_telemetryClient.OnlineStatus == false && retryLeft > 0)
            {
                _telemetryClient.Connect(DiagnosticChannelConnectionString);
                retryLeft -= 1;
            }
             
            if(_telemetryClient.OnlineStatus == false)
                throw new Exception("Unable to connect.");

            _telemetryClient.Send(TelemetryClient.DiagnosticMessage);
            DiagnosticInfo = _telemetryClient.Receive();
            _telemetryClient.Disconnect();
        }
    }
}
