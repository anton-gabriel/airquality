using AirQualityServer.Utils.Messages;
using Generated;
using Grpc.Core;
using NLog;
using System.Threading.Tasks;

namespace AirQualityServer.Services
{
    internal sealed class AirQualityService : Generated.AirQualityService.AirQualityServiceBase
    {
        #region Logger
        private static Logger Logger { get; } = LogManager.GetCurrentClassLogger();
        #endregion

        #region AirQualityServiceBase
        public override Task<AirQualityResponse> GetAirQuality(AirQualityRequest request, ServerCallContext context)
        {
            Logger.Info(LoggerMessages.ServiceRequestMessage(service: nameof(GetAirQuality), host: context.Host, peer: context.Peer));
            return Task.FromResult(new AirQualityResponse() { Quality = 1.0, AirFeature = request.AirFeature });
        }

        public override async Task GetAirFeatures(IAsyncStreamReader<AirQualityRequest> requestStream, IServerStreamWriter<AirQualityResponse> responseStream, ServerCallContext context)
        {
            Logger.Info(LoggerMessages.ServiceRequestMessage(service: nameof(GetAirFeatures), host: context.Host, peer: context.Peer, requestStream));
            while (await requestStream.MoveNext())
            {
                var request = requestStream.Current;
                await responseStream.WriteAsync(new AirQualityResponse() { AirFeature = request.AirFeature, Quality = 8.9 });
            }
        }
        #endregion
    }
}