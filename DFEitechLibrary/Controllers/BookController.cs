using System.Web.Mvc;
using DFEitechLibrary.DAL;
using DFEitechLibrary.Models;

namespace DFEitechLibrary.Controllers
{
    public class BookController : Controller
    {
        private static readonly log4net.ILog log = LogLink.GetLogger();
        MySqlButler butler = new MySqlButler();

        public ActionResult ListBooks()
        {
            return View(butler.GetAllBooks());
        }

        [ActionName("ListBooksById")]
        public ActionResult ListBooks(int id)
        {
            return View("ListBooks", butler.GetBookById(id));
        }

        [ActionName("ListBooksByTitle")]
        public ActionResult ListBooks(string title)
        {
            return View("ListBooks", butler.GetBookByName(title));
        }

        [ActionName("ListBooksByAuthL")]
        public ActionResult GetDaBooks(string authL)
        {
            return View("ListBooks", butler.GetBookByAuthL(authL));
        }

        [ActionName("ListBooksByType")]
        public ActionResult ListBooks(BookType bookType)
        {
            return View("ListBooks", butler.GetBooksByType(bookType));
        }

        [ActionName("InsertBook")]
        public ActionResult ListBooks(string title, string authL, string authF, int typeId)
        {
            butler.InsertBook(title, authL, authF, typeId);
            return View("ListBooks", butler.GetAllBooks());
        }
    }
}