using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "category")]
    public class Category
    {
        [DataMember, XmlText]
        public string Value { get; set; }

        [DataMember(Name = "domain")]
        public string Domain { get; set; }
    }
}