using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DFEitechLibrary.DAL;

namespace DFEitechLibraryTest
{
    [TestClass]
    public class BookTypeTests
    {
        [TestMethod]
        public void InsertBookTypeTest1()
        {
            string name = "InsertBookTypeTest1, happy_path, 1";
            TimeSpan duration = new TimeSpan(11, 11, 11);
            Decimal penalty = 11.11m;

            TypeSql typeSql = new TypeSql();
            Console.WriteLine(typeSql.InsertBookType(name, duration, penalty));
        }

        [TestMethod]
        public void FindTypeByIdTest1()
        {
            int typeId = 1;

            TypeSql typeSql = new TypeSql();
            Console.WriteLine(typeSql.FindTypeById(typeId));
        }

        [TestMethod]
        public void GetTypesByIdTest1()
        {
            int typeId = 1;

            TypeSql typeSql = new TypeSql();
            Console.WriteLine(typeSql.GetTypesById(typeId));
        }

        [TestMethod]
        public void GetTypeByNameTest1()
        {
            string name = "InsertBookTypeTest1, happy_path, 1";

            TypeSql typeSql = new TypeSql();
            Console.WriteLine(typeSql.GetTypeByName(name));
        }

        [TestMethod]
        public void GetTypeByDurationTest1()
        {
            TimeSpan duration = new TimeSpan(11, 11, 11);

            TypeSql typeSql = new TypeSql();
            Console.WriteLine(typeSql.GetTypeByDuration(duration));
        }

        [TestMethod]
        public void GetTypeByPenaltyTest1()
        {
            Decimal penalty = 11.11m;

            TypeSql typeSql = new TypeSql();
            Console.WriteLine(typeSql.GetTypeByPenalty(penalty));
        }
        
        [TestMethod]
        public void UpdateBookTypeTest1()
        {
            int typeId = 1;
            string typeName = "UpdateBookTypeTest, happy_path, 1";
            TimeSpan duration = new TimeSpan(12, 12, 12);
            Decimal penalty = 12.12m;

            TypeSql typeSql = new TypeSql();
            Console.WriteLine(typeSql.UpdateBookType(typeId, typeName, duration, penalty));
        }

        [TestMethod]
        public void DeleteBookTypeTest1()
        {
            TypeSql typeSql = new TypeSql();
            Console.WriteLine(typeSql.DeleteBookType(1));   // requires manual confirmation of valid id.
        }
    }
}
