﻿using System;

namespace AirQualityDatabase.Model.Entity
{
    internal sealed class Gas
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; }
    }
}