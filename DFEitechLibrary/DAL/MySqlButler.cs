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
        public Student InsertStudent(string fname, string lname)
        {
            return studentSql.InsertStudent(fname, lname);
        }

        public Student DeleteStudent(int id)
        {
            return studentSql.DeleteStudent(id);
        }

        public Student UpdateStudent(int id, string fname, string lname)
        {
            return studentSql.UpdateStudent(id, fname, lname);
        }

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
        public Book InsertBook(string title, string authF, string authL, BookType type, TypeSql typeSql)
        {
            return bookSql.InsertBook(title, authF, authL, type, typeSql);
        }

        public Book DeleteBook(int bookId, TypeSql typeSql)
        {
            return bookSql.DeleteBook(bookId, typeSql);
        }

        public Book UpdateBook(int bookId, string authF, string authL, BookType type, TypeSql typeSql)
        {
            return bookSql.UpdateBook(bookId, authF, authL, type, typeSql);
        }

        public List<Book> GetBookById(int id, TypeSql typeSql)
        {
            return bookSql.GetBookById(id, typeSql);
        }

        public List<Book> GetBookByName(string title, TypeSql typeSql)
        {
            return bookSql.GetBookByName(title, typeSql);
        }

        public List<Book> GetBookByAuthF(string authF, TypeSql typeSql)
        {
            return bookSql.GetBookByAuthF(authF, typeSql);
        }

        public List<Book> GetBookAuthL(string authL, TypeSql typeSql)
        {
            return bookSql.GetBookByAuthL(authL, typeSql);
        }

        /************************************************************ Type Passers *****/
        public BookType InsertBookType(string name, TimeSpan duration, Decimal penalty)
        {
            return typeSql.InsertBookType(name, duration, penalty);
        }

        public BookType DeleteBookType(int id)
        {
            return typeSql.DeleteBookType(id);
        }

        public BookType UpdateBookType(int id, TimeSpan duration, string typeName, Decimal penalty)
        {
            return typeSql.UpdateBookType(id, typeName, duration, penalty);
        }

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
        public Loan InsertLoan(int studentId, int bookId, DateTime loanDate, DateTime loanDue, Boolean active, Decimal accrued)
        {
            return loanSql.InsertLoan(studentId, bookId, loanDate, loanDue, active, accrued);
        }

        public Loan DeleteLoan(int loanId)
        {
            return loanSql.DeleteLoan(loanId);
        }

        public Loan UpdateLoan(int loanId, int studentId, int bookId, DateTime loanDate, DateTime loanDue, Boolean active, Decimal accrued)
        {
            return loanSql.UpdateLoan(loanId, studentId, bookId, loanDate, loanDue, active, accrued);
        }

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