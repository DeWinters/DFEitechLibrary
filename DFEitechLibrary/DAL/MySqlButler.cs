using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DFEitechLibrary.Models;

namespace DFEitechLibrary.DAL
{
    public class MySqlButler : MySqlLink
    {
        private static readonly log4net.ILog log = LogLink.GetLogger();

        public MySqlButler()
        {
            cmd.Connection = con;            
        }
        ~MySqlButler()
        {
            con.Close();
        }

        public LoanSql loanSql = new LoanSql();
        public BookSql bookSql = new BookSql();
        public TypeSql typeSql = new TypeSql();
        public StudentSql studentSql = new StudentSql();

        /************************************************************ Student Passers **/
        public Student InsertStudent(string fname, string lname)
        {
            try
            {
                log.Debug("Student_" + fname + "-" + lname + "_Inserted");
                return studentSql.InsertStudent(fname, lname);
            }
            catch(Exception e)
            {
                log.Error("Insert Student(fname, lname) Butler Failure", e);
                return studentSql.FailedStudentQuery();
            }            
        }

        public Student DeleteStudent(int id)
        {
            try
            {
                log.Debug("Student_" + id + "_Deleted");
                return studentSql.DeleteStudent(id);
            }
            catch(Exception e)
            {
                log.Error("Delete Student(id) Butler Failure", e);
                return studentSql.FailedStudentQuery();
            }
        }

        public Student UpdateStudent(int id, string fname, string lname)
        {
            try
            {
                log.Debug("Student_" + id + "-" + fname + "-" + lname + "_Updated");
                return studentSql.UpdateStudent(id, fname, lname);
            }
            catch
            {
                log.Error("Update Student(id, fname, lname) Butler Failure");
                return studentSql.FailedStudentQuery();
            }            
        }

        public List<Student> GetStudentsById(int id)
        {
            try
            {
                log.Debug("Student_" + id + "_Get");
                return studentSql.GetStudentsById(id);
            }
            catch
            {
                log.Error("Get Student(id) Butler Failure");
                return studentSql.FailedStudentList();
            }            
        }

        public List<Student> GetStudentsByFname(string fname)
        {
            try
            {
                log.Debug("Student_" + fname + "_Get");
                return studentSql.GetStudentsByFname(fname);
            }
            catch(Exception e)
            {
                log.Error("Get Student(fname) Butler Failure", e);
                return studentSql.FailedStudentList();
            }
        }

        public List<Student> GetStudentsByLname(string lname)
        {
            try
            {
                log.Debug("Student_" + lname + "_Get");
                return studentSql.GetStudentsByLname(lname);
            }
            catch(Exception e)
            {
                log.Error("Get Student(lname) Butler Failure", e);
                return studentSql.FailedStudentList();
            }
        }

        /************************************************************ Book Passers *****/
        public Book InsertBook(string title, string authF, string authL, int type)
        {
            try
            {
                BookType bookType = typeSql.FindTypeById(type);
                log.Debug("Book_" + title + "-" + authL + "_Inserted");
                return bookSql.InsertBook(title, authF, authL, bookType, typeSql);
            }
            catch(Exception e)
            {
                log.Error("Insert Book(title,authF,authL,type,typeSql) Butler Failure", e);
                return bookSql.FailedBookQuery();
            }            
        }

        public Book DeleteBook(int bookId, TypeSql typeSql)
        {
            try
            {
                log.Debug("Book_" + bookId + "_Deleted");
                return bookSql.DeleteBook(bookId, typeSql);
            }
            catch(Exception e)
            {
                log.Error("Delete Book(id,typeSql) Butler Failure", e);
                return bookSql.FailedBookQuery();
            }
        }

        public Book UpdateBook(int bookId, string title, string authF, string authL, BookType type, TypeSql typeSql)
        {
            try
            {
                log.Debug("Book_" + bookId + "-" + title + "_Updated");
                return bookSql.UpdateBook(bookId, title, authF, authL, type, typeSql);
            }
            catch (Exception e)
            {
                log.Error("Update Book(id,title) Butler Failure", e);
                return bookSql.FailedBookQuery();
            }
        }

        public List<Book> GetBookById(int id)
        {
            try
            {
                log.Debug("Book_" + id + "_Get");
                return bookSql.GetBookById(id, typeSql);
            }
            catch(Exception e)
            {
                log.Error("Get Book(id, typeSql) Butler Failure", e);
                return bookSql.FailedBookList();
            }
        }

        public List<Book> GetBookByName(string title)
        {
            try
            {
                log.Debug("Book_" + title + "_Get");
                return bookSql.GetBookByName(title, typeSql);
            }
            catch(Exception e)
            {
                log.Error("Get Book(title,typeSql) Butler Failure", e);
                return bookSql.FailedBookList();
            }
        }

