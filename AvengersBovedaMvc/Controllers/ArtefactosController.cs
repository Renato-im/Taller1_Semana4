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
    public class ArtefactosController : Controller
    {
        private AvengersDbContext db = new AvengersDbContext();

        // GET: Artefactos
        public ActionResult Index()
        {
            return View(db.Artefactos.ToList());
        }

        // GET: Artefactos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artefacto artefacto = db.Artefactos.Find(id);
            if (artefacto == null)
            {
                return HttpNotFound();
            }
            return View(artefacto);
        }

        // GET: Artefactos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artefactos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "artefactoID,nombre,poseedor,energia")] Artefacto artefacto)
        {
            if (ModelState.IsValid)
            {
                db.Artefactos.Add(artefacto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artefacto);
        }

        // GET: Artefactos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artefacto artefacto = db.Artefactos.Find(id);
            if (artefacto == null)
            {
                return HttpNotFound();
            }
            return View(artefacto);
        }

        // POST: Artefactos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "artefactoID,nombre,poseedor,energia")] Artefacto artefacto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artefacto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artefacto);
        }

        // GET: Artefactos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artefacto artefacto = db.Artefactos.Find(id);
            if (artefacto == null)
            {
                return HttpNotFound();
            }
            return View(artefacto);
        }

        // POST: Artefactos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artefacto artefacto = db.Artefactos.Find(id);
            db.Artefactos.Remove(artefacto);
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
