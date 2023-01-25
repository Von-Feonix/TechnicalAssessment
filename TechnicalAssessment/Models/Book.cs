using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnicalAssessment.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string bookName { get; set; }
        public string bookID { get; set; }
        public Boolean reserved { get; set; }
    }
}