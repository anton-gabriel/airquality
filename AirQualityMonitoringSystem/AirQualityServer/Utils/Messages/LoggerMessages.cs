using System.Linq;

namespace AirQualityServer.Utils.Messages
{
    internal static class LoggerMessages
    {
        public static string ServiceRequestMessage(string service, string host, string peer)
        {
            return $"New request from {peer}, at host {host} for service: {service}.";
        }

        public static string ServiceRequestMessage(string service, string host, string peer, params object[] requestObjects)
        {
            string GetObjectStatus(object data) => data != null ? "Ok" : "Null";
            return $"New request from {peer}, at host {host} for service {service}, with objects: " +
                  requestObjects.Select(@object => $"{@object.GetType().Name}: Status: {GetObjectStatus(@object)}")
                 .ToList()
                 .Aggregate((first, second) => $"{first}, {second}");
        }

        public static string ServerClosedMessage(string host)
        {
            return $"Server closed (hots: {host}).";
        }

        public static string ServerStartedMessage(string host)
        {
            return $"Server started (hots: {host}).";
        }
    }
}