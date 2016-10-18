using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookWorkExperience
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
        /// Employer.
        /// </summary>
        public FacebookPage Employer { get; set; }
        /// <summary>
        /// End date.
        /// </summary>
        public string EndDate { get; set; }
        /// <summary>
        /// Tagged by.
        /// </summary>
        public FacebookUser From { get; set; }
        /// <summary>
        /// Location
        /// </summary>
        public FacebookPage Location { get; set; }
        /// <summary>
        /// Position.
        /// </summary>
        public FacebookPage Position { get; set; }
        /// <summary>
        /// Projects.
        /// </summary>
        public List<FacebookProjectExperience> Projects { get; set; }
        /// <summary>
        /// Start date.
        /// </summary>
        public string StartDate { get; set; }
        /// <summary>
        /// Tagged Users.
        /// </summary>
        public List<FacebookUser> With { get; set; }
        public FacebookWorkExperience(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            ID = (obj["id"] ?? "NA").ToString();
            Description = (obj["description"] ?? "NA").ToString();
            if (obj["employer"] != null)
                Employer = new FacebookPage(obj["employer"]);
            EndDate = (obj["end_date"] ?? "NA").ToString();
            if (obj["from"] != null)
                From = new FacebookUser(obj["from"]);
            if (obj["location"] != null)
                Location = new FacebookPage(obj["location"]);
            if (obj["position"] != null)
                Position = new FacebookPage(obj["position"]);
            if (obj["projects"] != null)
            {
                Projects = new List<FacebookProjectExperience>();
                foreach(var tk in obj["projects"])
                {
                    FacebookProjectExperience fpe = new FacebookProjectExperience(tk);
                    Projects.Add(fpe);
                }
            }
            if (obj["with"] != null)
            {
                With = new List<FacebookUser>();
                foreach (var tk in obj["with"])
                {
                    FacebookUser fu = new FacebookUser(tk);
                    With.Add(fu);
                }
            }
        }
    }
}
