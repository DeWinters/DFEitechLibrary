﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DFEitechLibrary.Controllers
{
    public class BookController : Controller
    {
        private static readonly log4net.ILog log = LogLink.GetLogger();

        public ActionResult ListBooks()
        {
            return View();
        }
    }
}