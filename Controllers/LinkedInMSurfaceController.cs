using GlobalDevelopment.SocialNetworks;
using Umbraco.Web.Mvc;

namespace GlobalDevelopment.Controllers
{
    public class LinkedInMSurfaceController : SurfaceController
    {
        public void MemberRegisterU(string memberType, string memberGroup, string propertyAlias)
        {
            LinkedinM.MemberRegisterU(memberType, memberGroup, propertyAlias);
        }
        public string GetField(string field)
        {
            return LinkedinM.GetField(field);
        }
    }
}