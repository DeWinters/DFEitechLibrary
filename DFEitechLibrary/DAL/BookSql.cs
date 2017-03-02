using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DFEitechLibrary.Models;

namespace DFEitechLibrary.DAL
{
    public class BookSql : MySqlLink
    {
        public BookSql()
        {
            cmd.Connection = con;
        }
        ~BookSql()
        {
            con.Close();
        }

        /************************************************************ Book Setters **/
        public List<Book> GetBookById(int id)
        {
            List<Book> matchedBooks = new List<Book>(); // TBC
            return matchedBooks;
        }

        public List<Book> GetBookByName(string name)
        {
            List<Book> matchedBooks = new List<Book>(); // TBC
            return matchedBooks;
        }

        public List<Book> GetBookByAuthF(string authF)
        {
            List<Book> matchedBooks = new List<Book>(); // TBC
            return matchedBooks;
        }

        public List<Book> GetBookByAuthL(string authL)
        {
            List<Book> matchedBooks = new List<Book>(); // TBC
            return matchedBooks;
        }
    }
}