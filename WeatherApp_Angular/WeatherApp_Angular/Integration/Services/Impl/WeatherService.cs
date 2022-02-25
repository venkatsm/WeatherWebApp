using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp_Angular.Integration.Clients;
using WeatherApp_Angular.Integration.Dtos;

namespace WeatherApp_Angular.Integration.Services.Impl
{
    public class WeatherService : IWeatherService
    {
        private const string ExceptionMessage = "Weather API call did not succeed.";

        private readonly IWeatherClient _weatherClient;

        public WeatherService(IWeatherClient weatherClient)
        {
            _weatherClient = weatherClient;
        }

        public async Task<WeatherServiceResponseDto> GetWeather(string region)
        {
            try
            {
                return await _weatherClient.GetWeather(region);
            }
            catch (Exception)
            {
                throw new Exception(ExceptionMessage);
            }
        }
    }
}
