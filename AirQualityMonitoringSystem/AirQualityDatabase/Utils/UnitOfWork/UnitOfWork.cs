using AirQualityDatabase.Utils.Context;
using AirQualityDatabase.Utils.Repository;

namespace AirQualityDatabase.Utils.UnitOfWork
{
    internal sealed class UnitOfWork : IUnitOfWork
    {

        #region Constructors
        public UnitOfWork(AirQualityContext context)
        {
            this.context = context ?? throw new System.ArgumentNullException(nameof(context));
            AltitudeRepository = new AltitudeRepository(context);
            Co2Repository = new Co2Repository(context);
            GasRepository = new GasRepository(context);
            HumidityRepository = new HumidityRepository(context);
            PressureRepository = new PressureRepository(context);
            TemperatureRepository = new TemperatureRepository(context);
            TvocRepository = new TvocRepository(context);
        }
        #endregion

        #region Private fields
        private readonly AirQualityContext context;
        #endregion

        #region Properties
        public IAltitudeRepository AltitudeRepository { get; private set; }

        public ICo2Repository Co2Repository { get; private set; }

        public IGasRepository GasRepository { get; private set; }

        public IHumidityRepository HumidityRepository { get; private set; }

        public IPressureRepository PressureRepository { get; private set; }

        public ITemperatureRepository TemperatureRepository { get; private set; }

        public ITvocRepository TvocRepository { get; private set; }
        #endregion

        #region IUnitOfWork
        public int Complete()
        {
            return this.context.SaveChanges();
        }
        public void Dispose()
        {
            this.context.Dispose();
        }
        #endregion
    }
}