using Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.Models
{
    public class FacebookOAuth
    {
        public string AccessToken { get; set; }
        public string PageID { get; set; }
        public string AppSecret { get; set; }
        public string AppId { get; set; }
        public string PermissionScope { get; set; }
        public string Url { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public FacebookClient Client { get; set; }
        public string UserID { get; set; }
    }
}