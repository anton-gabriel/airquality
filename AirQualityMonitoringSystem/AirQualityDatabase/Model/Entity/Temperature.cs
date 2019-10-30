using System;

namespace AirQualityDatabase.Model.Entity
{
    internal sealed class Temperature
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
    }
}