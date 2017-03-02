using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DFEitechLibrary.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult ListBooks()
        {
            return View();
        }
    }
}