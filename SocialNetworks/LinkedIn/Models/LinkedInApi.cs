namespace GlobalDevelopment.SocialNetworks.LinkedIn.Models
{
    public static class LinkedInApi
    {
        public static string ResourceUrl = "https://www.linkedin.com/";
        public static string AuthorizeUrl = ResourceUrl + "oauth/v2/authorization";
        public static string AccessTokenUrl = ResourceUrl + "oauth/v2/accessToken";
        public static string FormatUrl = "&format=json";
        public static string SiteUrl = "https://www.linkedin.com/";
        public static string GrantType = "authorization_code";
        public static string SessionApp = "linkedinApp";
        public static string State = "C1TP0RT$";
        public static string Permission = "r_basicprofile%20r_emailaddress%20rw_company_admin";
        public static string UserFields = "id,email-address,first-name,last-name,maiden-name,formatted-name,phonetic-first-name,phonetic-last-name,formatted-phonetic-name,headline,location,industry,current-share,num-connections,num-connections-capped,summary,specialties,positions,picture-url,picture-urls::(original),site-standard-profile-request,api-standard-profile-request,public-profile-url";
        public static string UserUrl = ResourceUrl + "v1/people/~:(" + UserFields + ")?oauth2_access_token=";
    }
}
