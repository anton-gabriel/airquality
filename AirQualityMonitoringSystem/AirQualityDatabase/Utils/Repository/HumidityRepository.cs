using AirQualityDatabase.Model.Entity;
using AirQualityDatabase.Utils.Context;
using AirQualityDatabase.Utils.Repository.Base;

namespace AirQualityDatabase.Utils.Repository
{
    internal sealed class HumidityRepository : Repository<Humidity>, IHumidityRepository
    {
        #region Constructors
        public HumidityRepository(AirQualityContext context) :
            base(context)
        {

        }
        #endregion

        #region Properties
        public AirQualityContext AirQualityContext => Context as AirQualityContext;
        #endregion

        #region IHumidityRepository

        #endregion
    }
}