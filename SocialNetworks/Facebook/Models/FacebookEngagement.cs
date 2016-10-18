using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookEngagement
    {
        /// <summary>
        /// Number of poeple who like this.
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Abbreviated string reprentation of count.
        /// </summary>
        public string CountString { get; set; }
        /// <summary>
        /// Abbreviated string representation of count if the viewer likes the object.
        /// </summary>
        public string CountStringWithLike { get; set; }
        /// <summary>
        /// Abbreviated string representation of count if the viewer likes the object.
        /// </summary>
        public string CountStringWithoutLike { get; set; }
        /// <summary>
        /// The text that the like button would currently display.
        /// </summary>
        public string SocialSentence { get; set; }
        /// <summary>
        /// The text that the like button would display if the viewer likes the object.
        /// </summary>
        public string SocialSentenceWithLike { get; set; }
        /// <summary>
        /// Text that the like button would display if the viewer does not like the object.
        /// </summary>
        public string SocialSentenceWithoutLike { get; set; }
        public FacebookEngagement(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            Count = int.Parse((obj["count"] ?? "0").ToString());
            CountString = (obj["count_string"] ?? "NA").ToString();
            CountStringWithLike = (obj["count_string_with_like"] ?? "NA").ToString();
            CountStringWithoutLike = (obj["count_string_without_like"] ?? "NA").ToString();
            SocialSentence = (obj["social_sentance"] ?? "NA").ToString();
            SocialSentenceWithLike  = (obj["social_sentance_with_like"] ?? "NA").ToString();
            SocialSentenceWithoutLike = (obj["social_sentance_without_like"] ?? "NA").ToString();
        }
    }
}
