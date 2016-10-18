using Newtonsoft.Json.Linq;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookVoipInfo
    {
        /// <summary>
        /// Does this user have a pushable mobile app install?
        /// </summary>
        public bool HasMobileApp { get; set; }
        /// <summary>
        /// Does the viewer have permission to call?
        /// </summary>
        public bool HasPermission { get; set; }
        /// <summary>
        /// Is this user currently callable via mobile?
        /// </summary>
        public bool IsCallable { get; set; }
        /// <summary>
        /// Is this user currently callable vis desktop?
        /// </summary>
        public bool IsCallableWebrct { get; set; }
        /// <summary>
        /// Does this user have an unmuted push token?
        /// </summary>
        public bool IsPushable { get; set; }
        /// <summary>
        /// Reason code if not callable.
        /// </summary>
        public int ReasonCode { get; set; }
        /// <summary>
        /// Reason description if not callable.
        /// </summary>
        public string ReasionDescription { get; set; }
        public FacebookVoipInfo(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            HasMobileApp = bool.Parse((obj["has_mobile_app"] ?? "false").ToString());
            HasPermission = bool.Parse((obj["has_permission"] ?? "false").ToString());
            IsCallable = bool.Parse((obj["is_callable"] ?? "false").ToString());
            IsCallableWebrct = bool.Parse((obj["is_callable_webrtc"] ?? "false").ToString());
            IsPushable = bool.Parse((obj["is_pushable"] ?? "false").ToString());
            ReasonCode = int.Parse((obj["reason_code"] ?? "0").ToString());
            ReasionDescription = (obj["reasion_description"] ?? "NA").ToString();
        }
    }
}
