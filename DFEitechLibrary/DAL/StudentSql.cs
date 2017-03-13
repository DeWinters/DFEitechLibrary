using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DFEitechLibrary.Models;
using MySql.Data.MySqlClient;

namespace DFEitechLibrary.DAL
{
    public class StudentSql : MySqlLink
    {
        private static readonly log4net.ILog log = LogLink.GetLogger();

        public StudentSql()
        {
            cmd.Connection = con;
        }
        ~StudentSql()
        {
            con.Close();
        }

        public Student InsertStudent(string fname, string lname)
        {
            Student student = new Student(); 
            if(fname !=null && lname != null)
            {
                try
                {
                    con.Open();
                    cmd.CommandText = "INSERT INTO student (student_first, student_last) VALUES(@FIRST, @LAST)";
                    cmd.Parameters.AddWithValue("@FIRST", fname);
                    cmd.Parameters.AddWithValue("@LAST", lname);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    student.NameL = e.ToString();
                    log.Error("Insert Student Query Failure");
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                student.NameL = "Missing Parameters";
            }            
            return student;
        }

        public Student DeleteStudent(int id) 
        {
            Student student = FindStudentById(id);
            if(id != 0)
            {
                try
                {
                    con.Open();
                    cmd.CommandText = "DELETE FROM student WHERE student_id= @ID";
                    cmd.Parameters.Add(new MySqlParameter("@ID", id));
                    //cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    student.NameL = e.ToString();
                    log.Error("Delete student(id) Query Failure");
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                student.NameL = "Missing Parameter";
            }            
            return student;
        }

        public Student UpdateStudent(int id, string fname, string lname)
        {
            Student student = new Student(); 
            if(id !=0 && fname !=null && lname != null)
            {
                try
                {
                    con.Open();
                    cmd.CommandText = "UPDATE student SET student_first=@FNAME, student_last=@LNAME WHERE student_id=@ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@FNAME", fname);
                    cmd.Parameters.AddWithValue("@LNAME", lname);
                    cmd.ExecuteNonQuery();

                    student = FindStudentById(id);
                }
                catch (MySqlException e)
                {
                    student.NameL = e.ToString();
                    log.Error("Update Student Query Failure");
                }
                finally
                {
                    con.Close();
                }
            }
            else if (id !=0 && fname != null)
            {
                try
                {
                    con.Open();
                    cmd.CommandText = "UPDATE student SET student_first=@FNAME WHERE student_id=@ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@FNAME", fname);
                    cmd.ExecuteNonQuery();

                    student = FindStudentById(id);
                }
                catch (MySqlException e)
                {
                    student.NameL = e.ToString();
                    log.Error("Update Student Query Failure");
                }
                finally
                {
                    con.Close();
                }
            }
            else if(id !=0 && lname !=null)
            {
                try
                {
                    con.Open();
                    cmd.CommandText = "UPDATE student SET student_last=@LNAME WHERE student_id=@ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@LNAME", lname);
                    cmd.ExecuteNonQuery();

                    student = FindStudentById(id);
                }
                catch (MySqlException e)
                {
                    student.NameL = e.ToString();
                    log.Error("Update Student Query Failure");
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                student.NameL = "Insufficient Parameters";
            }            
            return student;
        }

        /************************************************************ Student Getters **/
        public Student FindStudentById(int id)
        {
            Student student = new Student();
            if(id != 0)
            {
                try
                {
                    con.Open();
                    cmd.CommandText = "SELECT * FROM student WHERE student_id=" + id;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        student.Id = rdr.GetInt16(0);
                        student.NameF = rdr.GetString(1);
                        student.NameL = rdr.GetString(2);
                    }
                }
                catch (MySqlException e)
                {
                    student.NameL = e.ToString();
                    log.Error("Find Student(id)");
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                student.NameL = "Missing Parameter";
            }            
            return student;
        }

        public List<Student> GetStudentsById(int id)
        {
            List<Student> matchedStudents = new List<Student>(); 
            if(id != 0)
            {
                try
                {
                    con.Open();
                    cmd.CommandText = "SELECT * FROM student WHERE student_id=" + id;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Student student = new Student();
                        student.Id = rdr.GetInt16(0);
                        student.NameF = rdr.GetString(1);
                        student.NameL = rdr.GetString(2);
                        matchedStudents.Add(student);
                    }
                }
                catch (MySqlException e)
                {
                    Student student = new Student();
                    student.NameL = e.ToString();
                    matchedStudents.Add(student);

                    log.Error("Get Students(id) Query Failure");
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                Student student = new Student();
                student.NameL = "Missing Parameter";
                matchedStudents.Add(student);
            }
            return matchedStudents;
        }

        public List<Student> GetStudentsByFname(string fname)
        {
            List<Student> matchedStudents = new List<Student>();
            if(fname != null)
            {
                try
                {
                    con.Open();
                    cmd.CommandText = "SELECT * FROM student WHERE student_first=" + fname;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Student student = new Student();
                        student.Id = rdr.GetInt16(0);
                        student.NameF = rdr.GetString(1);
                        student.NameL = rdr.GetString(2);
                        matchedStudents.Add(student);
                    }
                }
                catch (MySqlException e)
                {
                    Student student = new Student();
                    student.NameL = e.ToString();
                    matchedStudents.Add(student);
                    log.Error("Get Student(fname)");
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                Student student = new Student();
                student.NameL = "Missing Parameter";
                matchedStudents.Add(student);
            }
            
            return matchedStudents;
        }

        public List<Student> GetStudentsByLname(string lname)
        {
            List<Student> matchedStudents = new List<Student>();
            if(lname != null)
            {
                try
                {
                    con.Open();
                    cmd.CommandText = "SELECT * FROM student WHERE student_last=" + lname;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Student student = new Student();
                        student.Id = rdr.GetInt16(0);
                        student.NameF = rdr.GetString(1);
                        student.NameL = rdr.GetString(2);
                        matchedStudents.Add(student);
                    }
                }
                catch (MySqlException e)
                {
                    Student student = new Student();
                    student.NameL = e.ToString();
                    matchedStudents.Add(student);
                    log.Error("Get Students(lname)");
                }
            }
            else
            {
                Student student = new Student();
                student.NameL = "Parameter Missing";
                matchedStudents.Add(student);
            }            
            return matchedStudents;
        }

        public List<Student> GetAllStudents()
        {
            List<Student> allStudents = new List<Student>();

            try
            {
                con.Open();
                cmd.CommandText = "SELECT * FROM student";
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Student student = new Student();
                    student.Id = rdr.GetInt16(0);
                    student.NameF = rdr.GetString(1);
                    student.NameL = rdr.GetString(2);
                    allStudents.Add(student);
                }
            }
            catch (MySqlException e)
            {
                Student student = new Student();
                student.NameL = e.ToString();
                allStudents.Add(student);
                log.Error("Get All Students Query Failure");
            }
            finally
            {
                con.Close();
            }
            return allStudents;
        }

        public Student FailedStudentQuery()
        {
            Student failure = new Student() { Id = 999, NameF = "Handling Error", NameL = "Handling Error" };
            return failure;
        }

        public List<Student> FailedStudentList()
        {
            List<Student> failures = new List<Student>();
            Student failure = new Student() { Id = 999, NameF = "Handling Error", NameL = "Handling Error" };
            failures.Add(failure);
            return failures;
        }

    }
}