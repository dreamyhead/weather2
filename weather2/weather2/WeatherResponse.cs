using System;
using System.Collections.Generic;
using System.Text;

namespace weather2
{
    public class WeatherResponse
    {
        public TemperatureInfo Main { get; set; }
        public string Name { get; set; }
        public float Visibility { get; set; }
    }
}
