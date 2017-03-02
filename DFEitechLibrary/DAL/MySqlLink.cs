using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using DFEitechLibrary.Models;

namespace DFEitechLibrary.DAL
{
    public abstract class MySqlLink
    {
        protected MySqlCommand cmd = new MySqlCommand();
        protected MySqlConnection con = new MySqlConnection(@"server=testmysqlinst.corprrs97lob.eu-west-1.rds.amazonaws.com;port=3306;User ID=root;password=gyrfalcon5151;Database=librarydb");
        protected MySqlDataReader rdr;
    }
}