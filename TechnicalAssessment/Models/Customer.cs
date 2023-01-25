using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnicalAssessment.Models
{
    public class Customer
    {
        public int cID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}