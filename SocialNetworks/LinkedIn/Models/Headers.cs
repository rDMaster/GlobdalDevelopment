using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.LinkedIn.Models
{
    public class Headers
    {
        public int _Total { get; set; }
        public List<Values> Values { get; set; }
        public Headers(JToken token)
        {
            Values = new List<Values>();
            _Total = int.Parse((token["_total"] ?? "0").ToString());
            Values value;
            foreach(JToken tk in token["values"])
            {
                value = new Values(tk);
                Values.Add(value);
            }
        }
    }
}
