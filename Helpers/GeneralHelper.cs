using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.Helpers
{
    public static class GeneralHelper
    {
        public static JToken GetData(string field, string json)
        {
            object deserialized = JsonConvert.DeserializeObject(json.ToString());
            JObject obj = JObject.Parse(deserialized.ToString());
            JToken data;
            obj.TryGetValue(field, out data);
            return data;
        }
    }
}
