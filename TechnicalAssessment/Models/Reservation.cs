using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnicalAssessment.Models
{
    public class Reservation
    {
        public int rID { get; set; }
        public int bID { get; set; }
        public int cID { get; set; }
        public DateTime reservationTime { get; set; }
    }
}