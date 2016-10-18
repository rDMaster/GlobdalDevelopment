using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookExperience
    {
        /// <summary>
        /// ID.
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Description.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// From.
        /// </summary>
        public FacebookUser From { get; set; }
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// With.
        /// </summary>
        public List<FacebookUser> With { get; set; }
        public FacebookExperience(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            ID = (obj["id"] ?? "NA").ToString();
            Description = (obj["description"] ?? "NA").ToString();
            if(obj["from"] != null)
                From = new FacebookUser(obj["from"]);
            Name = (obj["name"] ?? "NA").ToString();
            if (obj["with"] != null)
            {
                With = new List<FacebookUser>();
                foreach (var user in obj["with"])
                {
                    FacebookUser fbUser = new FacebookUser(user);
                    With.Add(fbUser);
                }
            }
        }
    }
}
