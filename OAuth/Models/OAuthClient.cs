using GlobalDevelopment.OAuth.Interfaces;

namespace GlobalDevelopment.OAuth.Models
{
    public class OAuthClient : IOAuthClient
    {
        public string AccessToken { get; set; }
    }
}