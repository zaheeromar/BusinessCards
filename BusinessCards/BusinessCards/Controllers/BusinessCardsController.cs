using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessCards.Models;

namespace BusinessCards.Controllers
{
    public class BusinessCardsController : Controller
    {
        private BusinessCardDBContext db = new BusinessCardDBContext();

        // GET: BusinessCards
        public ActionResult Index(string searchString)
        {
            var businessCards = from m in db.BusinessCards
                                select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                businessCards = businessCards.Where(s => s.Name.Contains(searchString));
            }

            return View(businessCards);
        }

        // GET: BusinessCards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessCard businessCard = db.BusinessCards.Find(id);
            if (businessCard == null)
            {
                return HttpNotFound();
            }
            return View(businessCard);
        }

        // GET: BusinessCards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusinessCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,CompanyName,Position,Address,Number,Email")] BusinessCard businessCard)
        {
            if (ModelState.IsValid)
            {
                db.BusinessCards.Add(businessCard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(businessCard);
        }

        // GET: BusinessCards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessCard businessCard = db.BusinessCards.Find(id);
            if (businessCard == null)
            {
                return HttpNotFound();
            }
            return View(businessCard);
        }

        // POST: BusinessCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,CompanyName,Position,Address,Number,Email")] BusinessCard businessCard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(businessCard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(businessCard);
        }

        // GET: BusinessCards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessCard businessCard = db.BusinessCards.Find(id);
            if (businessCard == null)
            {
                return HttpNotFound();
            }
            return View(businessCard);
        }

        // POST: BusinessCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BusinessCard businessCard = db.BusinessCards.Find(id);
            db.BusinessCards.Remove(businessCard);
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
