using AirQualityServer.Utils.Configuration;
using System;

namespace AirQualityServer
{
    internal sealed class Program
    {
        static void Main(string[] args)
        {
            using (Server server = new Server(Configuration.Instance.ServerData))
            {
                server.CloseServerAction = () => Console.ReadKey();
                server.Start();
            }
        }
    }
}