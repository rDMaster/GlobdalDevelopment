using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.Facebook.Interfaces
{
    public interface IFacebookCurrency
    {
        string CurrencyOffset { get; set; }
        string UsdExchange { get; set; }
        string UserCurrency { get; set; }
    }
}
