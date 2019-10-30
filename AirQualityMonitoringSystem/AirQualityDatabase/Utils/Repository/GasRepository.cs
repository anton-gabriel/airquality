using AirQualityDatabase.Model.Entity;
using AirQualityDatabase.Utils.Context;
using AirQualityDatabase.Utils.Repository.Base;

namespace AirQualityDatabase.Utils.Repository
{
    internal sealed class GasRepository : Repository<Gas>, IGasRepository
    {
        #region Constructors
        public GasRepository(AirQualityContext context) :
            base(context)
        {

        }
        #endregion

        #region Properties
        public AirQualityContext AirQualityContext => Context as AirQualityContext;
        #endregion

        #region IGasRepository

        #endregion
    }
}