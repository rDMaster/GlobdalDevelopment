using GlobalDevelopment.SocialNetworks.Facebook.Interfaces;
using Newtonsoft.Json.Linq;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookCover : IFacebookCover
    {
        public string PhotoID { get; set; }
        public string CoverID { get; set; }
        public string OffsetX { get; set; }
        public string OffsetY { get; set; }
        public string SourceUrl { get; set; }
        public FacebookCover(JToken obj)
        {
            PhotoID = (obj["id"] ?? "NA").ToString();
            CoverID = (obj["cover_id"] ?? "NA").ToString();
            OffsetX = (obj["offset_x"] ?? "NA").ToString();
            OffsetY = (obj["offset_y"] ?? "NA").ToString();
            SourceUrl = (obj["source"] ?? "NA").ToString();
        }
    }
}