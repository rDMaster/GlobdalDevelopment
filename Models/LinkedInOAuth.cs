using GlobalDevelopment.Interfaces;

namespace GlobalDevelopment.Models
{
    public class LinkedInOAuth : ILinkedInOauth
    {
        public string AccessToken { get; set; }
        public string PageID { get; set; }
        public string AppSecret { get; set; }
        public string AppId { get; set; }
        public string PermissionScope { get; set; }
        public string State { get; set; }
        public string Url { get; set; }
        public string UserID { get; set; }
        public string Email { get; set; }
        public string ResponseType { get; set; }
        public string UserName { get; set; }
    }
}
