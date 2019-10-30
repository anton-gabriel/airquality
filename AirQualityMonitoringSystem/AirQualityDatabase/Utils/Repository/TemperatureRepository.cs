using AirQualityDatabase.Model.Entity;
using AirQualityDatabase.Utils.Context;
using AirQualityDatabase.Utils.Repository.Base;

namespace AirQualityDatabase.Utils.Repository
{
    internal sealed class TemperatureRepository : Repository<Temperature>, ITemperatureRepository
    {
        #region Constructors
        public TemperatureRepository(AirQualityContext context) :
            base(context)
        {

        }
        #endregion

        #region Properties
        public AirQualityContext AirQualityContext => Context as AirQualityContext;
        #endregion

        #region ITemperatureRepository

        #endregion
    }
}