using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace DFEitechLibrary.DAL
{
    public abstract class MySqlLink
    {
        private static readonly log4net.ILog log = LogLink.GetLogger();

        protected MySqlCommand cmd = new MySqlCommand();
        protected MySqlConnection con = new MySqlConnection(@"server=testmysqlinst.corprrs97lob.eu-west-1.rds.amazonaws.com;port=3306;User ID=root;password=gyrfalcon5151;Database=librarydb");
        protected MySqlDataReader rdr;
    }
}