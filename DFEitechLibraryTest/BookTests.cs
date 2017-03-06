using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DFEitechLibrary.DAL;
using DFEitechLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DFEitechLibraryTest
{
    [TestClass]
    class BookTests
    {
        [TestMethod]
        public void InsertBookTest1()
        {
            string title ="InsertBookTest1, title, happy_path, 1";
            string authF = "InsertBookTest1, authF, happy_path, 1";
            string authL = "InsertBookTest1, authL, happy_path, 1";
            TimeSpan duration = new TimeSpan(11, 11, 11);
            BookType type = new BookType() { Id = 1, Name = "TypeDummy1", Duration = duration, Penalty = 55.55m };
            TypeSql typeSql = new TypeSql();

            BookSql bookSql = new BookSql();
            Console.WriteLine(bookSql.InsertBook(title, authF, authL, type, typeSql));
        }

        [TestMethod]
        public void FindBookByIdTest1()
        {
            int bookId = 1;
            TypeSql typeSql = new TypeSql();

            BookSql bookSql = new BookSql();
            Console.WriteLine(bookSql.FindBookById(bookId, typeSql));
        }

        [TestMethod]
        public void GetBookByIdTest1()
        {
            int bookId = 1;
            TypeSql typeSql = new TypeSql();

            BookSql bookSql = new BookSql();
            Console.WriteLine(bookSql.GetBookById(bookId, typeSql));
        }

        [TestMethod]
        public void GetBookByNameTest1()
        {
            string title ="InsertBookTest1, title, happy_path, 1";
            TypeSql typeSql = new TypeSql();

            BookSql bookSql = new BookSql();
            Console.WriteLine(bookSql.GetBookByName(title, typeSql));
        }

        [TestMethod]
        public void GetBookByAuthFTest1()
        {
            string authF = "InsertBookTest1, authF, happy_path, 1";
            TypeSql typeSql = new TypeSql();

            BookSql bookSql = new BookSql();
            Console.WriteLine(bookSql.GetBookByAuthF(authF, typeSql));
        }

        [TestMethod]
        public void GetBookByAuthLTest1()
        {
            string authL = "InsertBookTest1, authF, happy_path, 1";
            TypeSql typeSql = new TypeSql();

            BookSql bookSql = new BookSql();
            Console.WriteLine(bookSql.GetBookByAuthL(authL, typeSql));
        }

        [TestMethod]
        public void UpdateBookTest1()
        {
            int bookId = 1;
            string title = "UpdateBookTest1, title, happy_path, 1";
            string authF = "UpdateBookTest1, authF, happy_path, 1";
            string authL = "UpdateBookTest1, authL, happy_path, 1";

            TimeSpan duration = new TimeSpan(6, 6, 6);
            BookType type = new BookType() { Id = 1, Name = "TypeDummy2", Duration = duration, Penalty = 66.66m };

            TypeSql typeSql = new TypeSql();
            BookSql bookSql = new BookSql();
            Console.WriteLine(bookSql.UpdateBook(bookId, title, authF, authL, type, typeSql));
        }


        [TestMethod]
        public void DeleteBookTest1()
        {
            int bookId = 1;
            TypeSql typeSql = new TypeSql();

            BookSql bookSql = new BookSql();
            Console.WriteLine(bookSql.DeleteBook(bookId, typeSql));
        }
    }
}
