using Newtonsoft.Json.Linq;
using System;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookAgeRange
    {
        public Int32 Max { get; set; }
        public Int32 Min { get; set; }
        public FacebookAgeRange(int max, int min)
        {
            Max = max;
            Min = min;
        }
        public FacebookAgeRange(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            Max = int.Parse((obj["max"] ?? "0").ToString());
            Min = int.Parse((obj["min"] ?? "0").ToString());
        }
    }
}