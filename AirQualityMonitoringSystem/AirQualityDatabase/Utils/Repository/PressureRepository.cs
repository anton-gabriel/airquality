using AirQualityDatabase.Model.Entity;
using AirQualityDatabase.Utils.Context;
using AirQualityDatabase.Utils.Repository.Base;

namespace AirQualityDatabase.Utils.Repository
{
    internal sealed class PressureRepository : Repository<Pressure>, IPressureRepository
    {
        #region Constructors
        public PressureRepository(AirQualityContext context) :
            base(context)
        {

        }
        #endregion

        #region Properties
        public AirQualityContext AirQualityContext => Context as AirQualityContext;
        #endregion

        #region IPressureRepository

        #endregion
    }
}