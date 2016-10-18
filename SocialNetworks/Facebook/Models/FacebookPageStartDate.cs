using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookPageStartDate
    {
        /// <summary>
        /// The start day of the entity.
        /// </summary>
        public int Day { get; set; }
        /// <summary>
        /// The start month of the entity.
        /// </summary>
        public int Month { get; set; }
        /// <summary>
        /// The start year of the entity.
        /// </summary>
        public int Year { get; set; }
        public FacebookPageStartDate(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            Day = int.Parse((obj["day"] ?? "0").ToString());
            Month = int.Parse((obj["month"] ?? "0").ToString());
            Year = int.Parse((obj["year"] ?? "0").ToString());
        }
    }
}
