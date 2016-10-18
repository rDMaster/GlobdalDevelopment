using Umbraco.Core;
using Umbraco.Web;
using Umbraco.Web.WebServices;

namespace GlobalDevelopment.Inheritance
{
    public class UmbracoBase
    {
        public ApplicationContext AContext { get; set; }
        public UmbracoContext UContext { get; set; }
        public UmbracoHelper Helper { get; set; }
        public UmbracoBase()
        {
            AContext = ApplicationContext.Current;
            UContext = UmbracoContext.Current;
            Helper = new UmbracoHelper(UContext);
        }
    }
}
