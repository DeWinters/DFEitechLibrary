using System;
using System.Web.Mvc;
using DFEitechLibrary.DAL;

namespace DFEitechLibrary.Controllers
{
    public class LoanController : Controller
    {
        private static readonly log4net.ILog log = LogLink.GetLogger();
        MySqlButler butler = new MySqlButler();

        public ActionResult ListLoans()
        {
            return View(butler.GetAllLoans());
        }

        [HttpPost]
        [ActionName("InsertLoan")]        
        public ActionResult ListLoans(int Id, int Tome)
        {
            butler.InsertLoan(Id, Tome);
            return View("ListLoans", butler.GetAllLoans());
        }
        [ActionName("ListLoansById")]
        public ActionResult ListLoans(int Id)
        {
            return View("ListLoans", butler.GetLoanById(Id));
        }
        [ActionName("ListLoansByActive")]
        public ActionResult ListLoans(Boolean active)
        {
            return View("ListLoans", butler.GetLoanByActive(active));
        }

        public ActionResult ListActives()
        {
            return View();
        }

        public ActionResult _LoanForm(int Id)
        {
            return PartialView(butler.FindLoanById(Id));
        }

    }
}