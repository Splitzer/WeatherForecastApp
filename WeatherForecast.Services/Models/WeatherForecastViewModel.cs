using System;
using WeatherForecastApp.Endpoints.Responses;

namespace WeatherForecastApp.Models
{
    public class WeatherForecastViewModel
    {
        public WeatherForecastViewModel() { }

        public WeatherForecastViewModel(Weather weather)
        {
            State = weather.WeatherStateName;
            Date = DateTime.Parse(weather.ApplicableDate).ToString("dd/MM/yyyy");
            ImageUrlSuffix = weather.WeatherStateAbbr;
        }

        public string State { get; set; }
        public string Date { get; set; }
        public string ImageUrlSuffix { get; set; }
    }
}
