using System;

namespace AirQualityDatabase.Model.Entity
{
    internal sealed class Pressure
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
    }
}