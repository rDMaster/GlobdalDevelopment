using Newtonsoft.Json.Linq;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookPlace
    {
        public string ID { get; set; }
        public FacebookLocation Location { get; set; }
        public string Name { get; set; }
        public float OveralRating { get; set; }
        public FacebookPlace(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            ID = (obj["id"] ?? "NA").ToString();
            Location = new FacebookLocation(obj["location"]);
            Name = (obj["name"] ?? "NA").ToString();
            OveralRating = float.Parse((obj["located_in"] ?? "NA").ToString());
        }
    }
}