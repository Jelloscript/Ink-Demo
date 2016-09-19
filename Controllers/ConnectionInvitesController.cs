using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sabio.Web.Controllers
{
    [RoutePrefix("ConnectionInvites")]
    public class ConnectionInvitesController : BaseController
    {
        // GET: ConnectionInvites
        public ActionResult Sent()
        {
            return View();
        }
        public ActionResult Received()
        {
            return View();
        }
    }
}