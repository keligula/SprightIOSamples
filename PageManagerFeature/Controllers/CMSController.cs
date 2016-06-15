﻿using Sabio.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sabio.Web.Controllers.CMS
{
    [RoutePrefix("cms")]
    public class CMSController : BaseController
    {

        // GET: CMS List
        [Route]
        public ActionResult Index_ng()
        {
            return View();
        }
    }
}