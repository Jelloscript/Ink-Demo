using Sabio.Web.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sabio.Web.Domain
{
    public class Medias
    {

        public int MediasTableId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public MediaType MediaType { get; set; }

        public string ContentType { get; set; }

        public string UserId { get; set; }

        public string FilePath { get; set; }

        public string FullUrl
        {
            get
            {
                if(MediaType == MediaType.LinkedIn)
                {
                    return this.FilePath;
                }
                else
                {
                    return ConfigService.uploadFileS3BaseUrl + this.FilePath;
                }

            }
        }
    }
}