using GlobalDevelopment.UmbracoN;
using Umbraco.Web.Mvc;

namespace GlobalDevelopment.Controllers
{
    public class UmbracoNSurfaceController : SurfaceController
    {
        public void UmbracoMemberRegister(string memberName, string email, string password, string memberType, string memberGroupd)
        {
            Member.CreateMember(memberName, email, password, memberType, memberGroupd);
        }
        public void UmbracoMemberLogin(string email, bool t)
        {
            Member.MemberLoginU(email, t);
        }
        public void UmbracoMemberLogout()
        {
            Member.MemberLogout();
        }
    }
}