        public List<Book> GetBookByAuthF(string authF, TypeSql typeSql)
        {
            try
            {
                log.Debug("Book_" + authF + "_Get");
                return bookSql.GetBookByAuthF(authF, typeSql);
            }
            catch(Exception e)
            {
                log.Error("Get Book(authF,typeSql) Butler Failure", e);
                return bookSql.FailedBookList();
            }
        }

        public List<Book> GetBookByAuthL(string authL)
        {
            try
            {
                log.Debug("Book_" + authL + "_Get");
                return bookSql.GetBookByAuthL(authL, typeSql);
            }
            catch(Exception e)
            {
                log.Error("Get Book(authL,typeSql) Butler Failure", e);
                return bookSql.FailedBookList();
            }
        }

        public List<Book> GetBooksByType(BookType type)
        {
            return bookSql.GetBooksByType(type, typeSql);
        }

        public List<Book> GetAllBooks()
        {
            return bookSql.GetAllBooks(typeSql);
        }

        /************************************************************ Type Passers *****/
        public BookType InsertBookType(string name, TimeSpan duration, Decimal penalty)
        {
            try
            {
                log.Debug("BookType_" + name + "_Inserted");
                return typeSql.InsertBookType(name, duration, penalty);
            }
            catch(Exception e)
            {
                log.Error("Insert Book(name,duration,penalty) Butler Failure", e);
                return typeSql.FailedTypeQuery();
            }
        }

        public BookType DeleteBookType(int id)
        {
            try
            {
                log.Debug("BookType_" + id + "_Deleted");
                return typeSql.DeleteBookType(id);
            }
            catch(Exception e)
            {
                log.Error("Delete Book(id) Butler Failure", e);
                return typeSql.FailedTypeQuery();
            }
        }

        public BookType UpdateBookType(int id, TimeSpan duration, string typeName, Decimal penalty)
        {
            try
            {
                log.Debug("BookType_" + id + "-" + typeName + "_Updated");
                return typeSql.UpdateBookType(id, typeName, duration, penalty);
            }
            catch(Exception e)
            {
                log.Error("Update BookType(id,typeName) Butler Failure", e);
                return typeSql.FailedTypeQuery();
            }
        }

        public BookType FindTypeById(int id)
        {
            try
            {
                log.Debug("BookType_" + id + "_Get");
                return typeSql.FindTypeById(id);
            }
            catch (Exception e)
            {
                log.Error("Get BookTypes(id) Butler Failure", e);
                return typeSql.FailedTypeQuery();
            }
        }

        public List<BookType> GetTypeById(int id)
        {
            try
            {
                log.Debug("BookType_" + id + "_Get");
                return typeSql.GetTypesById(id);
            }
            catch(Exception e)
            {
                log.Error("Get BookTypes(id) Butler Failure", e);
                return typeSql.FailedTypeList();
            }
        }

        public List<BookType> GetTypeByName(string name)
        {
            try
            {
                log.Debug("BookType_" + name + "_Get");
                return typeSql.GetTypeByName(name);
            }
            catch(Exception e)
            {
                log.Error("Get BookTypes(name) Butler Failure", e);
                return typeSql.FailedTypeList();
            }
        }

        public List<BookType> GetTypeByDuration(TimeSpan duration)
        {
            try
            {
                log.Debug("BookType_" + duration.ToString() + "_Get");
                return typeSql.GetTypeByDuration(duration);
            }
            catch(Exception e)
            {
                log.Error("Get BookType(duration) Butler Failure", e);
                return typeSql.FailedTypeList();
            }
        }

        public List<BookType> GetTypeByPenalty(Decimal penalty)
        {
            try
            {
                log.Debug("BookType_" + penalty + "_Get");
                return typeSql.GetTypeByPenalty(penalty);
            }
            catch(Exception e)
            {
                log.Error("Get BookType(penalty) Butler Failure", e);
                return typeSql.FailedTypeList();
            }
        }

        public List<BookType> GetAllTypes()
        {
            try
            {
                log.Debug("BookType_All_Get");
                return typeSql.GetAllTypes();
            }
            catch(Exception e)
            {
                log.Error("Get BookType(*) Butler Failure", e);
                return typeSql.FailedTypeList();
            }
        }

        public BookType FailedTypeQuery()
        {
            try
            {
                log.Debug("BookType_fail_Get");
                return typeSql.FailedTypeQuery();
            }
            catch(Exception e)
            {
                log.Error("Get BookTypes_fail_Get");
                BookType blankBook = new BookType() { Id = 999, Name = "Blank Slot" };
                return blankBook;
            }
            
        }

