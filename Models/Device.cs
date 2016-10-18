using GlobalDevelopment.Interfaces;
using Newtonsoft.Json.Linq;

namespace GlobalDevelopment.Models
{
    public class Device : IDevice
    {
        public string Hardware { get; set; }
        public string OperatingSystem { get; set; }
        public Device(JToken obj)
        {
            Hardware = (obj["hardware"] ?? "NA").ToString();
            OperatingSystem = (obj["os"] ?? "NA").ToString();
        }
    }
}
