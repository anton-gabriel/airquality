using System;
using System.Collections.Generic;
using System.Text;
using Generated;

namespace AirQualityServer.Actions
{
    internal sealed class SensorInterpreter
    {
        #region Constructor
        public SensorInterpreter()
        {
          ///  FirebaseNotifier = new FirebaseNotifier("read from file configuration");
        }
        #endregion

        #region Private fields

        #endregion

        #region Properties
        public FirebaseNotifier FirebaseNotifier { get; private set; }
        #endregion

        #region Public methods
        public bool InterpretAirQualityData(SensorAirQualityRequest data)
        {
            switch (data.AirFeature)
            {
                case AirFeatureType.InvalidAirFeature:
                    break;
                case AirFeatureType.ECo2:
                    break;
                case AirFeatureType.Tvoc:
                    break;
                default:
                    break;
            }

            return default;
        }

        public bool InterpretEnvironmentData(SensorEnvironmentRequest data)
        {
            switch (data.EnvironmentFeature)
            {
                case EnvironmentFeatureType.InvalidEnvironmentFeature:
                    break;
                case EnvironmentFeatureType.Temperature:
                    break;
                case EnvironmentFeatureType.Gas:
                    break;
                case EnvironmentFeatureType.Humidity:
                    break;
                case EnvironmentFeatureType.Pressure:
                    break;
                case EnvironmentFeatureType.Altitude:
                    break;
                default:
                    break;
            }

            return default;
        }
        #endregion
    }
}
