using AirQualityDatabase.Model.Entity;
using AirQualityDatabase.Utils.Context;
using AirQualityDatabase.Utils.Repository.Base;


namespace AirQualityDatabase.Utils.Repository
{
    internal sealed class AltitudeRepository : Repository<Altitude>, IAltitudeRepository
    {
        #region Constructors
        public AltitudeRepository(AirQualityContext context) :
            base(context)
        {

        }
        #endregion

        #region Properties
        public AirQualityContext AirQualityContext => Context as AirQualityContext;
        #endregion

        #region IAltitudeRepository

        #endregion
    }
}