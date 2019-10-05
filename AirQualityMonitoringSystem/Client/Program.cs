using Generated;
using Grpc.Core;
using System;
using System.Threading.Tasks;

namespace Client
{
    internal sealed class Program
    {
        static async Task Main(string[] args)
        {
            const string Host = "localhost";
            const int Port = 50051;

            var channel = new Channel($"{Host}:{Port}", ChannelCredentials.Insecure);
            var client = new AirQualityService.AirQualityServiceClient(channel);

            var request = new AirQualityRequest
            {
                AirFeature = AirFeatureType.Humidity
            };

            Console.WriteLine("Client sending request");
            using (var response = client.GetAirQualityAsync(request))
            {
                Console.WriteLine("Client received response: ");
                Console.WriteLine(response.ResponseAsync.Result);
            }

            using (var call = client.GetAirFeatures())
            {
                var responseReaderTask = Task.Run(async () =>
                {
                    while (await call.ResponseStream.MoveNext())
                    {
                        var res = call.ResponseStream.Current;
                        Console.WriteLine("Received " + res);
                    }
                });

                while (Console.ReadLine() != "stop")
                {
                    Enum.TryParse(Console.ReadLine(), out AirFeatureType featureType);
                    await call.RequestStream.WriteAsync(new AirQualityRequest() { AirFeature = AirFeatureType.Co });
                }
                await call.RequestStream.CompleteAsync();
                await responseReaderTask;
            }



            // Shutdown
            channel.ShutdownAsync().Wait();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}