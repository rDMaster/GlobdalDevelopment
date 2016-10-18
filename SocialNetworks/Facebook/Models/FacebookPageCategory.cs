using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookPageCategory
    {
        /// <summary>
        /// The id of this category.
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        ///  The name of this category.
        /// </summary>
        public string Name { get; set; }
        public FacebookPageCategory(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            ID = (obj["id"] ?? "NA").ToString();
            Name = (obj["name"] ?? "NA").ToString();
        }
    }
}
