﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Intercambealo.Controllers
{
    public class PublicController : Controller
    {
        public ActionResult Principal()
        {
            return View();
        }
    }
}