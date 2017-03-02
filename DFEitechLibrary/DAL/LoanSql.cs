using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DFEitechLibrary.Models;

namespace DFEitechLibrary.DAL
{
    public class LoanSql : MySqlLink
    {
        public LoanSql()
        {
            cmd.Connection = con;
        }
        ~LoanSql()
        {
            con.Close();
        }

        /************************************************************ Loan Getters **/
        public List<Loan> GetLoansById(int loanId)
        {
            List<Loan> matchedLoans = new List<Loan>(); // TBC
            return matchedLoans;
        }

        public List<Loan> GetLoansByStudent(int studentId)
        {
            List<Loan> matchedLoans = new List<Loan>(); // TBC
            return matchedLoans;
        }

        public List<Loan> GetLoanByBookId(int bookId)
        {
            List<Loan> matchedLoans = new List<Loan>(); // TBC
            return matchedLoans;
        }

        public List<Loan> GetLoanByDate(DateTime loanDate)
        {
            List<Loan> matchedLoans = new List<Loan>(); // TBC
            return matchedLoans;
        }

        public List<Loan> GetLoanByDue(DateTime loanDue)
        {
            List<Loan> matchedLoans = new List<Loan>(); // TBC
            return matchedLoans;
        }

        public List<Loan> GetLoanByActive(Boolean active)
        {
            List<Loan> matchedLoans = new List<Loan>(); // TBC
            return matchedLoans;
        }

        public List<Loan> GetLoanByAccrued(Decimal accrued)
        {
            List<Loan> matchedLoans = new List<Loan>(); // TBC
            return matchedLoans;
        }
    }
}