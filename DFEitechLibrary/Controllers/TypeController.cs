using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DFEitechLibrary.DAL;

namespace DFEitechLibrary.Controllers
{
    public class TypeController : Controller
    {
        private static readonly log4net.ILog log = LogLink.GetLogger();
        MySqlButler butler = new MySqlButler();

        [HttpGet]
        public ActionResult ListTypes()
        {
            return View(butler.GetAllTypes());
        }
        [ActionName("ListTypesById")]
        public ActionResult ListTypes(int id)
        {
            return View("ListTypes", butler.GetTypeById(id));
        }
        [ActionName("TypesByName")]
        public ActionResult ListTypes(string name)
        {
            return View(butler.GetTypeByName(name));
        }
        [ActionName("TypesByDuration")]
        public ActionResult ListTypes(TimeSpan duration)
        {
            return View(butler.GetTypeByDuration(duration));
        }
        [ActionName("TypesByPenalty")]
        public ActionResult ListTypes(Decimal penalty)
        {
            return View(butler.GetTypeByPenalty(penalty));
        }

        [HttpPost]
        [ActionName("InsertType")]
        public ActionResult ListTypes(string name, TimeSpan duration, Decimal penalty)
        {
            butler.InsertBookType(name, duration, penalty);
            return View(butler.GetAllTypes());
        }


        public ActionResult RefinedTypes(int id, string name, TimeSpan duration, Decimal penalty)
        {
            if (id != 0 && name == null && duration == null && penalty == 0)
            {
                return View(butler.GetTypeById(id));
            }
            else if (id == 0 && name != null && duration==null && penalty == 0)
            {
                return View(butler.GetTypeByName(name));
            }
            else if (id == 0 && name == null && duration != null && penalty == 0)
            {
                return View(butler.GetTypeByDuration(duration));
            }
            else if (id == 0 && name == null && duration == null && penalty != 0)
            {
                return View(butler.GetTypeByPenalty(penalty));
            }
            else
            {
                return View(butler.GetAllTypes());
            }
        }




        public ActionResult _TypeForm(int id)
        {
            if(id != 0)
            {
                return PartialView(butler.FindTypeById(id));
            }
            else
            {
                return PartialView(butler.FailedTypeQuery());
            }
            
        }

        public ActionResult _SearchTypes()
        {
            return PartialView(butler.GetAllTypes());
        }

    }
}