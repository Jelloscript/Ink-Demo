using Sabio.Web.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sabio.Web.Models.Requests
{
    public class UsersProfilesRequest
    {
        [Required]
        public string profileName { get; set; }
        [Required]
        public string profileLastName { get; set; }

        public string profileEmail { get; set; }
        [Required]
        public string profilePhone { get; set; }

        public string profileMobile { get; set; }

        public string profileWebsite { get; set; }

        public string profileAddress { get; set; }

        public string profileCompany { get; set; }

        public string userId { get; set; }

        public string Tagline { get; set; }

        public int[] profileTags { get; set; }

        public UserExternalAccounts[] ExternalAccounts { get; set; }
    }
}