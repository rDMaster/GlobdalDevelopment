using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookPageStartInfo
    {
        /// <summary>
        /// The start date of the entity.
        /// </summary>
        public FacebookPageStartDate Date { get; set; }
        /// <summary>
        /// The start type of the entity.
        /// </summary>
        public string Type { get; set; }
        public FacebookPageStartInfo(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            Date = new FacebookPageStartDate(obj["data"]);
            Type = (obj["type"] ?? "NA").ToString();
        }
    }
}