        /************************************************************ Loan Passers *****/
        public Loan InsertLoan(int studentId, int bookId)
        {
            try
            {
                log.Debug("Loan_" + studentId + "-" + bookId + "_Inserted");
                return loanSql.InsertLoan(studentId, bookId, studentSql, bookSql, typeSql);
            }
            catch(Exception e)
            {
                log.Error("Insert Loan(studentId,bookId,loanDate,loanDue,active,accrued) Butler Failure", e);
                return loanSql.FailedLoanQuery();
            }
        }

        public Loan DeleteLoan(int loanId)
        {
            try
            {
                log.Debug("Loan_" + loanId + "_Deleted");
                return loanSql.DeleteLoan(loanId, studentSql, bookSql, typeSql);
            }
            catch(Exception e)
            {
                log.Error("Delete Loan(id) Butler Failure", e);
                return loanSql.FailedLoanQuery();
            }
        }

        public Loan UpdateLoan(int loanId, int studentId, int bookId, DateTime loanDate, DateTime loanDue, Boolean active, Decimal accrued)
        {
            try
            {
                log.Debug("Loan_" + loanId + "-" + studentId + "-" + bookId);
                return loanSql.UpdateLoan(loanId, studentId, bookId, loanDate, loanDue, active, accrued, studentSql, bookSql, typeSql);
            }
            catch(Exception e)
            {
                log.Error("Update Loan(loanId,studentId,bookId,loanDate,loanDue,active,accrued) Butler Failure", e);
                return loanSql.FailedLoanQuery();
            }
        }

        public Loan FindLoanById(int loanId)
        {
            try
            {
                log.Debug("Loan_" + loanId + "_Find");
                return loanSql.FindLoanById(loanId, studentSql, bookSql, typeSql);
            }
            catch(Exception e)
            {
                log.Error("Find Loans(id) Butler Failure", e);
                return loanSql.FailedLoanQuery();
            }
        }

        public List<Loan> GetLoanById(int loanId)
        {
            try
            {
                log.Debug("Loan_" + loanId + "_Get");
                return loanSql.GetLoansById(loanId, studentSql, bookSql, typeSql);
            }
            catch(Exception e)
            {
                log.Error("Get Loans(id) Butler Failure", e);
                return loanSql.FailedLoanList();
            }
        }

        public List<Loan> GetLoansByStudent(int studentId)
        {
            try
            {
                log.Debug("Loan_" + studentId + "_Get");
                return loanSql.GetLoansByStudent(studentId, studentSql, bookSql, typeSql);
            }
            catch(Exception e)
            {
                log.Error("Get Loans(studentId) Butler Failure", e);
                return loanSql.FailedLoanList();
            }
        }

        public List<Loan> GetLoanByBookId(int bookId)
        {
            try
            {
                log.Debug("Loan_" + bookId + "_Get");
                return loanSql.GetLoanByBookId(bookId, studentSql, bookSql, typeSql);
            }
            catch(Exception e)
            {
                log.Error("Get Loans(bookId) Butler Failure", e);
                return loanSql.FailedLoanList();
            }
        }

        public List<Loan> GetLoanByDate(DateTime loanDate)
        {
            try
            {
                log.Debug("Loan_" + loanDate + "_Get");
                return loanSql.GetLoanByDate(loanDate, studentSql, bookSql, typeSql);
            }
            catch(Exception e)
            {
                log.Error("Get Loans(loanDate) Butler Failure", e);
                return loanSql.FailedLoanList();
            }
        }

        public List<Loan> GetLoanByDue(DateTime loanDue)
        {
            try
            {
                log.Debug("Loan_" + loanDue + "_Get");
                return loanSql.GetLoanByDue(loanDue, studentSql, bookSql, typeSql);
            }
            catch(Exception e)
            {
                log.Error("Get Loans(loanDue) Butler Failure", e);
                return loanSql.FailedLoanList();
            }
        }

        public List<Loan> GetLoanByActive(Boolean active)
        {
            try
            {
                log.Debug("Loan_" + active + "_Get");
                return loanSql.GetLoanByActive(active, studentSql, bookSql, typeSql);
            }
            catch(Exception e)
            {
                log.Error("Get Loans(active) Butler Failure", e);
                return loanSql.FailedLoanList();
            }
        }

        public List<Loan> GetLoanByAccrued(Decimal accrued)
        {
            try
            {
                log.Debug("Loan_" + accrued + "_Get");
                return loanSql.GetLoanByAccrued(accrued, studentSql, bookSql, typeSql);
            }
            catch(Exception e)
            {
                log.Error("Get Loans(accrued) Butler Failure", e);
                return loanSql.FailedLoanList();
            }
        }

        public List<Loan> GetAllLoans()
        {

            return loanSql.GetAllLoans(studentSql, bookSql, typeSql);
        }
    }
}