using Sabio.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sabio.Web.Domain
{
    public class ConnectionInvites
    {
        public int ConnectionRequestId { get; set; }

        public string RequesterId { get; set; }

        public string RequestedId { get; set; }

        public int Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public User RequesterInfo { get; set; } //person1

        public User RequestedInfo { get; set; } //person2

    }
}