using AirQualityServer.Utils.Messages;
using Generated;
using Grpc.Core;
using NLog;
using System.Threading.Tasks;

using Status = Generated.RequestStatus;

namespace AirQualityServer.Services
{
    internal sealed class SensorEnvironmentService : Generated.SensorEnvironmentService.SensorEnvironmentServiceBase
    {
        #region Logger
        private static Logger Logger { get; } = LogManager.GetCurrentClassLogger();
        #endregion

        #region SensorEnvironmentServiceBase
        public override Task<SensorEnvironmentResponse> SendEnvironmentFeature(SensorEnvironmentRequest request, ServerCallContext context)
        {
            Logger.Info(LoggerMessages.ServiceRequestMessage(service: nameof(SendEnvironmentFeature), host: context.Host, peer: context.Peer));
            //Call to the Sensor Interpreter - that decide to call or not the FirebaseNotifier
            //
            return Task.FromResult(new SensorEnvironmentResponse() { Status = Status.Resolved });
        }

        public override async Task SendEnvironmentFeatures(IAsyncStreamReader<SensorEnvironmentRequest> requestStream, IServerStreamWriter<SensorEnvironmentResponse> responseStream, ServerCallContext context)
        {
            Logger.Info(LoggerMessages.ServiceRequestMessage(service: nameof(SendEnvironmentFeatures), host: context.Host, peer: context.Peer, requestStream));
            while (await requestStream.MoveNext())
            {
                var request = requestStream.Current;
                //Call to the Sensor Interpreter - that decide to call or not the FirebaseNotifier
                //
                await responseStream.WriteAsync(new SensorEnvironmentResponse() { Status = Status.Resolved });
            }
        }
        #endregion
    }
}