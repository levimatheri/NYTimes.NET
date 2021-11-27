using Newtonsoft.Json;

namespace NYTimes.NET.Models
{
    public abstract class ModelBase
    {
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
