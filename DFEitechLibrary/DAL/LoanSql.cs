using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DFEitechLibrary.Models;
using MySql.Data.MySqlClient;

namespace DFEitechLibrary.DAL
{
    public class LoanSql : MySqlLink
    {
        private static readonly log4net.ILog log = LogButler.GetLogger();

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
            Loan loan = new Loan();
            if (studentId !=0 && bookId !=0 && loanDate !=null && loanDue !=null && active !=false && accrued !=0)
            {
                try
                {
                    con.Open();
                    cmd.CommandText = "INSERT INTO loan (student_id, book_id, loan_date, loan_due, loan_active, loan_penalty) VALUES(@STUDENT, @BOOK, @DATE, @DUE, @ACTIVE, @ACCRUED)";
                    cmd.Parameters.AddWithValue("@STUDENT", studentId);
                    cmd.Parameters.AddWithValue("@BOOK", bookId);
                    cmd.Parameters.AddWithValue("@DATE", loanDate);
                    cmd.Parameters.AddWithValue("@DUE", loanDue);
                    cmd.Parameters.AddWithValue("@ACTIVE", active);
                    cmd.Parameters.AddWithValue("@ACCRUED", accrued);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    log.Error("Insert Loan Query Failure", e);
                }
                finally
                {
                    con.Close();
                }
            }
            return loan;
        }

        public Loan DeleteLoan(int loanId)
        {
            Loan loan = new Loan();
            if (loanId != 0)
            {
                try
                {
                    con.Open();
                    loan = FindLoanById(loanId);
                    cmd.CommandText = "DELETE FROM student WHERE student_id= @ID";
                    cmd.Parameters.AddWithValue("@ID", loanId);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    log.Error("Delete Loan(id)", e);
                }
                finally
                {
                    con.Close();
                }
            }
            return loan;
        }

        public Loan UpdateLoan(int loanId, int studentId, int bookId, DateTime loanDate, DateTime loanDue, Boolean active, Decimal accrued)
        {
            Loan loan = new Loan();
            if (loanId !=0 && studentId !=0 && bookId !=0 && loanDate !=null && loanDue !=null && active !=false && accrued !=0)
            {
                try
                {
                    con.Open();
                    cmd.CommandText = "UPDATE loan SET student_id=@STUDENT, book_id=@BOOK, loan_date=@DATE, loan_due=@DUE, loan_active=@ACTIVE, loan_accrued=@ACCRUED WHERE loan_id=@LOAN";
                    cmd.Parameters.AddWithValue("@LOAN", loanId);
                    cmd.Parameters.AddWithValue("@STUDENT", studentId);
                    cmd.Parameters.AddWithValue("@BOOK", bookId);
                    cmd.Parameters.AddWithValue("@DATE", loanDate);
                    cmd.Parameters.AddWithValue("@DUE", loanDue);
                    cmd.Parameters.AddWithValue("@ACTIVE", active);
                    cmd.Parameters.AddWithValue("@ACCRUED", accrued);
                    cmd.ExecuteNonQuery();

                    loan = FindLoanById(loanId);
                }
                catch (MySqlException e)
                {
                    log.Error("Update Loan(*) Query Failure", e);
                }
                finally
                {
                    con.Close();
                }
            }
            return loan;
        }

