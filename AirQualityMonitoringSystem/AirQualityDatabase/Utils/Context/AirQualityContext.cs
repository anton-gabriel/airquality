using AirQualityDatabase.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace AirQualityDatabase.Utils.Context
{
    internal sealed class AirQualityContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //read from file
            optionsBuilder.UseNpgsql("Host=my_host;Database=my_db;Username=my_user;Password=my_pw");
        }

        #region Properties
        public DbSet<Altitude> Altitudes { get; set; }
        public DbSet<Co2> Co2s { get; set; }
        public DbSet<Gas> GasValues { get; set; }
        public DbSet<Humidity> Humidities { get; set; }
        public DbSet<Pressure> Pressures { get; set; }
        public DbSet<Temperature> Temperatures { get; set; }
        public DbSet<Tvoc> Tvocs { get; set; }
        #endregion
    }
}