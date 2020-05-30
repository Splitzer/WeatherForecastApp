using System.Threading.Tasks;
using WeatherForecast.Services.Endpoints.Responses;
using WeatherForecastApp.Endpoints.Responses;

namespace WeatherForecastApp.Endpoints
{
    public interface IWeatherEndpoint
    {
        Task<WeatherForecastResponse> GetWeatherForecast(int locationCode);
        Task<AreaInformation> GetAreaInformation(string areaName);
    }
}