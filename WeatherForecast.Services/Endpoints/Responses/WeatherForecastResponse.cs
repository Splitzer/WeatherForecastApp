using System.Collections.Generic;
using WeatherForecast.Services.Endpoints.Responses;

namespace WeatherForecastApp.Endpoints.Responses
{
    public class WeatherForecastResponse
    {
        public IEnumerable<Weather> ConsolidatedWeather { get; set; }
        public string Time { get; set; }
        public string SunRise { get; set; }
        public string SunSet { get; set; }
        public string TimezoneName { get; set; }
        public AreaInformation Parent { get; set; }
        public IEnumerable<Source> Sources { get; set; }
        public string Title { get; set; }
        public string LocationType { get; set; }
        public int Woeid { get; set; }
        public string LattLong { get; set; }
        public string Timezone { get; set; }
    }

    public class Weather
    {
        public long Id { get; set; }
        public string WeatherStateName { get; set; }
        public string WeatherStateAbbr { get; set; }
        public string WindDirectionCompass { get; set; }
        public string Created { get; set; }
        public string ApplicableDate { get; set; }
        public string MinTemp { get; set; }
        public string MaxTemp { get; set; }
        public string TheTemp { get; set; }
        public string WindSpeed { get; set; }
        public string WindDirection { get; set; }
        public string AirPressure { get; set; }
        public string Humidity { get; set; }
        public string Visibility { get; set; }
        public string Predictability { get; set; }
    }

    public class Source
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Url { get; set; }
        public int CrawlRate { get; set; }
    }
}
