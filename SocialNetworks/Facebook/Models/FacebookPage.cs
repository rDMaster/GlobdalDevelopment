using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookPage
    {
        /// <summary>
        /// The current page's ID.
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Information about the page.
        /// </summary>
        public string About { get; set; }
        /// <summary>
        /// The access token you can use to act as the current page. Only visible if you are one of the page's Admins.
        /// </summary>
        public string AccessToken { get; set; }
        /// <summary>
        /// Affiliation of this person. Applicable to pages representing people.
        /// </summary>
        public string Affiliation { get; set; }
        /// <summary>
        /// App ID for app-owned pages and app pages.
        /// </summary>
        public string AppID { get; set; }
        /// <summary>
        /// Artists and band likes. Applicable to bands.
        /// </summary>
        public string ArtistsWeLike { get; set; }
        /// <summary>
        /// Dess crode of the business. Applicable to Restaurants or Nightlife. Can be on one of Casual, Dressy or Unispecified.
        /// </summary>
        public string Attire { get; set; }
        /// <summary>
        /// The awards information of the film. Applicable to Films.
        /// </summary>
        public string Awards { get; set; }
        /// <summary>
        /// Band interests. Applicable to bands.
        /// </summary>
        public string BandInterests { get; set; }
        /// <summary>
        /// Members of the band. Applicable to Bands.
        /// </summary>
        public string BandMembers { get; set; }
        /// <summary>
        /// The best available page on facebook for the concept represented by this page. The best available page takes int account authenticity and the number of likes.
        /// </summary>
        public FacebookPage BestPage { get; set; }
        /// <summary>
        /// Biography of the band. Applicable to bands.
        /// </summary>
        public string Bio { get; set; }
        /// <summary>
        /// Birthday of the person. Applicable to pages representing people.
        /// </summary>
        public string Birthday { get; set; }
        /// <summary>
        /// Booking agent of the band. Applicable to bands.
        /// </summary>
        public string BookingAgent { get; set; }
        /// <summary>
        /// Year vehicle was built. Applicable to vehicles.
        /// </summary>
        public string Built { get; set; }
        /// <summary>
        /// The business associated with this page. Visible only with a page access token or a user access token that has admin rights on the page.
        /// </summary>
        public string Business { get; set; }
        /// <summary>
        /// Whether this page has checking functionality enabled.
        /// </summary>
        public bool CanCheckIn { get; set; }
        /// <summary>
        /// Whether the current session user can post on this page.
        /// </summary>
        public bool CanPost { get; set; }
        /// <summary>
        /// The page's category e.g Product/Service. Computers/Technology.
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// The page's sub-categories.
        /// </summary>
        public List<FacebookPageCategory> CategoryList { get; set; }
        /// <summary>
        /// The number of checkins at a place represented by a page.
        /// </summary>
        public int Checkins { get; set; }
        /// <summary>
        /// The company overview. Applicable to companies.
        /// </summary>
        public string CompanyOverview { get; set; }
        /// <summary>
        /// The mailing or contact address for this page. The field will be blank if the contact address is the same as the physical address.
        /// </summary>
        public FacebookMailingAddress ContactAddress { get; set; }
        /// <summary>
        /// If this is a page in Global Pages hierarchy, the number of people who are being directed to this page.
        /// </summary>
        public int CountryPageLikes { get; set; }
        /// <summary>
        /// Information about the page's cover photos.
        /// </summary>
        public FacebookCover Cover { get; set; }
        /// <summary>
        /// Culinary team of the business. Applicable to Restaurants or Nightlife.
        /// </summary>
        public string CulinaryTeam { get; set; }
        /// <summary>
        /// Current location of the page.
        /// </summary>
        public string CurrentLocation { get; set; }
        /// <summary>
        /// The description of the page.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// The descripion of the page in raw HTML.
        /// </summary>
        public string DescriptionHtml { get; set; }
        /// <summary>
        /// The director of the film. Applicable to films.
        /// </summary>
        public string DirectedBy { get; set; }
        /// <summary>
        /// Subtext about the page being viewed.
        /// </summary>
        public string DisplaySubtext { get; set; }
        /// <summary>
        /// Page estimated message response time displayed to user.
        /// </summary>
        public string DisplayedMessageResponseTime { get; set; }
        /// <summary>
        /// The emails listed in the 'About' section of the page.
        /// </summary>
        public List<string> Emails { get; set; }
        /// <summary>
        /// The social sentence and like count information for this page. This is the same info used for the like button.
        /// </summary>
        public FacebookEngagement Engagement { get; set; }
        /// <summary>
        /// The number of user's who like the page. For global pages this is the count for all pages across the brand.
        /// </summary>
        public int FanCount { get; set; }
        /// <summary>
        /// Features of the vehicle. Applicable to vehicles.
        /// </summary>
        public string Features { get; set; }
        /// <summary>
        /// The restaurant's food styles. Applicable to Restaurants.
        /// </summary>
        public List<string> FoodStyles { get; set; }
        /// <summary>
        /// When the company was founded. Applicable pages in the company category.
        /// </summary>
        public string Founded { get; set; }
        /// <summary>
        /// General information provided by the page.
        /// </summary>
        public string GeneralInfo { get; set; }
        /// <summary>
        /// General manager of the business. Applicable to Restaurants or Nightlife.
        /// </summary>
        public string GeneralManager { get; set; }
        /// <summary>
        /// The genre of the film. Applicable to films.
        /// </summary>
        public string Genre { get; set; }
        /// <summary>
        /// The name of the page with country codes appended for global pages. Only visible to the page admin.
        /// </summary>
        public string GlobalBandPageName { get; set; }
        /// <summary>
        /// The brand's global root ID.
        /// </summary>
        public string GlobalBrandRootID { get; set; }
        /// <summary>
        /// Indicates whether this page has added the app making the query in page tab.
        /// </summary>
        public bool HasFacebookApp { get; set; }
        /// <summary>
        /// Hometown of the band. Applicable to bands.
        /// </summary>
        public string HomeTown { get; set; }
        /// <summary>
        /// Legal information about the page publishers.
        /// </summary>
        public string Impressum { get; set; }
        /// <summary>
        /// Influences on the band. Applicable to bands.
        /// </summary>
        public string Influence { get; set; }
        /// <summary>
        /// Indicates the current instant articles review status for the page.
        /// </summary>
        public string InstantArticlesReviewStatus { get; set; }
        /// <summary>
        /// Indicates whether this location is always open/
        /// </summary>
        public bool IsAlwaysOpen { get; set; }
        /// <summary>
        /// Indicates whether the page is a community page.
        /// </summary>
        public bool IsCommunityPage { get; set; }
        /// <summary>
        /// Indicates whether the business corresponding to this page is permanently closed.
        /// </summary>
        public bool IsPermantlyClose { get; set; }
        /// <summary>
        /// Indicates whether the page is published and visible to non-admins.
        /// </summary>
        public bool IsPublished { get; set; }
        /// <summary>
        /// Indicates whether the page is unclaimed.
        /// </summary>
        public bool IsUnclaimed { get; set; }
        /// <summary>
        /// This field indicates whether the page is verified.
        /// </summary>
        public bool IsVerified { get; set; }
        /// <summary>
        /// Indicates whether the application is subscribed for real time updates from this page/
        /// </summary>
        public bool IsWebhooksSubscribed { get; set; }
        /// <summary>
        /// Last used time of this object by current viewer.
        /// </summary>
        public DateTime LastUsedTime { get; set; }
        /// <summary>
        /// Indicated whether a user has acceptes the TOS for running LeadGen ads on a page.
        /// </summary>
        public bool LeadgenTosAccepted { get; set; }
        /// <summary>
        /// The page's facebook url.
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// The location of this place. Applicable to all places.
        /// </summary>
        public FacebookLocation Location { get; set; }
        /// <summary>
        /// Members of this org. Applicable to pages representing Team Orgs.
        /// </summary>
        public string Members { get; set; }
        /// <summary>
        /// The company mission. Applicable to Companies.
        /// </summary>
        public string Mission { get; set; }
        /// <summary>
        /// MPG of the vehicle. Applicable to vehicles.
        /// </summary>
        public string MPG { get; set; }
        /// <summary>
        /// The name of the page.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The name of the page with its location and/or global brand descriptor.
        /// </summary>
        public string NameWithLocationDescriptor { get; set; }
        /// <summary>
        /// The TV network for the TV show. Applicable to TV shows.
        /// </summary>
        public string Network { get; set; }
        /// <summary>
        /// The number of people who have liked the page, since the last login. Only visible to a page admin.
        /// </summary>
        public int NewLinkCount { get; set; }
        /// <summary>
        /// Offer eligbility status, Only visible to page admin.
        /// </summary>
        public bool OfferEligable { get; set; }
        /// <summary>
        /// Parent page for this page.
        /// </summary>
        public FacebookPage ParentPage { get; set; }
        /// <summary>
        /// Parking information. Applicable to business places.
        /// </summary>
        public FacebookParking Parking { get; set; }
        /// <summary>
        /// Payment options accepted by the business. Applicable to Restaurants or Nightflite.
        /// </summary>
        public FacebookPaymentOptions PaymentOptions { get; set; }
        /// <summary>
        /// Personal Information. Applicable to pages representing people.
        /// </summary>
        public string PersonalInfo { get; set; }
        /// <summary>
        /// Personal interests. Applicable to pages representing people.
        /// </summary>
        public string PersonalInterests { get; set; }
        /// <summary>
        /// Pharmacy safety information. Applicable to Pharmaceutical companies.
        /// </summary>
        public string PharmaSafetyInfo { get; set; }
        /// <summary>
        /// Phone number provided by a page.
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// For places, the category of the place.
        /// </summary>
        public string PlaceType { get; set; }
        /// <summary>
        /// The plot outline of the film. Applicable to films.
        /// </summary>
        public string PlotOutline { get; set; }
        /// <summary>
        /// Press information of the band. Applicable to bands.
        /// </summary>
        public string PressContact { get; set; }
        /// <summary>
        /// Price range of the business. Applicable to Restaurants or Nightlife.
        /// </summary>
        public string PriceRange { get; set; }
        /// <summary>
        /// The productor of the film. Applicable to films.
        /// </summary>
        public string ProducedBy { get; set; }
        /// <summary>
        /// The products of this company. Applicable to companies.
        /// </summary>
        public string Products { get; set; }
        /// <summary>
        /// Reason why a post isn't eligble for boosting. Only visible to page admins.
        /// </summary>
        public bool PromotionEligable { get; set; }
        /// <summary>
        /// Reason, for which boosted posts are not eligble. Only visible to page admin.
        /// </summary>
        public string PromotionIneligibleReason { get; set; }
        /// <summary>
        /// Public transit to the business. Applicable to Restaurants or Nightlife.
        /// </summary>
        public string PublicTransit { get; set; }
        /// <summary>
        /// Messenger page sope id associated with page and a user using account_link_token.
        /// </summary>
        public int Recipient { get; set; }
        /// <summary>
        /// Record label of the band. Applicable to bands.
        /// </summary>
        public string RecordLabel { get; set; }
        /// <summary>
        /// The film's release day. Applicable to films.
        /// </summary>
        public string ReleaseDate { get; set; }
        /// <summary>
        /// Services the restaurant provides. Aplicable to restaurants.
        /// </summary>
        public FacebookRestaurantServices RestaurantServices { get; set; }
        /// <summary>
        /// The restaurant's specialties. Applicable to restaurants.
        /// </summary>
        public FacebookRestaurantSpecialties RestaurantSpecialties { get; set; }
        /// <summary>
        /// The air schedule of the TV show. Applicable to TV shows.
        /// </summary>
        public string Schedule { get; set; }
        /// <summary>
        /// The screenwriter of the film. Applicable to films.
        /// </summary>
        public string ScreenplayBy { get; set; }
        /// <summary>
        /// The seasion information of the TV show. Applicable to TV shows.
        /// </summary>
        public string Season { get; set; }
        /// <summary>
        /// The page address, if any, ins a simple single line format.
        /// </summary>
        public string SingleLineAddress { get; set; }
        /// <summary>
        /// The cast of the film. Applicable to a film.
        /// </summary>
        public string Starring { get; set; }
        /// <summary>
        /// Information about when the entity represented by the page was started.
        /// </summary>
        public FacebookPageStartDate StartInfo { get; set; }
        /// <summary>
        /// Location page's store location descriptor.
        /// </summary>
        public string StoreLocationDescriptor { get; set; }
        /// <summary>
        /// Unique store number for this location page.
        /// </summary>
        public string StoreNumber { get; set; }
        /// <summary>
        /// The studio for the film production. Applicable for films.
        /// </summary>
        public string Studio { get; set; }
        /// <summary>
        /// Indicates whether this page supports instant articles.
        /// </summary>
        public bool SupportsInstantArticles { get; set; }
        /// <summary>
        /// The number of people talking about this page.
        /// </summary>
        public int TalkingAboutCount { get; set; }
        /// <summary>
        /// Unread message count for the page. Only visible to a page admin.
        /// </summary>
        public int UnreadMessageCount { get; set; }
        /// <summary>
        /// Number of unread notifications. Only visible to a page admin.
        /// </summary>
        public int UnreadNotifCount { get; set; }
        /// <summary>
        /// Unseen messaeges count for the page. Only visible to a page admin.
        /// </summary>
        public int UnseenMessageCount { get; set; }
        /// <summary>
        /// The alias of the page.
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Whether this page is verified and in what color.
        /// </summary>
        public string VerificationStatus { get; set; }
        /// <summary>
        /// Voip info.
        /// </summary>
        public FacebookVoipInfo VoipInfo { get; set; }
        /// <summary>
        /// The URL of the page's website.
        /// </summary>
        public string Website { get; set; }
        /// <summary>
        /// The number of visits to this page's location. If the page setting show pam, check-ins and start settings on page is disabled, then this value will also be disabled.
        /// </summary>
        public int WereHereCount { get; set; }
        /// <summary>
        /// The writer of the TV show. Applicable to TV shows.
        /// </summary>
        public string WrittenBy { get; set; }
        public FacebookPage(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            ID = (obj["id"] ?? "NA").ToString();
            About = (obj["about"] ?? "NA").ToString();
            AccessToken = (obj["access_token"] ?? "NA").ToString();
            Affiliation = (obj["affiliation"] ?? "NA").ToString();
            AppID = (obj["app_id"] ?? "NA").ToString();
            ArtistsWeLike = (obj["artists_we_like"] ?? "NA").ToString();
            Attire = (obj["attire"] ?? "NA").ToString();
            Awards = (obj["awards"] ?? "NA").ToString();
            BandInterests = (obj["band_interests"] ?? "NA").ToString();
            BandMembers = (obj["band_members"] ?? "NA").ToString();
            if(obj["best_page"] != null)
                BestPage = new FacebookPage(obj["best_page"]);
            Bio = (obj["bio"] ?? "NA").ToString();
            Birthday = (obj["birthday"] ?? "NA").ToString();
            BookingAgent = (obj["booking_agent"] ?? "NA").ToString();
            Built = (obj["built"] ?? "NA").ToString();
            CanCheckIn = bool.Parse((obj["can_checkin"] ?? "false").ToString());
            CanPost = bool.Parse((obj["can_post"] ?? "false").ToString());
            Category = (obj["category"] ?? "NA").ToString();
            if (obj["category_list"] != null)
            {
                CategoryList = new List<FacebookPageCategory>();
                foreach (var category in obj["category_list"])
                {
                    FacebookPageCategory ct = new FacebookPageCategory(category);
                    CategoryList.Add(ct);
                }
            }
            Checkins = int.Parse((obj["checkins"] ?? "0").ToString());
            CompanyOverview = (obj["company_overview"] ?? "NA").ToString();
            if (obj["contact_address"] != null)
                ContactAddress = new FacebookMailingAddress(obj["contact_address"]);
            CountryPageLikes = int.Parse((obj["country_page_likes"] ?? "0").ToString());
            if (obj["cover"] != null)
                Cover = new FacebookCover(obj["cover"]);
            CulinaryTeam = (obj["culinary_team"] ?? "NA").ToString();
            CurrentLocation = (obj["current_location"] ?? "NA").ToString();
            Description = (obj["description"] ?? "NA").ToString();
            DescriptionHtml = (obj["description_html"] ?? "NA").ToString();
            DirectedBy = (obj["directed_by"] ?? "NA").ToString();
            DisplaySubtext = (obj["display_subtext"] ?? "NA").ToString();
            DisplayedMessageResponseTime = (obj["display_message_response_time"] ?? "NA").ToString();
            if (obj["emails"] != null)
            {
                Emails = new List<string>();
                foreach (var item in Emails)
                {
                    Emails.Add(item);
                }
            }
            if (obj["engagement"] != null)
                Engagement = new FacebookEngagement(obj["engagement"]);
            FanCount = int.Parse((obj["fan_count"] ?? "0").ToString());
            Features = (obj["features"] ?? "NA").ToString();
            if(obj["food_styles"] != null)
            {
                FoodStyles = new List<string>();
                foreach(var tk in obj["food_styles"])
                {
                    FoodStyles.Add(tk.ToString());
                }
            }
            Founded = (obj["founded"] ?? "NA").ToString();
            GeneralInfo = (obj["general_info"] ?? "NA").ToString();
            GeneralManager = (obj["general_manager"] ?? "NA").ToString();
            Genre = (obj["genre"] ?? "NA").ToString();
            GlobalBandPageName = (obj["global_brand_page_name"] ?? "NA").ToString();
            GlobalBrandRootID = (obj["global_brand_root_id"] ?? "NA").ToString();
            HasFacebookApp = bool.Parse((obj["has_added_app"] ?? "false").ToString());
            HomeTown = (obj["hometown"] ?? "NA").ToString();
            Impressum = (obj["impressum"] ?? "NA").ToString();
            Influence = (obj["influences"] ?? "NA").ToString();
            InstantArticlesReviewStatus = (obj["instant_articles_review_status"] ?? "NA").ToString();


            Name = (obj["name"] ?? "NA").ToString();
        }
    }
}