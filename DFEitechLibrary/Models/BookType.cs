using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DFEitechLibrary.Models
{
    public class BookType
    {
        int Id { get; set; }
        string Name { get; set; }
        TimeSpan Duration { get; set; }
        Decimal Penalty { get; set; }
    }
}