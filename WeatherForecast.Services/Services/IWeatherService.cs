using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherForecastApp.Models;

namespace WeatherForecastApp.Services
{
    public interface IWeatherService
    {
        Task<IEnumerable<WeatherForecastViewModel>> GetWeather(string areaName);
    }
}