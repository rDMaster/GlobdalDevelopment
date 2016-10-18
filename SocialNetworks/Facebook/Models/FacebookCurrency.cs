using GlobalDevelopment.SocialNetworks.Facebook.Interfaces;
using Newtonsoft.Json.Linq;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookCurrency : IFacebookCurrency
    {
        public string CurrencyOffset { get; set; }
        public string UsdExchange { get; set; }
        public string UserCurrency { get; set; }
        public FacebookCurrency(JToken obj)
        {
            CurrencyOffset = (obj["currency_offset"] ?? "NA").ToString();
            UsdExchange = (obj["usd_exchange"] ?? "NA").ToString();
            UserCurrency = (obj["user_currency"] ?? "NA").ToString();
        }
    }
}
