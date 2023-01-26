using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechnicalAssessment.Models
{
    public class Book
    {
        [Key] public int ID { get; set; }
        public string bookName { get; set; }
        public string bookID { get; set; }
        public Boolean reserved { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}