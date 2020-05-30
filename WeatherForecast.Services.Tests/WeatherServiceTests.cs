using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherForecast.Services.Endpoints.Responses;
using WeatherForecastApp.Endpoints;
using WeatherForecastApp.Endpoints.Responses;
using WeatherForecastApp.Services;
using Xunit;

namespace WeatherForecast.Services.Tests
{
    public class WeatherServiceTests
    {
        private readonly Mock<IWeatherEndpoint> _mockWeatherEndpoint;
        private readonly WeatherForecastResponse _dummyWeatherResponse;
        private readonly AreaInformation _dummyAreaInformation;

        public WeatherServiceTests()
        {
            _mockWeatherEndpoint = new Mock<IWeatherEndpoint>();

            _dummyWeatherResponse = new WeatherForecastResponse
            {
                ConsolidatedWeather = new List<Weather>
                {
                    new Weather
                    {
                        WeatherStateName = "Dummy WeatherStateName",
                        ApplicableDate = "2020-05-30",
                        WeatherStateAbbr = "Dummy WeatherStateAbbr"
                    }
                }
            };

            _dummyAreaInformation = new AreaInformation
            {
                Title = "Dummy Title",
                Woeid = 1,
                LattLong = "Dummy LattLong",
                LocationType = "Dummy LocationType"
            };
        }

        [Fact]
        public async Task GetWeather_Success()
        {
            //ASSEMBLE
            _mockWeatherEndpoint.Setup(x => x.GetAreaInformation(It.IsAny<string>()))
                .Returns(Task.FromResult(_dummyAreaInformation));
            _mockWeatherEndpoint.Setup(x => x.GetWeatherForecast(It.IsAny<int>()))
                .Returns(Task.FromResult(_dummyWeatherResponse));

            var service = new WeatherService(_mockWeatherEndpoint.Object);

            //ACTION
            var result = await service.GetWeather("Belfast");

            //ASSERT
            Assert.NotNull(result);
            Assert.Single(result);
        }
    }
}
