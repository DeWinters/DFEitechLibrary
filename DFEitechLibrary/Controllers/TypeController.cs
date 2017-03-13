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

        public ActionResult ListTypes()
        {
            return View(butler.GetAllTypes());
        }

        [ActionName("ListTypesById")]
        public ActionResult ListTypes(int id)
        {
            return View("ListTypes", butler.GetTypeById(id));
        }

        [ActionName("ListTypesByName")]
        public ActionResult ListTypes(string name)
        {
            return View("ListTypes", butler.GetTypeByName(name));
        }

        [ActionName("ListTypesByDuration")]
        public ActionResult ListTypes(TimeSpan duration)
        {
            return View("ListTypes", butler.GetTypeByDuration(duration));
        }

        [ActionName("ListTypesByPenalty")]
        public ActionResult ListTypes(Decimal penalty)
        {
            return View("ListTypes", butler.GetTypeByPenalty(penalty));
        }

        [HttpPost]
        [ActionName("InsertType")]
        public ActionResult ListTypes(string name, TimeSpan duration, Decimal penalty)
        {
            butler.InsertBookType(name, duration, penalty);
            return View("ListTypes", butler.GetAllTypes());
        }

        public ActionResult LoadType(int id)
        {
            return View("RefinedTypes", id);
        }

        
        public ActionResult DeleteTypes(int id)
        {
            return View("ListTypes", butler.DeleteBookType(id));
        }

        //[ActionName("RefinedTypesById")]
        public ActionResult RefinedTypes(int id)
        {
            return View(butler.FindTypeById(id));  
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