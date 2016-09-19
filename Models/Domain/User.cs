using Sabio.Web.Domain;
using Sabio.Web.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sabio.Web.Models
{
    public class User : BaseUser
    {

        // cap at hte start


        public string ProfileName { get; set; }

        public string ProfileEmail { get; set; }

        public string ProfilePhone { get; set; }

        public string ProfileMobile { get; set; }

        public string ProfileWebsite { get; set; }

        public string ProfileAddress { get; set; }

        public string ProfileCompany { get; set; }

        public string UserId { get; set; }

        public int MediaId { get; set; }

        public int ThemeMediaId { get; set; }

        public string ProfileLastName { get; set; }

        public int ProfileViewCount { get; set; }

        public int ConnectionsCount { get; set; }

        public int GroupsCount { get; set; }

        public Medias Avatar { get; set; }

        public Medias Theme { get; set; }

        public bool IsConnected { get; set; }

        public List<Tags> Tags { get; set; }

        public UserEvents Attendance { get; set; }

        public EventInvites EventInvites { get; set; }

        public Connections Connection{ get; set; }

        public List<UserTag> UserTags { get; set; }

        public Location Location { get; set; }

        public string Tagline { get; set; }

        public string CardTemplate { get; set; }

        public List<UserExternalAccounts> ExternalAccounts { get; set; }

        public UserMini UserMini
        {
            get
            {
                UserMini organizer = new UserMini();
                organizer.UserId = UserId;
                organizer.profileName = ProfileName;
                organizer.profileLastName = ProfileLastName;
                organizer.Avatar = Avatar;

                return organizer;
            }
        }
    }
}