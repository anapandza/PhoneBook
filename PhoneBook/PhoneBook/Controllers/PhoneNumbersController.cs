using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhoneBook.DAL;
using PhoneBook.Models;

namespace PhoneBook.Controllers
{
    public class PhoneNumbersController : Controller
    {
        private PhoneBookContext db = new PhoneBookContext();

        // GET: PhoneNumbers
        public ActionResult Index()
        {
            var phoneNumbers = db.PhoneNumbers.Include(p => p.Contact).Include(p => p.PhoneType);
            return View(phoneNumbers.ToList());
        }

        // GET: PhoneNumbers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhoneNumber phoneNumber = db.PhoneNumbers.Find(id);
            if (phoneNumber == null)
            {
                return HttpNotFound();
            }
            return View(phoneNumber);
        }

        // GET: PhoneNumbers/Create
        public ActionResult Create(int? id)
        {
            if (id != null)
            {
                var contact = db.Contacts.Find(id);
                ViewBag.ContactID = new SelectList(db.Contacts, "ContactID", "Fullname", id);
            }

            else
            {
                ViewBag.ContactID = new SelectList(db.Contacts, "ContactID", "Fullname");
            }

            ViewBag.PhoneTypeID = new SelectList(db.PhoneTypes, "PhoneTypeID", "Type");
            return View();
        }

        // POST: PhoneNumbers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContactID,PhoneTypeID,Number")] PhoneNumber phoneNumber)
        {
            if (ModelState.IsValid)
            {
                // if created phone number is only phone number of  contact then that number is set to default
                Contact contact = db.Contacts.Find(phoneNumber.ContactID);
                if (contact.PhoneNumbers.Count == 0) phoneNumber.Default = true;
                else phoneNumber.Default = false;

                db.PhoneNumbers.Add(phoneNumber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContactID = new SelectList(db.Contacts, "ContactID", "FullName", phoneNumber.ContactID);
            ViewBag.PhoneTypeID = new SelectList(db.PhoneTypes, "PhoneTypeID", "Type", phoneNumber.PhoneTypeID);

            return View(phoneNumber);
        }

        // GET: PhoneNumbers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhoneNumber phoneNumber = db.PhoneNumbers.Find(id);
            if (phoneNumber == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactID = new SelectList(db.Contacts, "ContactID", "FullName", phoneNumber.ContactID);
            ViewBag.PhoneTypeID = new SelectList(db.PhoneTypes, "PhoneTypeID", "Type", phoneNumber.PhoneTypeID);
            return View(phoneNumber);
        }

        // POST: PhoneNumbers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhoneNumberID,ContactID,PhoneTypeID,Number")] PhoneNumber phoneNumber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phoneNumber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContactID = new SelectList(db.Contacts, "ContactID", "FullName", phoneNumber.ContactID);
            ViewBag.PhoneTypeID = new SelectList(db.PhoneTypes, "PhoneTypeID", "Type", phoneNumber.PhoneTypeID);
            return View(phoneNumber);
        }

        // GET: PhoneNumbers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhoneNumber phoneNumber = db.PhoneNumbers.Find(id);
            if (phoneNumber == null)
            {
                return HttpNotFound();
            }
            return View(phoneNumber);
        }

        // POST: PhoneNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhoneNumber phoneNumber = db.PhoneNumbers.Find(id);
            db.PhoneNumbers.Remove(phoneNumber);
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
