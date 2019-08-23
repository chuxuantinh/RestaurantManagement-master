using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models
    
{
    public class Reservation
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
        [Display(Name = "Reservation Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ReservationDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}")]
        [Display(Name = "Reservation Time")]
        public DateTime ReservationTime { get; set; }
        [Display(Name = "Number Of Guest")]
        public string NumberOfGuests { get; set; }
        //[ForeignKey("Customer")]
        //public int CustomerId { get; set; }
        //public Customer Customer { get; set; }
    }
}