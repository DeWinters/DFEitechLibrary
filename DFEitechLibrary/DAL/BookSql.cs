using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DFEitechLibrary.Models;
using MySql.Data.MySqlClient;

namespace DFEitechLibrary.DAL
{
    public class BookSql : MySqlLink
    {
        private static readonly log4net.ILog log = LogButler.GetLogger();

        public BookSql()
        {
            cmd.Connection = con;
        }
        ~BookSql()
        {
            con.Close();
        }

        public Book InsertBook(string title, string authF, string authL, BookType type, TypeSql typeSql)
        {
            Book book = new Book(); 
            if (title != null && authL != null && type !=null)
            {
                try
                {
                    con.Open();
                    cmd.CommandText = "INSERT INTO book (book_title, book_auth_first, book_auth_last, type) VALUES(@TITLE, @FIRST, @LAST, @TYPE)";
                    cmd.Parameters.AddWithValue("@TITLE", title);
                    cmd.Parameters.AddWithValue("@FIRST", authF);
                    cmd.Parameters.AddWithValue("@LAST", authL);
                    cmd.Parameters.AddWithValue("@TYPE", type);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    book.Title = e.ToString();
                    log.Error("Insert Book Query Failure", e);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                book.Title = "Missing Parameters";
            }
            return book;
        }

        public Book DeleteBook(int bookId, TypeSql typeSql)
        {
            Book book = new Book(); 
            if (bookId != 0)
            {
                try
                {
                    con.Open();
                    book = FindBookById(bookId, typeSql);
                    cmd.CommandText = "DELETE FROM book WHERE book_id= @ID";
                    cmd.Parameters.AddWithValue("@ID", bookId);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    book.Title = e.ToString();
                    log.Error("Delete Book(id, typeSql) Query Failure", e);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                book.Title = "No Book ID entered";
            }
            return book;
        }

        public Book UpdateBook(int bookId, string title, string authF, string authL, BookType type, TypeSql typeSql)
        {
            Book book = new Book();
            if (bookId != 0 && authF != null && authL != null && type !=null)
            {
                try
                {
                    con.Open();
                    cmd.CommandText = "UPDATE book SET book_auth_first=@FNAME, book_auth_last=@LNAME, book_type=@TYPE WHERE book_id=@ID";
                    cmd.Parameters.AddWithValue("@ID", bookId);
                    cmd.Parameters.AddWithValue("@FNAME", authF);
                    cmd.Parameters.AddWithValue("@LNAME", authL);
                    cmd.Parameters.AddWithValue("@TYPE", type);
                    cmd.ExecuteNonQuery();

                    book = FindBookById(bookId, typeSql);
                }
                catch (MySqlException e)
                {
                    book.Title = e.ToString();
                    log.Error("Update Book Query Failure", e);
                }
                finally
                {
                    con.Close();
                }
            }
            else if (bookId !=0 && authL !=null && type !=null)
            {
                try
                {
                    con.Open();
                    cmd.CommandText = "UPDATE book SET book_auth_last=@LNAME, book_type=@TYPE WHERE book_id=@ID";
                    cmd.Parameters.AddWithValue("@ID", bookId);
                    cmd.Parameters.AddWithValue("@LNAME", authL);
                    cmd.Parameters.AddWithValue("@TYPE", type);
                    cmd.ExecuteNonQuery();

                    book = FindBookById(bookId, typeSql);
                }
                catch (MySqlException e)
                {
                    book.Title = e.ToString();
                    log.Error("Update Book Query Failue", e);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                book.Title = "Missing Parameters";
            }
            return book;
        }

        /************************************************************ Book Setters **/
        public Book FindBookById(int bookId, TypeSql typeSql)
        {
            Book book = new Book(); 
            if (bookId != 0)
            {
                try
                {
                    con.Open();
                    cmd.CommandText = "SELECT * FROM book WHERE student_id=" + bookId;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        book.Id = rdr.GetInt32(0);
                        book.Title = rdr.GetString(1);
                        book.AuthL = rdr.GetString(2);
                        book.AuthF = rdr.GetString(3);
                        book.TomeType = typeSql.FindTypeById(rdr.GetInt32(4)); 
                    }
                }
                catch (MySqlException e)
                {
                    book.Title = e.ToString();
                    log.Error("Find Student(id, typeSql) Query Failure", e);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                book.Title = "Missing Parameter";
            }
            return book;
        }

        public List<Book> GetBookById(int bookId, TypeSql typeSql)
        {
            List<Book> matchedBooks = new List<Book>();
            if (bookId != 0)
            {
                try
                {
                    con.Open();
                    cmd.CommandText = "SELECT * FROM book WHERE student_id=" + bookId;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Book book = new Book();
                        book.Id = rdr.GetInt32(0);
                        book.Title = rdr.GetString(1);
                        book.AuthL = rdr.GetString(2);
                        book.AuthF = rdr.GetString(3);
                        book.TomeType = typeSql.FindTypeById(rdr.GetInt32(4));
                        matchedBooks.Add(book);
                    }
                }
                catch (MySqlException e)
                {
                    Book book = new Book() { Title = e.ToString() };
                    matchedBooks.Add(book);
                    log.Error("Get Book(id, typeSql) Query Failure", e);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                Book book = new Book() { Title = "Missing Parameter" };
                matchedBooks.Add(book);
            }
            return matchedBooks;
        }

        public List<Book> GetBookByName(string title, TypeSql typeSql)
        {
            List<Book> matchedBooks = new List<Book>();
            if (title != null)
            {
                try
                {
                    con.Open();
                    cmd.CommandText = "SELECT * FROM book WHERE book_title=" + title;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Book book = new Book();
                        book.Id = rdr.GetInt32(0);
                        book.Title = rdr.GetString(1);
                        book.AuthL = rdr.GetString(2);
                        book.AuthF = rdr.GetString(3);
                        book.TomeType = typeSql.FindTypeById(rdr.GetInt32(4));
                        matchedBooks.Add(book);
                    }
                }
                catch (MySqlException e)
                {
                    Book book = new Book() { Title = e.ToString() };
                    matchedBooks.Add(book);
                    log.Error("Get Book(name, typeSql) Query Failure", e);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                Book book = new Book() { Title = "Missing Parameter" };
                matchedBooks.Add(book);
            }
            return matchedBooks;
        }

        public List<Book> GetBookByAuthF(string authF, TypeSql typeSql)
        {
            List<Book> matchedBooks = new List<Book>();
            if (authF != null)
            {
                try
                {
                    con.Open();
                    cmd.CommandText = "SELECT * FROM book WHERE book_auth_first=" + authF;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Book book = new Book();
                        book.Id = rdr.GetInt32(0);
                        book.Title = rdr.GetString(1);
                        book.AuthL = rdr.GetString(2);
                        book.AuthF = rdr.GetString(3);
                        book.TomeType = typeSql.FindTypeById(rdr.GetInt32(4));
                        matchedBooks.Add(book);
                    }
                }
                catch (MySqlException e)
                {
                    Book book = new Book() { Title = e.ToString() };
                    matchedBooks.Add(book);
                    log.Error("Get Book(authF, typeSql) Query Failure", e);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                Book book = new Book() { Title = "Missing Parameter" };
                matchedBooks.Add(book);
            }
            return matchedBooks;
        }

        public List<Book> GetBookByAuthL(string authL, TypeSql typeSql)
        {
            List<Book> matchedBooks = new List<Book>();
            if (authL != null)
            {
                try
                {
                    con.Open();
                    cmd.CommandText = "SELECT * FROM book WHERE book_auth_last=" + authL;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Book book = new Book();
                        book.Id = rdr.GetInt32(0);
                        book.Title = rdr.GetString(1);
                        book.AuthL = rdr.GetString(2);
                        book.AuthF = rdr.GetString(3);
                        book.TomeType = typeSql.FindTypeById(rdr.GetInt32(4));
                        matchedBooks.Add(book);
                    }
                }
                catch (MySqlException e)
                {
                    Book book = new Book() { Title = e.ToString() };
                    matchedBooks.Add(book);
                    log.Error("Get Book(authL, typeSql) Query Failure", e);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                Book book = new Book() { Title = "Missing Parameter" };
                matchedBooks.Add(book);
            }
            return matchedBooks;
        }

        public Book FailedBookQuery()
        {
            Book failure = new Book() { Id = 999, Title = "Handling Error", AuthF = "Handling Error", AuthL = "Handling Error", TomeType=null };
            return failure;
        }

        public List<Book> FailedBookList()
        {
            List<Book> failures = new List<Book>();
            Book failure = new Book() { Id = 999, Title = "Handling Error", AuthF = "Handling Error", AuthL = "Handling Error", TomeType = null };
            failures.Add(failure);
            return failures;
        }
    }
}