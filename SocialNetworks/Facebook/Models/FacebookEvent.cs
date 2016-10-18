using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookEvent
    {
        /// <summary>
        /// The event ID.
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Number of people attending the event.
        /// </summary>
        public int AttendingCount { get; set; }
        /// <summary>
        /// Can guests invite friends?
        /// </summary>
        public bool CanQuestsInvite { get; set; }
        /// <summary>
        /// The category of the event.
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Cover photo.
        /// </summary>
        public FacebookCover CoverPhoto { get; set; }
        /// <summary>
        /// Number people who declined the event.
        /// </summary>
        public int DeclinedCount { get; set; }
        /// <summary>
        /// The event description.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// End time, if one has beens set.
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        /// Can see guest list.
        /// </summary>
        public bool GuestListEnabled { get; set; }
        /// <summary>
        /// Number of people interested in the event.
        /// </summary>
        public int InterestedCount { get; set; }
        /// <summary>
        /// Whether or not the event has been marked as canceled.
        /// </summary>
        public bool IsCanceled { get; set; }
        /// <summary>
        /// Whether event is created by page or not.
        /// </summary>
        public bool IsPageOwned { get; set; }
        /// <summary>
        /// Whether the viewer is admin or not.
        /// </summary>
        public bool IsViewerAdmin { get; set; }
        /// <summary>
        /// Number of people who maybe going to the event.
        /// </summary>
        public int MaybeCount { get; set; }
        /// <summary>
        /// Event Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The number of people who did not reply to the event.
        /// </summary>
        public int NoreplyCount { get; set; }
        /// <summary>
        /// The person that created the event.
        /// </summary>
        public FacebookUser Owner { get; set; }
        /// <summary>
        /// The group the event belongs to.
        /// </summary>
        public FacebookGroup ParentGroup { get; set; }
        /// <summary>
        /// Event place information.
        /// </summary>
        public FacebookPlace Place { get; set; }
        /// <summary>
        /// Start time.
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// The link users can visit to buy a ticket to this event.
        /// </summary>
        public string TicketUrl { get; set; }
        /// <summary>
        /// Time zone.
        /// </summary>
        public string Timezone { get; set; }
        /// <summary>
        /// The type of the event.
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Last update time.
        /// </summary>
        public DateTime UpdatedTime { get; set; }
        public FacebookEvent(JToken token)
        {

        }
    }
}