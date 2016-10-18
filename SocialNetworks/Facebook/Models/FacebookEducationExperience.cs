using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookEducationExperience
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Classes taken.
        /// </summary>
        public List<FacebookExperience> Classes { get; set; }
        /// <summary>
        /// Facebookpages representing subjects studied.
        /// </summary>
        public List<FacebookPage> Concentration { get; set; }
        /// <summary>
        /// The facebook page for the degree obtained.
        /// </summary>
        public FacebookPage Degree { get; set; }
        /// <summary>
        /// The facebook page for this school.
        /// </summary>
        public FacebookPage School { get; set; }
        /// <summary>
        /// The type of educational instituion.
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// People tagged who went to school with this person.
        /// </summary>
        public List<FacebookUser> With { get; set; }
        /// <summary>
        /// Facebook page for the year this person graduated.
        /// </summary>
        public FacebookPage Year { get; set; }
        public FacebookEducationExperience(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            ID = (obj["id"] ?? "NA").ToString();
            if (obj["classes"] != null)
            {
                Classes = new List<FacebookExperience>();
                foreach (var Class in obj["classes"])
                {
                    FacebookExperience fe = new FacebookExperience(Class);
                    Classes.Add(fe);
                }
            }
            if (obj["concentration"] != null)
            {
                Concentration = new List<FacebookPage>();
                foreach (var c in obj["concentration"])
                {
                    FacebookPage fp = new FacebookPage(c);
                    Concentration.Add(fp);
                }
            }
            if (obj["school"] != null)
                School = new FacebookPage(obj["school"]);
            Type = (obj["type"] ?? "NA").ToString();
            if (obj["with"] != null)
            {
                With = new List<FacebookUser>();
                foreach (var c in obj["with"])
                {
                    FacebookUser fu = new FacebookUser(c);
                    With.Add(fu);
                }
            }
            if (obj["year"] != null)
                Year = new FacebookPage(obj["year"]);
        }
    }
}
