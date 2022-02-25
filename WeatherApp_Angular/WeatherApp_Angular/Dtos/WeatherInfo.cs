using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp_Angular.Integration.Dtos;

namespace WeatherApp_Angular.Dtos
{
    public class WeatherInfo
    {
        public string Region { get; set; }
        public Currentconditions CurrentConditions { get; set; }
        public List<WeatherInfoDetail> Next_Days { get; set; }
    }

    public class WeatherInfoDetail
    {
        public string Date { get; set; }
        public string MinTemperature { get; set; }
        public string MaxTemperature { get; set; }
        public string Summary { get; set; }
    }
}
