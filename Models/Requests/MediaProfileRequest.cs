using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sabio.Web.Models.Requests
{
    public class MediaProfileRequest
    {
        [Required]
        public string MediaType { get; set; }
        [Required]
        public string ContentType { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string FilePath { get; set; }

        public int MediaThemeId { get; set; }
    }
}