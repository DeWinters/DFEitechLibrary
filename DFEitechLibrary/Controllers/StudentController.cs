using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DFEitechLibrary.DAL;

namespace DFEitechLibrary.Controllers
{
    public class StudentController : Controller
    {
        private static readonly log4net.ILog log = LogLink.GetLogger();

        public ActionResult ListStudents()
        {
            return View();
        }

        public ActionResult _InsertStudent(int id, string nameL, string nameF)
        {
            return View();
        }
    }
}