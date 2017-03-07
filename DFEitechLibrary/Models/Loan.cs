using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DFEitechLibrary.Models
{
    public class Loan
    {
        private static readonly log4net.ILog log = LogLink.GetLogger();

        public int Id { get; set; }
        public int StudentId { get; set; }
        public int BookId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime LoanDue { get; set; }
        public Boolean Active { get; set; }
        public Decimal Accrued { get; set; }
    }
}