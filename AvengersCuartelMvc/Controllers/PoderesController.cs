using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AvengersCuartelMvc.Models;

namespace AvengersCuartelMvc.Controllers
{
    public class PoderesController : Controller
    {
        private AvengersDbContext db = new AvengersDbContext();

        // GET: Poderes
        public ActionResult Index()
        {
            return View(db.Poderes.ToList());
        }

        // GET: Poderes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poder poder = db.Poderes.Find(id);
            if (poder == null)
            {
                return HttpNotFound();
            }
            return View(poder);
        }

        // GET: Poderes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Poderes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PoderId,Nombre")] Poder poder)
        {
            if (ModelState.IsValid)
            {
                db.Poderes.Add(poder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(poder);
        }

        // GET: Poderes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poder poder = db.Poderes.Find(id);
            if (poder == null)
            {
                return HttpNotFound();
            }
            return View(poder);
        }

        // POST: Poderes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PoderId,Nombre")] Poder poder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(poder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(poder);
        }

        // GET: Poderes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poder poder = db.Poderes.Find(id);
            if (poder == null)
            {
                return HttpNotFound();
            }
            return View(poder);
        }

        // POST: Poderes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Poder poder = db.Poderes.Find(id);
            db.Poderes.Remove(poder);
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
