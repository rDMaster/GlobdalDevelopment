using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookPaymentOptions
    {
        /// <summary>
        /// Whether the business accepts American Express as a payment option.
        /// </summary>
        public int Amex { get; set; }
        /// <summary>
        /// Whether the business accepts cash only as a payment option.
        /// </summary>
        public int CashOnly { get; set; }
        /// <summary>
        /// Whether the business acceots Discover as a payment option.
        /// </summary>
        public int Discover { get; set; }
        /// <summary>
        /// Whether the business accepts Mastercard as a payment option.
        /// </summary>
        public int Mastercard { get; set; }
        /// <summary>
        /// Whether the business accepts Visa as a payment option.
        /// </summary>
        public int Visa { get; set; }
        public FacebookPaymentOptions(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            Amex = int.Parse((obj["amex"] ?? "0").ToString());
            CashOnly = int.Parse((obj["cash_only"] ?? "0").ToString());
            Discover = int.Parse((obj["discover"] ?? "0").ToString());
            Mastercard = int.Parse((obj["mastercard"] ?? "0").ToString());
            Visa = int.Parse((obj["visa"] ?? "0").ToString());
        }
    }
}