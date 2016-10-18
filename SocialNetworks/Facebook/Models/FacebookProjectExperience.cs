using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookProjectExperience
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
        /// End Date.
        /// </summary>
        public string EndDate { get; set; }
        /// <summary>
        /// From.
        /// </summary>
        public FacebookUser From { get; set; }
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Start date.
        /// </summary>
        public string StartDate { get; set; }
        /// <summary>
        /// Tagged users.
        /// </summary>
        public List<FacebookUser> With { get; set; }
        public FacebookProjectExperience(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            ID = (obj["id"] ?? "NA").ToString();
            Description = (obj["description"] ?? "NA").ToString();
            EndDate = (obj["end_date"] ?? "NA").ToString();
            if (obj["from"] != null)
                From = new FacebookUser(obj["from"]);
            Name = (obj["name"] ?? "NA").ToString();
            StartDate = (obj["start_date"] ?? "NA").ToString();
            if(obj["with"] != null)
            {
                With = new List<FacebookUser>();
                foreach(var tk in obj["with"])
                {
                    FacebookUser fu = new FacebookUser(tk);
                    With.Add(fu);
                }
            }
        }
    }
}
