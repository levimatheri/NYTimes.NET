using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NYTimes.NET.Tests.Mocks
{
    public class ArchiveMocks
    {
        public static JObject GetEmptyJArray()
        {
            var mockArray = new
            {
                response = new
                {
                    docs = System.Array.Empty<object>()
                }
            };

            return JObject.Parse(JsonConvert.SerializeObject(mockArray, Formatting.Indented));
        }
    }
}
