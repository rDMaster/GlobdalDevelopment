using GlobalDevelopment.SocialNetworks;
using GlobalDevelopment.Models;
using System.Collections.Generic;
using Umbraco.Web.Mvc;
using System.Web.Http;

namespace GlobalDevelopment.Controllers
{
    public class FacebookMSurfaceController : SurfaceController
    {
        [HttpGet]
        public void Authorization(string url)
        {
            FacebookM.Authorization(url);
        }
        [HttpGet]
        public string GetAuthorizationRedirectUrl(string url)
        {
            return FacebookM.GetAuthorizationRedirectUrl(url);
        }
        [HttpGet]
        public string ExtractAccessToken(string url)
        {
            return FacebookM.ExtractAccessToken(url);
        }
        public void FacebookCreatePost(string text)
        {
            FacebookM.CreatePost(text);
        }
        public List<Posts> FacebookGetPosts()
        {
            return FacebookM.GetPosts();
        }
        public List<Posts> FacebookGetPosts(string pageID)
        {
            return FacebookM.GetPosts(pageID);
        }
        public string FacebookGetField(string field)
        {
            return FacebookM.GetField(field);
        }
        public void MemberRegisterU(string memberType, string memberGroup, string propertyAlias)
        {
            FacebookM.MemberRegisterU(memberType, memberGroup, propertyAlias);
        }
    }
}