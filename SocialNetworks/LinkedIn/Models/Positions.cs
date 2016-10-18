using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.LinkedIn.Models
{
    public class Positions
    {
        public int _Total { get; set; }
        public List<PositionValues> PositionValues { get; set; }
        public Positions(JToken token)
        {
            PositionValues = new List<PositionValues>();
            _Total = int.Parse((token["_total"] ?? "NA").ToString());
            PositionValues pv;
            foreach(JToken tk in token["values"])
            {
                pv = new PositionValues(tk);
                PositionValues.Add(pv);
            }
        }
    }
}
