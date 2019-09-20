using AirQualityServer.Model;
using AirQualityServer.Utils.Constants;
using AirQualityServer.Utils.Readers;
using NLog;

namespace AirQualityServer.Utils.Configuration
{
    internal sealed class Configuration
    {

        #region Constructors
        public Configuration()
        {
            ServerData = LoadServerData();
            ConfigLogger();
        }
        #endregion

        #region Private fields

        #region Singleton fields
        private static Configuration instance = null;
        private static readonly object padlock = new object();
        #endregion

        #endregion

        #region Properties

        #region Singleton properties
        public static Configuration Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Configuration();
                    }
                    return instance;
                }
            }
        }
        #endregion

        public ServerData ServerData { get; private set; }
        #endregion

        #region Private methods
        private ServerData LoadServerData()
        {
            return JsonReader<ServerData>.TryReadObject(Paths.ConfigFile);
        }

        private static void ConfigLogger()
        {
            var config = new NLog.Config.LoggingConfiguration();
            var logfile = new NLog.Targets.FileTarget()
            {
                FileName = Paths.LoggingFile
            };
            var logconsole = new NLog.Targets.ConsoleTarget();

            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            LogManager.Configuration = config;
        }
        #endregion
    }
}