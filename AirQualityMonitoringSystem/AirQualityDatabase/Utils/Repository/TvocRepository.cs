using AirQualityDatabase.Model.Entity;
using AirQualityDatabase.Utils.Context;
using AirQualityDatabase.Utils.Repository.Base;

namespace AirQualityDatabase.Utils.Repository
{
    internal sealed class TvocRepository : Repository<Tvoc>, ITvocRepository
    {
        #region Constructors
        public TvocRepository(AirQualityContext context) :
            base(context)
        {

        }
        #endregion

        #region Properties
        public AirQualityContext AirQualityContext => Context as AirQualityContext;
        #endregion

        #region ITvocRepository

        #endregion
    }
}