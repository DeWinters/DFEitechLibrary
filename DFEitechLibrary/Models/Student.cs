using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DFEitechLibrary.Models
{
    public class Student
    {
        private static readonly log4net.ILog log = LogLink.GetLogger();

        public int Id { get; set; }
        public string NameL { get; set; }
        public string NameF { get; set; }

        public String toString()
        {
            String text = this.Id.ToString() + "-" +
                          this.NameL + "-" +
                          this.NameF;
            return text;
        }
    }
}