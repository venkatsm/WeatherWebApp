using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp_Angular.Integration.Dtos;

namespace WeatherApp_Angular.Integration.Services
{
    public interface IWeatherService
    {
        public Task<WeatherServiceResponseDto> GetWeather(string region);
    }
}
