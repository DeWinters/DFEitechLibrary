using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DFEitechLibrary.Models;

namespace DFEitechLibrary.DAL
{
    public class StudentSql : MySqlLink
    {
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
            Student student = new Student(); // TBC
            return student;
        }

        public Student DeleteStudent(int id) // TBC
        {
            Student student = new Student();
            return student;
        }

        public Student UpdateStudent(int id, string fname, string lname)
        {
            Student student = new Student(); // TBC
            return student;
        }

        /************************************************************ Student Getters **/
        public List<Student> GetStudentsById(int id)
        {
            List<Student> matchedStudents = new List<Student>(); // TBC
            return matchedStudents;
        }

        public List<Student> GetStudentsByFname(string fname)
        {
            List<Student> matchedStudents = new List<Student>(); // TBC
            return matchedStudents;
        }

        public List<Student> GetStudentsByLname(string lname)
        {
            List<Student> matchedStudents = new List<Student>(); // TBC
            return matchedStudents;
        }

    }
}