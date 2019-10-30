using System;

namespace AirQualityDatabase.Model.Entity
{
    internal sealed class Tvoc
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; }
    }
}