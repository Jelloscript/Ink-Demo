﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sabio.Web.Controllers
{
    public class MyProfileController : BaseController
    {
        // GET: MyProfile
        public ActionResult Index()
        {
            return View();
        }
    }
}