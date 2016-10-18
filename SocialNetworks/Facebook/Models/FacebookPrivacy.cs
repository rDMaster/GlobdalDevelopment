using Newtonsoft.Json.Linq;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookPrivacy
    {
        /// <summary>
        /// The text that describes the privacy settings, as they would appear on Facebook.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// The actual setting.
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// If value is 'CUSTOM', this indicates which groupd of friends can see the post.
        /// </summary>
        public string Friends { get; set; }
        /// <summary>
        /// If value is 'CUSTOM', this is a comma-seperated ID list of users and friendlists (if any) that can see the post.
        /// </summary>
        public string Allow { get; set; }
        /// <summary>
        /// If value is 'CUSTOM', this is a comma-seperated ID list of users and friendlists (if any) that cannot see the post.
        /// </summary>
        public string Deny { get; set; }
        /// <summary>
        /// Model that contains all facebook's privacy settings and information.
        /// </summary>
        /// <param name="token"></param>
        public FacebookPrivacy(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            Description = (obj["description"] ?? "NA").ToString();
            Value = (obj["value"] ?? "NA").ToString();
            Friends = (obj["friends"] ?? "NA").ToString();
            Allow = (obj["allow"] ?? "NA").ToString();
            Deny = (obj["deny"] ?? "NA").ToString();
        }
    }
}