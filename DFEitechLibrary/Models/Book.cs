using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DFEitechLibrary.Models
{
    public class Book
    {
        private static readonly log4net.ILog log = LogLink.GetLogger();

        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthL { get; set; }
        public string AuthF { get; set; }
        public BookType TomeType { get; set; }
    }
}