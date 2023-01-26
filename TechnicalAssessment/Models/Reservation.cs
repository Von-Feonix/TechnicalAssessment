using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechnicalAssessment.Models
{
    public class Reservation
    {
        [Key] public int ReservationID { get; set; }
        public virtual Book Book { get; set; }
        public string reservationTime { get; set; }
        public string returnTime { get; set; }
    }
}