using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecastApp.Models;
using WeatherForecastApp.Services;

namespace WeatherForecastApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherService _weatherService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet("{areaName}")]
        public async Task<IEnumerable<WeatherForecastViewModel>> Get(string areaName)
        {
            _logger.LogInformation("Weather call initiated");

            var weatherRows = await _weatherService.GetWeather(areaName);

            _logger.LogInformation("Weather call completed {weatherCount}", weatherRows?.Count());

            return weatherRows;
        }
    }
}
