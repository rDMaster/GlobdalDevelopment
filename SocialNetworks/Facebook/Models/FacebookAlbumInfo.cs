using Newtonsoft.Json.Linq;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookAlbumInfo
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public FacebookAlbumInfo(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            ID = (obj["id"] ?? "NA").ToString();
            Name = (obj["name"] ?? "NA").ToString();
        }
    }
}
