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