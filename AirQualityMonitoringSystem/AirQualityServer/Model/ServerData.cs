using Newtonsoft.Json;

namespace AirQualityServer.Model
{
    internal sealed class ServerData
    {
        #region Properties
        [JsonProperty]
        public string Host { get; private set; }
        [JsonProperty]
        public int Port { get; private set; }
        #endregion
    }
}