using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DFEitechLibrary.Models
{
    public class BookType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public Decimal Penalty { get; set; }
    }
}