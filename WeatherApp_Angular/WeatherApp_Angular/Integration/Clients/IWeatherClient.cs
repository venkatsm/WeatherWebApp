using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp_Angular.Integration.Dtos;

namespace WeatherApp_Angular.Integration.Clients
{
    public interface IWeatherClient
    {
        [Get("/data/weather/{region}")]
        Task<WeatherServiceResponseDto> GetWeather([Body] string region);
    }
}
