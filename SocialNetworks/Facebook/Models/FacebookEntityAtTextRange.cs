using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookEntityAtTextRange
    {
        /// <summary>
        /// ID of the profile.
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Number of characters in the text indicating the object.
        /// </summary>
        public int Length { get; set; }
        /// <summary>
        /// Name of the object.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The object itself.
        /// </summary>
        public FacebookProfile Object { get; set; }
        /// <summary>
        /// The character offset in the source text of the text indicatin the object.
        /// </summary>
        public int Offset { get; set; }
        /// <summary>
        /// Type of the object.
        /// </summary>
        public string Type { get; set; }
        public FacebookEntityAtTextRange(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            ID = (obj["id"] ?? "NA").ToString();
            Length = int.Parse((obj["length"] ?? "0").ToString());
            Name = (obj["name"] ?? "NA").ToString();
            Object = new FacebookProfile(obj["object"]);
            Offset = int.Parse((obj["offset"] ?? "0").ToString());
            Type = (obj["type"] ?? "NA").ToString();
        }
    }
}