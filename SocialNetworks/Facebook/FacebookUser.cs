using GlobalDevelopment.Helpers;
using GlobalDevelopment.Models;
using GlobalDevelopment.OAuth.Models;
using GlobalDevelopment.SocialNetworks.Facebook.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GlobalDevelopment.SocialNetworks.Facebook
{
    public class FacebookUser //: OAuthApp
    {
        #region Properties
        /// <summary>
        /// This is a boolean to determin weather the current user instance has been successfully authenticated.
        /// </summary>
        public bool IsAuthenticated { get; set; }
        /// <summary>
        /// The id of the current user instance's account. The ID is unique to each app and cannot be used across diferant apps.
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// The 'About Me' sesction of this person's profile.
        /// </summary>
        public string About { get; set; }
        /// <summary>
        /// Notes added by viewing page on this person.
        /// </summary>
        public List<FacebookPageAdminNote> AdminNotes { get; set; }
        /// <summary>
        /// The age segment for the current user expressed as a minimum and maximum age. For example, more than 18, less than 21.
        /// </summary>
        public FacebookAgeRange AgeRange { get; set; }
        /// <summary>
        /// The current user's bio.
        /// </summary>
        public string Bio { get; set; }
        /// <summary>
        /// The current user's birthday. This is a fixed format string, like 'MM/DD/YYYY'. However, people can control who can see the year they were born seperately from the month and day so this string can be only the year 'YYYY' or month + day 'MM/DD'.
        /// </summary>
        public string Birthday { get; set; }
        /// <summary>
        /// Social context for this person.
        /// </summary>
        public FacebookUserContext Context {get;set;}
        /// <summary>
        /// The current user's cover.
        /// </summary>
        public FacebookCover Cover { get; set; }
        /// <summary>
        /// The current user's local currency information.
        /// </summary>
        public FacebookCurrency Currency { get; set; }
        /// <summary>
        /// The lis of devices the person is using. This will return only IOS and Android devices.
        /// </summary>
        public List<Device> Devices { get; set; }
        /// <summary>
        /// The person's education.
        /// </summary>
        public List<FacebookEducationExperience> Education { get; set; }
        /// <summary>
        /// The persons's primary email address listed on their profile. This field will not return if no valid email address is available.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Atheletes the person likes.
        /// </summary>
        public List<FacebookExperience> FavoriteAthletes { get; set; }
        /// <summary>
        /// Sports teams the person likes.
        /// </summary>
        public List<FacebookExperience> FavoriteTeams { get; set; }
        /// <summary>
        /// The person's first name.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// The gender selected by this person, male or female. This value will be omitted if the value is set to custom value.
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// The person's hometown.
        /// </summary>
        public FacebookPage HomeTown { get; set; }
        /// <summary>
        /// The person's inspirational people.
        /// </summary>
        public List<FacebookExperience> InspirationalPeople { get; set; }
        /// <summary>
        /// Install type.
        /// </summary>
        public string InstallType { get; set; }
        /// <summary>
        /// Is the app making the request installed?
        /// </summary>
        public bool Installed { get; set; }
        /// <summary>
        /// Gender's the person is interested in.
        /// </summary>
        public List<string> InterestedIn { get; set; }
        /// <summary>
        /// Is this a shared login?
        /// </summary>
        public bool IsSharedLogin { get; set; }
        /// <summary>
        /// This field indicates whether the person's profile is verified in this way.
        /// </summary>
        public bool IsVerified { get; set; }
        /// <summary>
        /// Labels applied by viewing page this person.
        /// </summary>
        public List<FacebookPageLabel> Labels { get; set; }
        /// <summary>
        /// Facebook pages representing the languages this person knows.
        /// </summary>
        public List<FacebookExperience> Languages { get; set; }
        /// <summary>
        /// This person's last name.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// A link to the person's timeline.
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// The person's locale.
        /// </summary>
        public string Locale { get; set; }
        /// <summary>
        /// The person's current location as entered by them on their profile.
        /// </summary>
        public FacebookPage Location { get; set; }
        /// <summary>
        /// What the person is interested in meeting for.
        /// </summary>
        public List<string> MeetingFor { get; set; }
        /// <summary>
        /// The person's middle name.
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// The person's full name.
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// The person's name formatted to correctly handle Chinese, Japanese, or Koeran ordering.
        /// </summary>
        public string NameFormat { get; set; }
        /// <summary>
        /// Page scoped ID for this user.
        /// </summary>
        public string PageScopedID { get; set; }
        /// <summary>
        /// The person's political views.
        /// </summary>
        public string Political { get; set; }
        /// <summary>
        /// The persons's PGP public key.
        /// </summary>
        public string PublicKey { get; set; }
        /// <summary>
        /// The person's favorite quotes.
        /// </summary>
        public string Quotes { get; set; }
        /// <summary>
        /// This person's relationship status.
        /// </summary>
        public string RelationshipStatue { get; set; }
        /// <summary>
        /// This person's religion.
        /// </summary>
        public string Religion { get; set; }
        /// <summary>
        /// The time that the shared loginneeds to be upgraded to business manager.
        /// </summary>
        public DateTime SharedLoginUpgradeRequiredBy { get; set; }
        /// <summary>
        /// The person's significant other.
        /// </summary>
        public FacebookUser SignificantOther { get; set; }
        /// <summary>
        /// Sports played by the person.
        /// </summary>
        public List<FacebookExperience> Sports { get; set; }
        /// <summary>
        /// Platform test group.
        /// </summary>
        public int TestGroup { get; set; }
        /// <summary>
        /// A string containing an anonymous, but unique identifier for the person. You can use this identifier with third parties.
        /// </summary>
        public string ThirdPartyID { get; set; }
        /// <summary>
        /// The person's current timezone offset from UTC.
        /// </summary>
        public float TimeZone { get; set; }
        /// <summary>
        /// A token that is the same accross a business's apps. Access to this requires that the person logged into your app or have a role on your. This will change if the businesss owning the app changes.
        /// </summary>
        public string TokenForBusiness { get; set; }
        /// <summary>
        /// Updated time.
        /// </summary>
        public DateTime UpdatedTime { get; set; }
        /// <summary>
        /// Indicates whether the account has been verified.
        /// </summary>
        public bool Verified { get; set; }
        /// <summary>
        /// Video upload limits.
        /// </summary>
        public FacebookVideoUploadLimits VideoUploadLimites { get; set; }
        /// <summary>
        /// Can the viewer send a gift to this person?
        /// </summary>
        public bool ViewerCanSendGift { get; set; }
        /// <summary>
        /// The person's website.
        /// </summary>
        public string Website { get; set; }
        /// <summary>
        /// Details of a person's work experience.
        /// </summary>
        public List<FacebookWorkExperience> Work { get; set; }
        /// <summary>
        /// All of this person's Posts.
        /// </summary>
        public List<FacebookPost> Posts { get; set; }
        /// <summary>
        /// Any post's this person is tagged in.
        /// </summary>
        public List<FacebookPost> TaggedPosts { get; set; }
        /// <summary>
        /// All user created posts.
        /// </summary>
        public List<FacebookPost> CreatedPosts { get; set; }
        /// <summary>
        /// The user's authorization access token.
        /// </summary>
        public string AccessToken { get; set; }
        /// <summary>
        /// The app which is used to authenticate the user. For example the app information that was used.
        /// </summary>
        public FacebookApp App { get; set; }
        /// <summary>
        /// The person's accounts.
        /// </summary>
        public List<FacebookAccount> Accounts { get; set; }
        /// <summary>
        /// This person's profile picture.
        /// </summary>
        public string Picture { get; set; }
        /// <summary>
        /// The photo albums this person has created.
        /// </summary>
        public List<FacebookAlbum> Albums { get; set; }
        #endregion
        #region Constructors
        public FacebookUser(string appID, string appSecret, string returnUrl) //: base(appID, appSecret, FacebookApi.Permission, returnUrl)
        {
            IsAuthenticated = false;
            if (HttpContext.Current.Session[FacebookApi.SessionApp] != null)
                App = (OAuthApp)HttpContext.Current.Session[FacebookApi.SessionApp] as FacebookApp;
            else
                App = new FacebookApp(appID, appSecret, returnUrl);
            if (App.AccessToken == null || App.AccessToken == "Invalid AccessToken")
                App.AccessToken = FacebookHelper.Authorization(returnUrl, appID, appSecret, FacebookApi.Permission);
            if (App.AccessToken != null && App.AccessToken != "Invalid AccessToken")
            {
                IsAuthenticated = true;
                AccessToken = App.AccessToken;
                BuildUser(FacebookHelper.GetUser(AccessToken));
            }
        }
        public FacebookUser(string accesstoken) //: base((OAuthApp)HttpContext.Current.Session[FacebookApi.SessionApp])
        {
            IsAuthenticated = false;
            if (HttpContext.Current.Session[FacebookApi.SessionApp] != null)
                App = (OAuthApp)HttpContext.Current.Session[FacebookApi.SessionApp] as FacebookApp;
            else
                App = new FacebookApp(accesstoken);
            IsAuthenticated = true;
            BuildUser(FacebookHelper.GetUser(accesstoken));
        }
        public FacebookUser(JToken token)
        {
            IsAuthenticated = false;
            if (HttpContext.Current.Session[FacebookApi.SessionApp] != null)
                App = (OAuthApp)HttpContext.Current.Session[FacebookApi.SessionApp] as FacebookApp;
            IsAuthenticated = true;
            AccessToken = App.AccessToken;
            BuildUser(token);
        }
        #endregion
        #region Methods
        private void BuildUser(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            #region Setting Properties
            ID = (obj["id"] ?? "NA").ToString();
            About = (obj["about"] ?? "NA").ToString();
            AdminNotes = new List<FacebookPageAdminNote>();
            if (obj["admin_notes"] != null)
            {
                foreach (var tk in obj["admin_notes"])
                {
                    FacebookPageAdminNote fpan = new FacebookPageAdminNote(tk);
                    AdminNotes.Add(fpan);
                }
            }
            if (obj["age_range"] != null)
                AgeRange = new FacebookAgeRange(obj["age_range"]);
            Bio = (obj["bio"] ?? "NA").ToString();
            Birthday = (obj["birthday"] ?? "NA").ToString();
            if (obj["context"] != null)
                Context = new FacebookUserContext(obj["context"]);
            if (obj["cover"] != null)
                Cover = new FacebookCover(obj["cover"]);
            if (obj["currency"] != null)
                Currency = new FacebookCurrency(obj["currency"]);
            Devices = new List<Device>();
            if (obj["devices"] != null)
            {
                foreach (var tk in obj["devices"])
                {
                    Device device = new Device(tk);
                    Devices.Add(device);
                }
            }
            Education = new List<FacebookEducationExperience>();
            if (obj["education"] != null)
            {
                foreach (var tk in obj["education"])
                {
                    FacebookEducationExperience fe = new FacebookEducationExperience(tk);
                    Education.Add(fe);
                }
            }
            Email = (obj["email"] ?? "NA").ToString();
            FavoriteAthletes = new List<FacebookExperience>();
            if (obj["favorite_athletes"] != null)
            {
                foreach (var tk in obj["favorite_athletes"])
                {
                    FacebookExperience fe = new FacebookExperience(tk);
                    FavoriteAthletes.Add(fe);
                }
            }
            if (obj["favorite_teams"] != null)
            {
                FavoriteTeams = new List<FacebookExperience>();
                foreach (var tk in obj["favorite_teams"])
                {
                    FacebookExperience fe = new FacebookExperience(tk);
                    FavoriteTeams.Add(fe);
                }
            }
            FirstName = (obj["first_name"] ?? "NA").ToString();
            Gender = (obj["gender"] ?? "NA").ToString();
            if (obj["hometown"] != null)
                HomeTown = new FacebookPage(obj["hometown"]);
            if (obj["inspirational_people"] != null)
            {
                InspirationalPeople = new List<FacebookExperience>();
                foreach (var tk in obj["inspirational_people"])
                {
                    FacebookExperience fe = new FacebookExperience(tk);
                    InspirationalPeople.Add(fe);
                }
            }
            InstallType = (obj["install_type"] ?? "NA").ToString();
            Installed = bool.Parse((obj["installed"] ?? "false").ToString());
            if (obj["interested_in"] != null)
            {
                InterestedIn = new List<string>();
                foreach (var tk in obj["interested_in"])
                {
                    InterestedIn.Add(tk.ToString());
                }
            }
            IsSharedLogin = bool.Parse((obj["is_shared_login"] ?? "false").ToString());
            IsVerified = bool.Parse((obj["is_verified"] ?? "false").ToString());
            if (obj["labels"] != null)
            {
                Labels = new List<FacebookPageLabel>();
                foreach (var tk in obj["labels"])
                {
                    FacebookPageLabel fpl = new FacebookPageLabel(tk);
                    Labels.Add(fpl);
                }
            }
            if (obj["languages"] != null)
            {
                Languages = new List<FacebookExperience>();
                foreach (var tk in obj["languages"])
                {
                    FacebookExperience fe = new FacebookExperience(tk);
                    Languages.Add(fe);
                }
            }
            LastName = (obj["last_name"] ?? "NA").ToString();
            Link = (obj["link"] ?? "NA").ToString();
            Locale = (obj["locale"] ?? "NA").ToString();
            if (obj["location"] != null)
                Location = new FacebookPage(obj["location"]);
            if (obj["meeting_for"] != null)
            {
                MeetingFor = new List<string>();
                foreach (var tk in obj["meeting_for"])
                {
                    MeetingFor.Add(tk.ToString());
                }
            }
            MiddleName = (obj["middle_name"] ?? "NA").ToString();
            FullName = (obj["name"] ?? "NA").ToString();
            NameFormat = (obj["name_format"] ?? "NA").ToString();
            PageScopedID = (obj["page_scoped_id"] ?? "NA").ToString();
            Political = (obj["political"] ?? "NA").ToString();
            Quotes = (obj["quotes"] ?? "NA").ToString();
            PublicKey = (obj["public_key"] ?? "NA").ToString();
            RelationshipStatue = (obj["relationship_status"] ?? "NA").ToString();
            Religion = (obj["religion"] ?? "NA").ToString();
            SharedLoginUpgradeRequiredBy = DateTime.Parse((obj["shared_login_upgrade_required_by"] ?? DateTime.Now.ToString()).ToString());
            if (obj["significant_other"] != null)
                SignificantOther = new FacebookUser(obj["significant_other"]);
            if (obj["sports"] != null)
            {
                Sports = new List<FacebookExperience>();
                foreach (var tk in obj["sports"])
                {
                    FacebookExperience fe = new FacebookExperience(tk);
                    Sports.Add(fe);
                }
            }
            TestGroup = int.Parse((obj["test_group"] ?? "0").ToString());
            ThirdPartyID = (obj["third_party_id"] ?? "NA").ToString();
            TimeZone = float.Parse((obj["timezone"] ?? "0").ToString());
            TokenForBusiness = (obj["token_for_business"] ?? "NA").ToString();
            UpdatedTime = DateTime.Parse((obj["updated_time"] ?? DateTime.Now.ToString()).ToString());
            Verified = bool.Parse((obj["verified"] ?? "false").ToString());
            if (obj["video_upload_limits"] != null)
                VideoUploadLimites = new FacebookVideoUploadLimits(obj["video_upload_limits"]);
            ViewerCanSendGift = bool.Parse((obj["viewer_can_send_gift"] ?? "false").ToString());
            Website = (obj["website"] ?? "NA").ToString();
            if (obj["work"] != null)
            {
                Work = new List<FacebookWorkExperience>();
                foreach (var tk in obj["work"])
                {
                    FacebookWorkExperience fe = new FacebookWorkExperience(tk);
                    Work.Add(fe);
                }
            }
            #endregion
            #region Setting Edges
            Picture = GetEdge("picture");
            Accounts = new List<FacebookAccount>();
            foreach (var tk in GeneralHelper.GetData("data", GetEdgeJson("accounts", AccessToken)))
            {
                FacebookAccount fa = new FacebookAccount(token);
                Accounts.Add(fa);
            }
            Posts = GetPosts();
            TaggedPosts = GetTaggedPosts();
            CreatedPosts = GetUserCreatedPosts();
            Albums = new List<FacebookAlbum>();
            foreach (var album in GeneralHelper.GetData("data", GetEdgeJson("albums", FacebookApi.AlbumFields, AccessToken)))
            {
                JObject ob = JObject.Parse(album.ToString());
                GetField(ob["id"].ToString());
                FacebookAlbum fa = new FacebookAlbum(album);
                Albums.Add(fa);
            }
            #endregion
        }
        private void BuildUser(string accessToken)
        {
            JObject json = FacebookHelper.GetUser(accessToken);

            Email = (json["email"] ?? "NA").ToString();
            ID = (json["id"] ?? "NA").ToString();
            FirstName = (json["first_name"] ?? "NA").ToString();
            LastName = (json["last_name"] ?? "NA").ToString();
            if (json["cover"] != null) Cover = new FacebookCover(json["cover"]);
            Birthday = (json["birthday"] ?? "NA").ToString();
            if (json["currency"] != null) Currency = new FacebookCurrency(json["currency"]);
            Bio = (json["bio"] ?? "NA").ToString();
            About = (json["about"] ?? "NA").ToString();
            Website = (json["website"] ?? "NA").ToString();
            TimeZone = float.Parse((json["timezone"] ?? "NA").ToString());
            ThirdPartyID = (json["third_party_id"] ?? "NA").ToString();
            Religion = (json["religion"] ?? "NA").ToString();
            RelationshipStatue = (json["relationship_status"] ?? "NA").ToString();
            Quotes = (json["quotes"] ?? "NA").ToString();
            PublicKey = (json["public_key"] ?? "NA").ToString();
            PageScopedID = (json["page_scope_id"] ?? "NA").ToString();
            NameFormat = (json["name_format"] ?? "NA").ToString();
            FullName = (json["name"] ?? "NA").ToString();
            Locale = (json["locale"] ?? "NA").ToString();
            Link = (json["link"] ?? "NA").ToString();
            Gender = (json["gender"] ?? "NA").ToString();
        }
        private List<FacebookPost> GetPosts()
        {
            return GetTypePosts("feed", FacebookApi.PostFields);
        }
        private List<FacebookPost> GetTaggedPosts()
        {
            return GetTypePosts("tagged", FacebookApi.PostFields);
        }
        private List<FacebookPost> GetUserCreatedPosts()
        {
            return GetTypePosts("posts", FacebookApi.PostFields);
        }
        private List<FacebookPost> GetTypePosts(string postType, string postFields)
        {
            List<FacebookPost> posts = new List<FacebookPost>();
            object result = GetField(ID + "/"  + postType, postFields);
            object deserialized = JsonConvert.DeserializeObject(result.ToString());
            JObject json = JObject.Parse(deserialized.ToString());
            JToken story = null;
            if (json.TryGetValue("data", out story))
            {
                foreach (var postItem in story)
                {
                    FacebookPost post = new FacebookPost(postItem);
                    post.From = this;
                    posts.Add(post);
                }
            }
            else
            {
                FacebookPost post = new FacebookPost();
                post.Message = "Error";
                post.Picture = "#";
                post.Link = "#";
                Posts.Add(post);
            }
            return posts;
        }
        public string GetField(string field)
        {
            string result = "Failed, please ensure you've called the 'authorization' method before attempting to retreive data.";
            if (AccessToken == null && HttpContext.Current.Session["facebookApp"] != null)
            {
                FacebookApp app = (FacebookApp)HttpContext.Current.Session[FacebookApi.SessionApp];
                AccessToken = app.AccessToken;
            }
            result = FacebookHelper.GetField(AccessToken, field);
            return result;
        }
        public string GetField(string target, string field)
        {
            string result = "Failed, please ensure you've called the 'authorization' method before attempting to retreive data.";
            if (AccessToken == null && HttpContext.Current.Session["facebookApp"] != null)
            {
                FacebookApp app = (FacebookApp)HttpContext.Current.Session[FacebookApi.SessionApp];
                AccessToken = app.AccessToken;
            }
            result = FacebookHelper.GetField(target, AccessToken, field);
            return result;
        }
        public string GetEdge(string edge)
        {
            string result = "Failed, please ensure you've called the 'authorization' method before attempting to retreive data.";
            result = FacebookHelper.GetEdge(ID, edge);
            return result;
        }
        public string GetEdge(string edge, string accessToken)
        {
            string result = "Failed, please ensure you've called the 'authorization' method before attempting to retreive data.";
            result = FacebookHelper.GetEdge(ID, edge, accessToken);
            return result;
        }
        public string GetEdgeJson(string edge)
        {
            string result = "Failed, please ensure you've called the 'authorization' method before attempting to retreive data.";
            result = FacebookHelper.GetEdgeJson(ID, edge);
            return result;
        }
        public string GetEdgeJson(string edge, string accessToken)
        {
            string result = "Failed, please ensure you've called the 'authorization' method before attempting to retreive data.";
            result = FacebookHelper.GetEdgeJson(ID, edge, accessToken);
            return result;
        }
        public string GetEdgeJson(string edge, string fields, string accessToken)
        {
            string result = "Failed, please ensure you've called the 'authorization' method before attempting to retreive data.";
            result = FacebookHelper.GetEdgeJson(ID, edge, fields, accessToken);
            return result;
        }
        #endregion
    }
}