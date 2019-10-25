using AirQualityServer.Utils.Messages;
using Generated;
using Grpc.Core;
using NLog;
using System.Threading.Tasks;

using Status = Generated.RequestStatus;

namespace AirQualityServer.Services
{
    internal sealed class SensorAirQualityService : Generated.SensorAirQualityService.SensorAirQualityServiceBase
    {
        #region Logger
        private static Logger Logger { get; } = LogManager.GetCurrentClassLogger();
        #endregion

        #region SensorAirQualityServiceBase
        public override Task<SensorAirQualityResponse> SendAirFeature(SensorAirQualityRequest request, ServerCallContext context)
        {
            Logger.Info(LoggerMessages.ServiceRequestMessage(service: nameof(SendAirFeature), host: context.Host, peer: context.Peer));
            //Call to the Sensor Interpreter - that decide to call or not the FirebaseNotifier
            //
            return Task.FromResult(new SensorAirQualityResponse() { Status = Status.Resolved });
        }

        public override async Task SendAirFeatures(IAsyncStreamReader<SensorAirQualityRequest> requestStream, IServerStreamWriter<SensorAirQualityResponse> responseStream, ServerCallContext context)
        {
            Logger.Info(LoggerMessages.ServiceRequestMessage(service: nameof(SendAirFeatures), host: context.Host, peer: context.Peer, requestStream));
            while (await requestStream.MoveNext())
            {
                var request = requestStream.Current;
                //Call to the Sensor Interpreter - that decide to call or not the FirebaseNotifier
                //
                await responseStream.WriteAsync(new SensorAirQualityResponse() { Status = Status.Resolved });
            }
        }
        #endregion
    }
}