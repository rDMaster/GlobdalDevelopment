using GlobalDevelopment.Interfaces;
using GlobalDevelopment.Models;
using GlobalDevelopment.SocialNetworks.Facebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.Facebook.Interfaces
{
    public interface IFacebookUser
    {
        #region Properties
        string FullName { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string AccessToken { get; set; }
        string About { get; set; }
        string Bio { get; set; }
        string Birthday { get; set; }
        IFacebookCover Cover { get; set; }
        string Email { get; set; }
        string Gender { get; set; }
        string ProfileImageUrl { get; set; }
        IFacebookCurrency Currency { get; set; }
        List<IDevice> Devices { get; set; }
        string Locale { get; set; }
        string NameFormat { get; set; }
        string Political { get; set; }
        string PublicKey { get; set; }
        string Quotes { get; set; }
        string RelationshipStatus { get; set; }
        string Religion { get; set; }
        string Website { get; set; }
        string TimeZone { get; set; }
        string ThirdPartyID { get; set; }
        string PageScopeID { get; set; }
        string ProfilePageUrl { get; set; }
        string GendersInterestedIn { get; set; }
        List<FacebookPost> Posts { get; set; }
        List<FacebookPost> TaggedPosts { get; set; }
        List<FacebookPost> CreatedPosts { get; set; }
        #endregion
        #region Methods
        string GetField(string field);
        string GetEdge(string edge);
        #endregion
    }
}