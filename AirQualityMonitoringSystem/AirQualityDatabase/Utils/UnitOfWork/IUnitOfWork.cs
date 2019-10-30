using AirQualityDatabase.Utils.Repository;
using System;

namespace AirQualityDatabase.Utils.UnitOfWork
{
    internal interface IUnitOfWork : IDisposable
    {
        #region Repositories
        IAltitudeRepository AltitudeRepository { get; }
        ICo2Repository Co2Repository { get; }
        IGasRepository GasRepository { get; }
        IHumidityRepository HumidityRepository { get; }
        IPressureRepository PressureRepository { get; }
        ITemperatureRepository TemperatureRepository { get; }
        ITvocRepository TvocRepository { get; }
        #endregion

        int Complete();
    }
}