using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantManagement.Models;

namespace RestaurantManagement.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {

            return View(new Reservation());
        }

        [HttpPost]
        public ActionResult MakeReservation(Reservation info)
        {
            var reservation = new Reservation
            {
                FirstName = info.FirstName,
                LastName = info.LastName,
                Phone = info.Phone,
                ReservationDate = info.ReservationDate,
                ReservationTime = info.ReservationTime,
                NumberOfGuests = info.NumberOfGuests
            };



            db.Reservation.Add(reservation);
            db.SaveChanges();

            //var reso = db.Reservation.SingleOrDefault(r => r.FirstName == info.FirstName);

            return View("ReservationConfirmation",reservation);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}