        /************************************************************ Loan Getters **/
        public Loan FindLoanById(int loanId)
        {
            Loan loan = new Loan();
            if (loanId != 0)
            {
                try
                {
                    con.Open();
                    cmd.CommandText = "SELECT * FROM loan WHERE loan_id=" + loanId;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        loan.Id = rdr.GetInt32(0);
                        loan.StudentId = rdr.GetInt32(1);
                        loan.BookId = rdr.GetInt32(2);
                        loan.LoanDate = rdr.GetDateTime(3);
                        loan.LoanDue = rdr.GetDateTime(4);
                        loan.Active = rdr.GetBoolean(5);
                        loan.Accrued = rdr.GetDecimal(6);
                    }
                }
                catch (MySqlException e)
                {
                    log.Error("Find Loan(id)", e);
                }
                finally
                {
                    con.Close();
                }
            }
            return loan;
        }

        public List<Loan> GetLoansById(int loanId)
        {
            List<Loan> matchedLoans = new List<Loan>();
            if (loanId != 0)
            {
                try
                {
                    con.Open();
                    cmd.CommandText = "SELECT * FROM loan WHERE loan_id=" + loanId;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Loan loan = new Loan();
                        loan.Id = rdr.GetInt32(0);
                        loan.StudentId = rdr.GetInt32(1);
                        loan.BookId = rdr.GetInt32(2);
                        loan.LoanDate = rdr.GetDateTime(3);
                        loan.LoanDue = rdr.GetDateTime(4);
                        loan.Active = rdr.GetBoolean(5);
                        loan.Accrued = rdr.GetDecimal(6);
                        matchedLoans.Add(loan);
                    }
                }
                catch (MySqlException e)
                {
                    log.Error("Get Loans(id) Query Failure", e);
                }
                finally
                {
                    con.Close();
                }
            }
            return matchedLoans;
        }

        public List<Loan> GetLoansByStudent(int studentId)
        {
            List<Loan> matchedLoans = new List<Loan>();
            if (studentId != 0)
            {
                try
                {
                    con.Open();
                    cmd.CommandText = "SELECT * FROM loan WHERE student_id=" + studentId;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Loan loan = new Loan();
                        loan.Id = rdr.GetInt32(0);
                        loan.StudentId = rdr.GetInt32(1);
                        loan.BookId = rdr.GetInt32(2);
                        loan.LoanDate = rdr.GetDateTime(3);
                        loan.LoanDue = rdr.GetDateTime(4);
                        loan.Active = rdr.GetBoolean(5);
                        loan.Accrued = rdr.GetDecimal(6);
                        matchedLoans.Add(loan);
                    }
                }
                catch (MySqlException e)
                {
                    log.Error("Get Loans(studentId) Query Failure", e);
                }
                finally
                {
                    con.Close();
                }
            }
            return matchedLoans;
        }

        public List<Loan> GetLoanByBookId(int bookId)
        {
            List<Loan> matchedLoans = new List<Loan>();
            if (bookId != 0)
            {
                try
                {
                    con.Open();
                    cmd.CommandText = "SELECT * FROM loan WHERE book_id=" + bookId;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Loan loan = new Loan();
                        loan.Id = rdr.GetInt32(0);
                        loan.StudentId = rdr.GetInt32(1);
                        loan.BookId = rdr.GetInt32(2);
                        loan.LoanDate = rdr.GetDateTime(3);
                        loan.LoanDue = rdr.GetDateTime(4);
                        loan.Active = rdr.GetBoolean(5);
                        loan.Accrued = rdr.GetDecimal(6);
                        matchedLoans.Add(loan);
                    }
                }
                catch (MySqlException e)
                {
                    log.Error("Get Loans(bookId) Query Failure", e);
                }
                finally
                {
                    con.Close();
                }
            }
            return matchedLoans;
        }

        public List<Loan> GetLoanByDate(DateTime loanDate)
        {
            List<Loan> matchedLoans = new List<Loan>();
            if (loanDate !=null)
            {
                try
                {
                    con.Open();
                    cmd.CommandText = "SELECT * FROM loan WHERE loan_date=" + loanDate;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Loan loan = new Loan();
                        loan.Id = rdr.GetInt32(0);
                        loan.StudentId = rdr.GetInt32(1);
                        loan.BookId = rdr.GetInt32(2);
                        loan.LoanDate = rdr.GetDateTime(3);
                        loan.LoanDue = rdr.GetDateTime(4);
                        loan.Active = rdr.GetBoolean(5);
                        loan.Accrued = rdr.GetDecimal(6);
                        matchedLoans.Add(loan);
                    }
                }
                catch (MySqlException e)
                {
                    log.Error("Get Loans(loanDate) Query Error", e);
                }
                finally
                {
                    con.Close();
                }
            }
            return matchedLoans;
        }

        public List<Loan> GetLoanByDue(DateTime loanDue)
        {
            List<Loan> matchedLoans = new List<Loan>();
            if (loanDue !=null)
            {
                try
                {
                    cmd.CommandText = "SELECT * FROM loan WHERE loan_due=" + loanDue;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Loan loan = new Loan();
                        loan.Id = rdr.GetInt32(0);
                        loan.StudentId = rdr.GetInt32(1);
                        loan.BookId = rdr.GetInt32(2);
                        loan.LoanDate = rdr.GetDateTime(3);
                        loan.LoanDue = rdr.GetDateTime(4);
                        loan.Active = rdr.GetBoolean(5);
                        loan.Accrued = rdr.GetDecimal(6);
                        matchedLoans.Add(loan);
                    }
                }
                catch (MySqlException e)
                {
                    log.Error("Get Loans(loanDue) Query Failure", e);
                }
                finally
                {
                    con.Close();
                }
            }
            return matchedLoans;
        }

        public List<Loan> GetLoanByActive(Boolean active)
        {
            List<Loan> matchedLoans = new List<Loan>();
            if (active !=false)
            {
                try
                {
                    con.Open();
                    cmd.CommandText = "SELECT * FROM loan WHERE loan_active=" + active;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Loan loan = new Loan();
                        loan.Id = rdr.GetInt32(0);
                        loan.StudentId = rdr.GetInt32(1);
                        loan.BookId = rdr.GetInt32(2);
                        loan.LoanDate = rdr.GetDateTime(3);
                        loan.LoanDue = rdr.GetDateTime(4);
                        loan.Active = rdr.GetBoolean(5);
                        loan.Accrued = rdr.GetDecimal(6);
                        matchedLoans.Add(loan);
                    }
                }
                catch (MySqlException e)
                {
                    log.Error("Get Loans(active)", e);
                }
                finally
                {
                    con.Close();
                }
            }
            return matchedLoans;
        }

        public List<Loan> GetLoanByAccrued(Decimal accrued)
        {
            List<Loan> matchedLoans = new List<Loan>();
            if (accrued != 0)
            {
                try
                {
                    con.Open();
                    cmd.CommandText = "SELECT * FROM loan WHERE loan_accrued=" + accrued;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Loan loan = new Loan();
                        loan.Id = rdr.GetInt32(0);
                        loan.StudentId = rdr.GetInt32(1);
                        loan.BookId = rdr.GetInt32(2);
                        loan.LoanDate = rdr.GetDateTime(3);
                        loan.LoanDue = rdr.GetDateTime(4);
                        loan.Active = rdr.GetBoolean(5);
                        loan.Accrued = rdr.GetDecimal(6);
                        matchedLoans.Add(loan);
                    }
                }
                catch (MySqlException e)
                {
                    log.Error("Get Loans(accrued) query Failure", e);
                }
            }
            return matchedLoans;
        }

        public Loan FailedLoanQuery()
        {
            DateTime loanDate = new DateTime(1, 1, 1);
            DateTime loanDue = new DateTime(5000,500,50);
            Loan failure = new Loan() { Id = 999, StudentId = 999, BookId = 999, Accrued = 999.99m, LoanDate = loanDate, LoanDue = loanDue, Active = false };
            return failure;
        }

        public List<Loan> FailedLoanList()
        {
            List<Loan> failures = new List<Loan>();
            DateTime loanDate = new DateTime(1, 1, 1);
            DateTime loanDue = new DateTime(5000, 500, 50);
            Loan failure = new Loan() { Id = 999, StudentId = 999, BookId = 999, Accrued = 999.99m, LoanDate = loanDate, LoanDue = loanDue, Active = false };
            failures.Add(failure);
            return failures;
        }
    }
}