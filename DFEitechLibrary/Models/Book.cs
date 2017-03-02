using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DFEitechLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthL { get; set; }
        public string AuthF { get; set; }
        public BookType TomeType { get; set; }
    }
}