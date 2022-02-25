using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp_Angular.Dtos;
using WeatherApp_Angular.Integration.Dtos;
using WeatherApp_Angular.Integration.Services;

namespace WeatherApp_Angular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherService _weatherService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            return "Weather Service";
        }

        [HttpGet]
        [Route("by")]
        public async Task<Dtos.Response<WeatherInfo>> GetWeather(string region)
        {
            _logger.LogInformation("In Weather Controller Get");

            WeatherServiceResponseDto serviceResponse = await _weatherService.GetWeather(region);

            Dtos.Response<WeatherInfo> response = new();
            response.Success = serviceResponse.Region != null;

            if (serviceResponse.Region != null)
            {
                response.Result = new WeatherInfo()
                {
                    Region = serviceResponse.Region,
                    CurrentConditions = serviceResponse.CurrentConditions,
                    Next_Days = new List<WeatherInfoDetail>(serviceResponse
                        .Next_Days.Select(x => new WeatherInfoDetail()
                        {
                            Date = x.Day,
                            MinTemperature = $"{x.Min_Temp.C}C ({x.Min_Temp.F}F)",
                            MaxTemperature = $"{x.Max_Temp.C}C ({x.Max_Temp.F}F)",
                            Summary = x.Comment
                        }))
                };
            }

            return response;
        }
    }
}
