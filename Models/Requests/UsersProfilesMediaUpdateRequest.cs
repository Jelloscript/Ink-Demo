using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sabio.Web.Models.Requests
{
    public class UsersProfilesMediaUpdateRequest
    {
        public string UserId { get; set; }
        [Required]
        public int MediaId { get; set; }

    }
}