using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnicalAssessment.Models
{
    public class Book
    {
        public int bID { get; set; }
        public string bookName { get; set; }
        public string bookID { get; set; }
        public bool reserved { get; set; }
    }
}