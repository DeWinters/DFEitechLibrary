using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DFEitechLibrary.Models;
using DFEitechLibrary.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DFEitechLibraryTest
{
    [TestClass]
    class LoanTests
    {
        [TestMethod]
        public void InsertLoanTest1()
        {
            int studentId = 1;
            int bookId = 1; 
            DateTime loanDate = new DateTime(2001, 1, 1);
            DateTime loanDue = new DateTime(2001, 1, 2);
            Boolean active = true;
            Decimal accrued = 11.11m;

            LoanSql loanSql = new LoanSql();
            Console.WriteLine(loanSql.InsertLoan(studentId, bookId, loanDate, loanDue, active, accrued));
        }

        [TestMethod]
        public void FindLoanById()
        {
            int loanId = 1;

            LoanSql loanSql = new LoanSql();
            Console.WriteLine(loanSql.FindLoanById(loanId));
        }

        [TestMethod]
        public void GetLoansById()
        {
            int loanId = 1;

            LoanSql loanSql = new LoanSql();
            Console.WriteLine(loanSql.GetLoansById(loanId));
        }

        [TestMethod]
        public void GetLoansByStudent()
        {
            int studentId = 1;

            LoanSql loanSql = new LoanSql();
            Console.WriteLine(loanSql.GetLoansByStudent(studentId));
        }

        [TestMethod]
        public void GetLoanByBookId()
        {
            int bookId = 1;

            LoanSql loanSql = new LoanSql();
            Console.WriteLine(loanSql.GetLoanByBookId(bookId));
        }

        [TestMethod]
        public void GetLoanByDate()
        {
            DateTime loanDate = new DateTime(2001, 1, 1);

            LoanSql loanSql = new LoanSql();
            Console.WriteLine(loanSql.GetLoanByDate(loanDate));
        }

        [TestMethod]
        public void GetLoanByDue()
        {
            DateTime loanDue = new DateTime(2001, 1, 2);

            LoanSql loanSql = new LoanSql();
            Console.WriteLine(loanSql.GetLoanByDue(loanDue));
        }

        [TestMethod]
        public void GetLoanByActive()
        {
            Boolean active = true;

            LoanSql loanSql = new LoanSql();
            Console.WriteLine(loanSql.GetLoanByActive(active));
        }

        [TestMethod]
        public void GetLoanByAccrued()
        {
            Decimal accrued = 11.11m;

            LoanSql loanSql = new LoanSql();
            Console.WriteLine(loanSql.GetLoanByAccrued(accrued));
        }


        [TestMethod]
        public void UpdateLoan()
        {
            int loanId = 1;
            int studentId = 1;
            int bookId = 1;
            DateTime loanDate = new DateTime(2002, 2, 2);
            DateTime loanDue = new DateTime(2002, 2, 3);
            Boolean active = true;
            Decimal accrued = 22.22m;

            LoanSql loanSql = new LoanSql();
            Console.WriteLine(loanSql.UpdateLoan(loanId, studentId, bookId, loanDate, loanDue, active, accrued));
        }

        [TestMethod]
        public void DeleteLoanTest1()
        {
            int loanId = 1;

            LoanSql loanSql = new LoanSql();
            Console.WriteLine(loanSql.DeleteLoan(loanId));
        }

    }
}
