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

        public Book InsertBook(string title, string authF, string authL, BookType type)
        {
            Book book = new Book(); //TBC
            return book;
        }

        public Book DeleteBook(int bookId)
        {
            Book book = new Book(); //TBC
            return book;
        }

        public Book UpdateBook(int bookId, string authF, string authL, BookType type)
        {
            Book book = new Book(); //TBC
            return book;
        }

        /************************************************************ Book Setters **/
        public List<Book> GetBookById(int id)
        {
            List<Book> matchedBooks = new List<Book>(); // TBC
            return matchedBooks;
        }

        public List<Book> GetBookByName(string title)
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