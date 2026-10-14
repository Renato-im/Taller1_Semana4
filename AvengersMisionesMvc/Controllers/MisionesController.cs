using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AvengersMisionesMvc.Models;

namespace AvengersMisionesMvc.Controllers
{
    public class MisionesController : Controller
    {
        private AvengersDbContext db = new AvengersDbContext();

        // GET: Misiones
        public ActionResult Index()
        {
            var misiones = db.Misiones.Include(m => m.Heroe);
            return View(misiones.ToList());
        }

        // GET: Misiones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mision mision = db.Misiones.Find(id);
            if (mision == null)
            {
                return HttpNotFound();
            }
            return View(mision);
        }

        // GET: Misiones/Create
        public ActionResult Create()
        {
            ViewBag.HeroeId = new SelectList(db.Heroes, "HeroeId", "Alias");
            return View();
        }

        // POST: Misiones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MisionId,Titulo,Amenaza,Estado,HeroeId")] Mision mision)
        {
            if (ModelState.IsValid)
            {
                db.Misiones.Add(mision);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HeroeId = new SelectList(db.Heroes, "HeroeId", "Alias", mision.HeroeId);
            return View(mision);
        }

        // GET: Misiones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mision mision = db.Misiones.Find(id);
            if (mision == null)
            {
                return HttpNotFound();
            }
            ViewBag.HeroeId = new SelectList(db.Heroes, "HeroeId", "Alias", mision.HeroeId);
            return View(mision);
        }

        // POST: Misiones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MisionId,Titulo,Amenaza,Estado,HeroeId")] Mision mision)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mision).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HeroeId = new SelectList(db.Heroes, "HeroeId", "Alias", mision.HeroeId);
            return View(mision);
        }

        // GET: Misiones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mision mision = db.Misiones.Find(id);
            if (mision == null)
            {
                return HttpNotFound();
            }
            return View(mision);
        }

        // POST: Misiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mision mision = db.Misiones.Find(id);
            db.Misiones.Remove(mision);
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
