using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DFEitechLibrary.Models;

namespace DFEitechLibrary.DAL
{
    public class MySqlButler : MySqlLink
    {
        public MySqlButler()
        {
            cmd.Connection = con;
        }
        ~MySqlButler()
        {
            con.Close();
        }

        LoanSql loanSql = new LoanSql();
        BookSql bookSql = new BookSql();
        TypeSql typeSql = new TypeSql();
        StudentSql studentSql = new StudentSql();

        /************************************************************ Student Passers **/
        public List<Student> GetStudentsById(int id)
        {
            return studentSql.GetStudentsById(id);
        }

        public List<Student> GetStudentsByFname(string fname)
        {
            return studentSql.GetStudentsByFname(fname);
        }

        public List<Student> GetStudentsByLname(string lname)
        {
            return studentSql.GetStudentsByLname(lname);
        }

        /************************************************************ Book Passers *****/
        public List<Book> GetBookById(int id)
        {
            return bookSql.GetBookById(id);
        }

        public List<Book> GetBookByName(string name)
        {
            return bookSql.GetBookByName(name);
        }

        public List<Book> GetBookByAuthF(string authF)
        {
            return bookSql.GetBookByAuthF(authF);
        }

        public List<Book> GetBookAuthL(string authL)
        {
            return bookSql.GetBookByAuthL(authL);
        }

        /************************************************************ Type Passers *****/
        public List<BookType> GetTypeById(int id)
        {
            return typeSql.GetTypeById(id);
        }

        public List<BookType> GetTypeByName(string name)
        {
            return typeSql.GetTypeByName(name);
        }

        public List<BookType> GetTypeByDuration(int durationId)
        {
            return typeSql.GetTypeByDuration(durationId);
        }

        public List<BookType> GetTypeByPenalty(Decimal penalty)
        {
            return typeSql.GetTypeByPenalty(penalty);
        }

        /************************************************************ Loan Passers *****/
        public List<Loan> GetLoanById(int loanId)
        {
            return loanSql.GetLoansById(loanId);
        }

        public List<Loan> GetLoansByStudent(int studentId)
        {
            return loanSql.GetLoansByStudent(studentId);
        }

        public List<Loan> GetLoanByBookId(int bookId)
        {
            return loanSql.GetLoanByBookId(bookId);
        }

        public List<Loan> GetLoanByDate(DateTime loanDate)
        {
            return loanSql.GetLoanByDate(loanDate);
        }

        public List<Loan> GetLoanByDue(DateTime loanDue)
        {
            return loanSql.GetLoanByDue(loanDue);
        }

        public List<Loan> GetLoanByActive(Boolean active)
        {
            return loanSql.GetLoanByActive(active);
        }

        public List<Loan> GetLoanByAccrued(Decimal accrued)
        {
            return loanSql.GetLoanByAccrued(accrued);
        }
    }
}