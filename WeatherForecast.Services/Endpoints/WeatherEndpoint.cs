using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WeatherForecast.Services.Endpoints.Responses;
using WeatherForecastApp.Endpoints.Responses;
using WeatherForecastApp.Tools;

namespace WeatherForecastApp.Endpoints
{
    public class WeatherEndpoint : IWeatherEndpoint
    {
        private readonly string _apiUrl = "https://www.metaweather.com/api";

        public async Task<AreaInformation> GetAreaInformation(string areaName)
        {
            var requestUrl = $"{_apiUrl}/location/search/?query={areaName.ToLower()}";
            var httpMessage = new HttpRequestMessage(HttpMethod.Get, requestUrl);

            var responseContent = await HandleHttpCall(httpMessage);

            var areaInformations = JsonHelper.ParseJson<IEnumerable<AreaInformation>>(responseContent);

            return areaInformations.Single();
        }

        public async Task<WeatherForecastResponse> GetWeatherForecast(int locationCode)
        {
            var requestUrl = $"{_apiUrl}/location/{locationCode}/";
            var httpMessage = new HttpRequestMessage(HttpMethod.Get, requestUrl);

            var responseContent = await HandleHttpCall(httpMessage);

            return JsonHelper.ParseJson<WeatherForecastResponse>(responseContent);
        }


        private async Task<string> HandleHttpCall(HttpRequestMessage httpMessage)
        {
            using (var cts = new CancellationTokenSource(TimeSpan.FromMinutes(1)))
            using (var client = new HttpMessageInvoker(new HttpClientHandler()))
            {
                var httpResponse = await client.SendAsync(httpMessage, cts.Token);

                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception($"Result code is {(int)httpResponse.StatusCode}");
                }
                if (httpResponse.Content == null)
                {
                    throw new Exception("Content is null");
                }
                if (httpResponse.Content.Headers.ContentType.MediaType != "application/json")
                {
                    throw new Exception($"Content-Type application/json expected. Received {httpResponse.Content.Headers.ContentType.MediaType}");
                }

                var responseContent = await httpResponse.Content.ReadAsStringAsync();

                return responseContent;
            }
        }
    }
}
