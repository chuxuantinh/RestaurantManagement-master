using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestaurantManagement.Models;
using Microsoft.AspNet.Identity;
using Twilio;
using System.Configuration;

namespace RestaurantManagement.Controllers
{
    public class WaitingListsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WaitingLists
        public ActionResult Index()
        {
            return View(db.WaitingList.ToList());
        }

        // GET: WaitingLists/SendText/5
        public ActionResult SendText(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaitingList waitingList = db.WaitingList.Find(id);
            if (waitingList == null)
            {
                return HttpNotFound();
            }

            var message = $"Hello {waitingList.FirstName}, Your table is now ready.  Thank You ";

            var client = new TwilioRestClient(ConfigurationManager.AppSettings["TwilioAccountSid"], ConfigurationManager.AppSettings["TwilioAuthToken"]);
            client.SendMessage(ConfigurationManager.AppSettings["TwilioPhoneNumber"], waitingList.Phone, message);

            return RedirectToAction("Index");
        }

        // GET: WaitingLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WaitingLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Phone")] WaitingList waitingList)
        {
            if (ModelState.IsValid)
            {
                waitingList.DateAndTime = DateTime.Now;
                db.WaitingList.Add(waitingList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(waitingList);
        }

        // GET: WaitingLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaitingList waitingList = db.WaitingList.Find(id);
            if (waitingList == null)
            {
                return HttpNotFound();
            }
            return View(waitingList);
        }

        // POST: WaitingLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Phone,DateAndTime")] WaitingList waitingList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(waitingList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(waitingList);
        }

        // GET: WaitingLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaitingList waitingList = db.WaitingList.Find(id);
            if (waitingList == null)
            {
                return HttpNotFound();
            }
            return View(waitingList);
        }

        // POST: WaitingLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WaitingList waitingList = db.WaitingList.Find(id);
            db.WaitingList.Remove(waitingList);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
