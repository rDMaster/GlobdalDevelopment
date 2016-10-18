using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookStoryTags
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Offset { get; set; }
        public string Length { get; set; }
        public FacebookStoryTags(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            ID = (obj["id"] ?? "NA").ToString();
            Name = (obj["name"] ?? "NA").ToString();
            Type = (obj["type"] ?? "NA").ToString();
            Offset = (obj["offset"] ?? "NA").ToString();
            Length = (obj["length"] ?? "NA").ToString();
        }
    }
}