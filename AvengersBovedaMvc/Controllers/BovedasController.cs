using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AvengerBovedaMvc.Models;
using AvengersBovedaMvc.Models;

namespace AvengersBovedaMvc.Controllers
{
    public class BovedasController : Controller
    {
        private AvengersDbContext db = new AvengersDbContext();

        // GET: Bovedas
        public ActionResult Index()
        {
            return View(db.Bovedas.ToList());
        }

        // GET: Bovedas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boveda boveda = db.Bovedas.Find(id);
            if (boveda == null)
            {
                return HttpNotFound();
            }
            return View(boveda);
        }

        // GET: Bovedas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bovedas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bovedaID,nombre,ubicacion")] Boveda boveda)
        {
            if (ModelState.IsValid)
            {
                db.Bovedas.Add(boveda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(boveda);
        }

        // GET: Bovedas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boveda boveda = db.Bovedas.Find(id);
            if (boveda == null)
            {
                return HttpNotFound();
            }
            return View(boveda);
        }

        // POST: Bovedas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bovedaID,nombre,ubicacion")] Boveda boveda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boveda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(boveda);
        }

        // GET: Bovedas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boveda boveda = db.Bovedas.Find(id);
            if (boveda == null)
            {
                return HttpNotFound();
            }
            return View(boveda);
        }

        // POST: Bovedas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Boveda boveda = db.Bovedas.Find(id);
            db.Bovedas.Remove(boveda);
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
