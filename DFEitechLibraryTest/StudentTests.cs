using DFEitechLibrary.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFEitechLibraryTest
{
    [TestClass]
    class StudentTests
    {
        [TestMethod]
        public void InsertStudentTest1()
        {
            string fname = "InsertStudentTest1, happy_path 1"; 
            string lname = "InsertStudentTest1, lname1";

            StudentSql studentSql = new StudentSql();
            Console.WriteLine(studentSql.InsertStudent(fname, lname));
        }

        [TestMethod]
        public void FindStudentByIdTest1()
        {
            int id = 1;

            StudentSql studentSql = new StudentSql();
            Console.WriteLine(studentSql.FindStudentById(id));
        }

        [TestMethod]
        public void GetStudentsByIdTest1()
        {
            int id = 1;

            StudentSql studentSql = new StudentSql();
            Console.WriteLine(studentSql.GetStudentsById(id));
        }

        [TestMethod]
        public void GetStudentsByFnameTest1()
        {
            string fname = "InsertStudentTest1, happy_path 1";

            StudentSql studentSql = new StudentSql();
            Console.WriteLine(studentSql.GetStudentsByFname(fname));
        }

        [TestMethod]
        public void GetStudentsByLnameTest1()
        {
            string lname = "InsertStudentTest1, lname1";

            StudentSql studentSql = new StudentSql();
            Console.WriteLine(studentSql.GetStudentsByLname(lname));
        }

        [TestMethod]
        public void UpdateStudentTest1()
        {
            int id =1;
            string fname = "UpdateStudentTest1, happy_path 1";
            string lname = "new last name";

            StudentSql studentSql = new StudentSql();
            Console.WriteLine(studentSql.UpdateStudent(id, fname, lname));
        }
        
        [TestMethod]
        public void DeleteStudentTest1()
        {
            StudentSql studentSql = new StudentSql();
            Console.WriteLine(studentSql.DeleteStudent(1)); // requires manual confirmation of valid id.
        }
    }
}
