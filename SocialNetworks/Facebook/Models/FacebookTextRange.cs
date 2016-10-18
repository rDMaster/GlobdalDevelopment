using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookTextRange
    {
        public string ID { get; set; }
        public int Length { get; set; }
        public string Name { get; set; }
        public int Offset { get; set; }
        public string Type { get; set; }
        public FacebookTextRange(string id, int length, string name, int offset, string type)
        {
            ID = id;
            Length = length;
            Name = name;
            Offset = offset;
            Type = type;
        }
        public FacebookTextRange(JObject obj)
        {
            ID = (obj["id"] ?? "NA").ToString();
            Length = int.Parse((obj["length"] ?? "NA").ToString());
            Name = (obj["name"] ?? "NA").ToString();
            Offset = int.Parse((obj["offset"] ?? "NA").ToString());
            Type = (obj["type"] ?? "NA").ToString();
        }
    }
}