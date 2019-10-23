using Generated;
using Grpc.Core;
using System;
using System.Threading.Tasks;

namespace Client
{
    internal sealed class Program
    {
        static void Main(string[] args)
        {
            const string Host = "localhost";
            const int Port = 50051;

            var channel = new Channel($"{Host}:{Port}", ChannelCredentials.Insecure);
            var client = new SensorAirQualityService.SensorAirQualityServiceClient(channel);

            var request = new SensorAirQualityRequest
            {
                AirFeature = AirFeatureType.ECo2,
                Value = 10.0
            };

            Console.WriteLine("Client sending request");
            using (var response = client.SendAirFeatureAsync(request))
            {
                Console.WriteLine("Client received response: ");
                Console.WriteLine(response.ResponseAsync.Result);
            }


            // Shutdown
            channel.ShutdownAsync().Wait();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}