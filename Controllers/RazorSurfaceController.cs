using GlobalDevelopment.SocialNetworks;
using Umbraco.Web.Mvc;
using System.Web.Mvc;

namespace GlobalDevelopment.Controllers
{
    public class RazorSurfaceController : SurfaceController
    {
        public RedirectResult FacebookLoginRegister(string url, string memberType, string memberGroups, string propertyAlias)
        {
            FacebookM.Authorization(url);
            FacebookM.MemberRegisterU(memberType, memberGroups, propertyAlias);
            return Redirect(url);
        }
    }
}