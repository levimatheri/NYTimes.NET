using Newtonsoft.Json;
using System.IO;

namespace NYTimes.NET.Clients
{
    /// <summary>
    /// Custom Json writer to serialize xml to json
    /// </summary>
    /// <remarks>
    /// Obtained from <see cref="https://stackoverflow.com/a/43485727"/>
    /// </remarks>
    public class CustomJsonWriter : JsonTextWriter
    {
        public CustomJsonWriter(TextWriter writer) : base(writer) { }

        public override void WritePropertyName(string name)
        {
            if (name.StartsWith("@") || name.StartsWith("#"))
            {
                base.WritePropertyName(name[1..]);
            }
            else
            {
                base.WritePropertyName(name);
            }
        }
    }
}
