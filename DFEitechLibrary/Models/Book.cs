using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DFEitechLibrary.Models
{
    public class Book
    {
        int Id { get; set; }
        string Title { get; set; }
        string AuthL { get; set; }
        string AuthF { get; set; }
        BookType TomeType { get; set; }
    }
}