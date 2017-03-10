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
        public MySqlButler mySqlButler = new MySqlButler();


        public ActionResult ListStudents()
        {
            return View(mySqlButler.studentSql.GetAllStudents());
        }

        public ActionResult InsertStudent(string nameL, string nameF)
        {
            return View(mySqlButler.studentSql.InsertStudent(nameL,nameF));
        }
    }
}