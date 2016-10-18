namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public static class FacebookApi
    {
        public static string ResourceUrl = "https://graph.facebook.com/";
        public static string UserLoginUrl = "https://www.facebook.com/dialog/oauth";
        public static string SiteUrl = "http://www.facebook.com/";
        public static string SessionApp = "facebookApp";
        public static string AuthorizeUrl = ResourceUrl + "oauth/authorize";
        public static string AccessTokenUrl = ResourceUrl + "oauth/access_token";
        /// <summary>
        /// The permissions requested when the authorization method is called.
        /// </summary>
        public static string Permission =
            "user_actions.fitness,user_actions.music,user_actions.news,user_actions.video,user_birthday,user_education_history,user_events,user_games_activity,user_hometown,user_likes,user_location,user_managed_groups,user_photos,user_posts,user_relationships,user_relationship_details,user_religion_politics,user_tagged_places,user_videos,user_website,user_work_history,read_insights,read_audience_network_insights,read_page_mailboxes,manage_pages,publish_pages,publish_actions,rsvp_event,pages_show_list,pages_manage_cta,pages_manage_instant_articles,pages_messaging,pages_messaging_phone_number";
        public static string UserFields =
            //"id,about,age_range,bio,birthday,context,cover,currency,devices,education,email,favorite_athletes,favorite_teams,first_name,gender,hometown,inspirational_people,install_type,installed,interested_in,is_shared_login,is_verified,labels,languages,last_name,link,locale,location,meeting_for,middle_name,name,name_format,page_scoped_id,political,public_key,quotes,relationship_status,religion,security_settings,shared_login_upgrade_required_by,significant_other,sports,test_group,third_party_id,timezone,token_for_business,updated_time,verified,video_upload_limits,viewer_can_send_gift,website,work";
            "id,about,age_range,bio,birthday,context,cover,currency,devices,education,email,favorite_athletes,favorite_teams,first_name,gender,hometown,inspirational_people,install_type,installed,interested_in,is_shared_login,is_verified,languages,last_name,link,locale,location,meeting_for,middle_name,name,name_format,political,public_key,quotes,relationship_status,religion,security_settings,shared_login_upgrade_required_by,significant_other,sports,test_group,third_party_id,timezone,updated_time,verified,video_upload_limits,viewer_can_send_gift,website";
        public static string PostFields =
            "id,admin_creator,application,call_to_action,caption,created_time,description,feed_targeting,from,icon,is_hidden,is_published,link,message,message_tags,name,object_id,parent_id,picture,place,privacy,properties,shares,source,status_type,story,story_tags,targeting,to,type,updated_time,with_tags";
        public static string AccountFields =
            "";
        public static string UserAlbumFields =
            "is_default,location,message,name,place,privacy";
        public static string AlbumFields =
            "id,can_upload,count,cover_photo,created_time,description,event,from,link,location,name,place,privacy,type,updated_time";
        public static string PhotoFields =
            "id,album,backdated_time,images";
    }
}