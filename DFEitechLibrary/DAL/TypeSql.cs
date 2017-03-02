using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DFEitechLibrary.Models;

namespace DFEitechLibrary.DAL
{
    public class TypeSql : MySqlLink
    {
        public TypeSql()
        {
            cmd.Connection = con;
        }
        ~TypeSql()
        {
            con.Close();
        }

        public BookType InsertBookType(string name, TimeSpan duration, Decimal penalty)
        {
            BookType bookType = new BookType(); // TBC
            return bookType;
        }

        public BookType DeleteBookType(int id)
        {
            BookType bookType = new BookType(); // TBC
            return bookType;
        }

        public BookType UpdateBookType(int id, TimeSpan duration, Decimal penalty)
        {
            BookType bookType = new BookType(); // TBC
            return bookType;
        }

        /************************************************************ Type Getters **/
        public List<BookType> GetTypeById(int id)
        {
            List<BookType> matchedTypes = new List<BookType>(); // TBC
            return matchedTypes;
        }

        public List<BookType> GetTypeByName(string name)
        {
            List<BookType> matchedTypes = new List<BookType>(); // TBC
            return matchedTypes;
        }

        public List<BookType> GetTypeByDuration(int durationId)
        {
            List<BookType> matchedTypes = new List<BookType>(); // TBC
            return matchedTypes;
        }

        public List<BookType> GetTypeByPenalty(Decimal penalty)
        {
            List<BookType> matchedTypes = new List<BookType>(); // TBC
            return matchedTypes;
        }
    }
}