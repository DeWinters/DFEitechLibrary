using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DFEitechLibrary.Models
{
    public class Loan
    {
        int Id { get; set; }
        int StudentId { get; set; }
        int BookId { get; set; }
        DateTime LoanDate { get; set; }
        DateTime LoanDue { get; set; }
        Boolean Active { get; set; }
        Decimal Accrued { get; set; }
    }
}