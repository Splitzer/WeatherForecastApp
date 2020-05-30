using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecastApp.Endpoints;
using WeatherForecastApp.Models;

namespace WeatherForecastApp.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherEndpoint _weatherEndpoint;

        public WeatherService(IWeatherEndpoint weatherEndpoint)
        {
            _weatherEndpoint = weatherEndpoint;
        }

        public async Task<IEnumerable<WeatherForecastViewModel>> GetWeather(string areaName)
        {
            var areaInformation = await _weatherEndpoint.GetAreaInformation(areaName);

            var weatherResponse = await _weatherEndpoint.GetWeatherForecast(areaInformation.Woeid);

            return weatherResponse.ConsolidatedWeather
                .Select(weather => new WeatherForecastViewModel(weather));
        }
    }
}
