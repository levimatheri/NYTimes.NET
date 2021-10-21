using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NYTimes.NET.Tests.Mocks
{
    public class GeneralUseMocks
    {
        public static JObject GetEmptyJArray()
        {
            var mockArray = new
            {
                results = System.Array.Empty<object>()
            };

            return JObject.Parse(JsonConvert.SerializeObject(mockArray, Formatting.Indented));
        }

        public static JObject GetEmptyJObject<T>() where T : new()
        {
            var mockObject = new
            {
                results = new T()
            };

            return JObject.Parse(JsonConvert.SerializeObject(mockObject, Formatting.Indented));
        }
    }
}
