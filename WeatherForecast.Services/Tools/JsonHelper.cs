using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WeatherForecastApp.Tools
{
    public static class JsonHelper
    {
        internal static string ToJson(object objectToSerialize)
        {
            //JsonConvert.SerializeObject(_apiResponse);

            throw new System.NotImplementedException();
        }

        internal static T ParseJson<T>(string payload)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver { NamingStrategy = new SnakeCaseNamingStrategy() }
            };

            var json = JsonConvert.DeserializeObject<T>(payload, settings);

            return json;
        }
    }
}
