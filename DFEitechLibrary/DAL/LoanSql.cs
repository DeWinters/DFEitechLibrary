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

        public Loan InsertLoan(int studentId, int bookId, DateTime loanDate, DateTime loanDue, Boolean active, Decimal accrued)
        {
            Loan loan = new Loan(); // TBC
            return loan;
        }

        public Loan DeleteLoan(int loanId)
        {
            Loan loan = new Loan(); // TBC
            return loan;
        }

        public Loan UpdateLoan(int loanId, int studentId, int bookId, DateTime loanDate, DateTime loanDue, Boolean active, Decimal accrued)
        {
            Loan loan = new Loan();
            return loan;
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