using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DFEitechLibrary.Models;
using MySql.Data.MySqlClient;

namespace DFEitechLibrary.DAL
{
    public class TypeSql : MySqlLink
    {
        public TypeSql()
        {
            cmd.Connection = con;
        }
        ~TypeSql()
        {
            con.Close();
        }

        public BookType InsertBookType(string name, TimeSpan duration, Decimal penalty)
        {
            BookType bookType = new BookType();
            if (name !=null && duration !=null && penalty !=0)
            {
                try
                {
                    cmd.CommandText = "INSERT INTO book (type_name, type_duration, type_penalty) VALUES(@NAME, @DURATION, @PENALTY)";
                    cmd.Parameters.AddWithValue("@NAME", name);
                    cmd.Parameters.AddWithValue("@DURATION", duration);
                    cmd.Parameters.AddWithValue("@PENALTY", penalty);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    bookType.Name = e.ToString();
                }
            }
            else
            {
                bookType.Name = "Missing Parameters";
            }
            return bookType;
        }

        public BookType DeleteBookType(int typeId)
        {
            BookType bookType = new BookType();
            if (typeId != 0)
            {
                try
                {
                    bookType = FindTypeById(typeId);
                    cmd.CommandText = "DELETE FROM booktype WHERE type_id= @ID";
                    cmd.Parameters.AddWithValue("@ID", typeId);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    bookType.Name = e.ToString();
                }
            }
            else
            {
                bookType.Name = "No Type ID entered";
            }
            return bookType;
        }

        public BookType UpdateBookType(int typeId, string typeName, TimeSpan duration, Decimal penalty)
        {
            BookType bookType = new BookType();
            if (typeId != 0 && duration != null && penalty !=0)
            {
                try
                {
                    cmd.CommandText = "UPDATE booktype SET type_name=@NAME, type_duration=@DURATION, type_penalty=@PENALTY WHERE type_id=@ID";
                    cmd.Parameters.AddWithValue("@ID", typeId);
                    cmd.Parameters.AddWithValue("@NAME", typeName);
                    cmd.Parameters.AddWithValue("@DURATION", duration);
                    cmd.Parameters.AddWithValue("@PENALTY", penalty);
                    cmd.ExecuteNonQuery();

                    bookType = FindTypeById(typeId);
                }
                catch (MySqlException e)
                {
                    bookType.Name = e.ToString();
                }
            }
            return bookType;
        }

        /************************************************************ Type Getters **/
        public BookType FindTypeById(int typeId)
        {
            BookType type = new BookType();
            if (typeId != 0)
            {
                try
                {
                    cmd.CommandText = "SELECT * FROM booktype WHERE type_id=" + typeId;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        type.Id = rdr.GetInt32(0);
                        type.Name = rdr.GetString(1);
                        type.Duration = rdr.GetTimeSpan(2);
                        type.Penalty = rdr.GetDecimal(3);
                    }
                }
                catch (MySqlException e)
                {
                    type.Name = e.ToString();
                }
            }
            else
            {
                type.Name = "Missing Parameter";
            }
            return type;
        }

        public List<BookType> GetTypeById(int typeId)
        {
            List<BookType> matchedTypes = new List<BookType>();
            if (typeId != 0)
            {
                try
                {
                    cmd.CommandText = "SELECT * FROM booktype WHERE type_id=" + typeId;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        BookType type = new BookType();
                        type.Id = rdr.GetInt32(0);
                        type.Name = rdr.GetString(1);
                        type.Duration = rdr.GetTimeSpan(2);
                        type.Penalty = rdr.GetDecimal(3);
                        matchedTypes.Add(type);
                    }
                }
                catch (MySqlException e)
                {
                    BookType type = new BookType() { Name = e.ToString() };
                    matchedTypes.Add(type);
                }
            }
            else
            {
                BookType type = new BookType() { Name = "Missing Parameter" };
                matchedTypes.Add(type);
            }
            return matchedTypes;
        }

        public List<BookType> GetTypeByName(string name)
        {
            List<BookType> matchedTypes = new List<BookType>();
            if (name !=null)
            {
                try
                {
                    cmd.CommandText = "SELECT * FROM booktype WHERE type_name=" + name;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        BookType type = new BookType();
                        type.Id = rdr.GetInt32(0);
                        type.Name = rdr.GetString(1);
                        type.Duration = rdr.GetTimeSpan(2);
                        type.Penalty = rdr.GetDecimal(3);
                        matchedTypes.Add(type);
                    }
                }
                catch (MySqlException e)
                {
                    BookType type = new BookType() { Name = e.ToString() };
                    matchedTypes.Add(type);
                }
            }
            else
            {
                BookType type = new BookType() { Name = "Missing Parameter" };
                matchedTypes.Add(type);
            }
            return matchedTypes;
        }

        public List<BookType> GetTypeByDuration(int durationId)
        {
            List<BookType> matchedTypes = new List<BookType>();
            if (durationId !=0)
            {
                try
                {
                    cmd.CommandText = "SELECT * FROM booktype WHERE type_duration=" + durationId;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        BookType type = new BookType();
                        type.Id = rdr.GetInt32(0);
                        type.Name = rdr.GetString(1);
                        type.Duration = rdr.GetTimeSpan(2);
                        type.Penalty = rdr.GetDecimal(3);
                        matchedTypes.Add(type);
                    }
                }
                catch (MySqlException e)
                {
                    BookType type = new BookType() { Name = e.ToString() };
                    matchedTypes.Add(type);
                }
            }
            else
            {
                BookType type = new BookType() { Name = "Missing Parameter" };
                matchedTypes.Add(type);
            }
            return matchedTypes;
        }

        public List<BookType> GetTypeByPenalty(Decimal penalty)
        {
            List<BookType> matchedTypes = new List<BookType>();
            if (penalty != 0)
            {
                try
                {
                    cmd.CommandText = "SELECT * FROM booktype WHERE type_penalty=" + penalty;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        BookType type = new BookType();
                        type.Id = rdr.GetInt32(0);
                        type.Name = rdr.GetString(1);
                        type.Duration = rdr.GetTimeSpan(2);
                        type.Penalty = rdr.GetDecimal(3);
                        matchedTypes.Add(type);
                    }
                }
                catch (MySqlException e)
                {
                    BookType type = new BookType() { Name = e.ToString() };
                    matchedTypes.Add(type);
                }
            }
            else
            {
                BookType type = new BookType() { Name = "Missing Parameter" };
                matchedTypes.Add(type);
            }
            return matchedTypes;
        }
    }
}