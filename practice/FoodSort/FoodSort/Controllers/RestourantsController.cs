using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FoodSort.Models;

namespace FoodSort.Controllers
{
    public class RestourantsController : Controller
    {
        private FoodSortDb db = new FoodSortDb();

        // GET: Restourants
        public ActionResult Index()
        {
            return View(db.Restourants.ToList());
        }

        // GET: Restourants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restourant restourant = db.Restourants.Find(id);
            if (restourant == null)
            {
                return HttpNotFound();
            }
            return View(restourant);
        }

        // GET: Restourants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restourants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,City,Country")] Restourant restourant)
        {
            if (ModelState.IsValid)
            {
                db.Restourants.Add(restourant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restourant);
        }

        // GET: Restourants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restourant restourant = db.Restourants.Find(id);
            if (restourant == null)
            {
                return HttpNotFound();
            }
            return View(restourant);
        }

        // POST: Restourants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,City,Country")] Restourant restourant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restourant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restourant);
        }

        // GET: Restourants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restourant restourant = db.Restourants.Find(id);
            if (restourant == null)
            {
                return HttpNotFound();
            }
            return View(restourant);
        }

        // POST: Restourants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restourant restourant = db.Restourants.Find(id);
            db.Restourants.Remove(restourant);
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
