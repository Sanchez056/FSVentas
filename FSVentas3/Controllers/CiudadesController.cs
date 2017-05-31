using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FSVentas2.DAL;
using FSVentas3.Models;

namespace FSVentas3.Controllers
{
    public class CiudadesController : Controller
    {
        private FSVentasDb db = new FSVentasDb();

        // GET: Ciudades
        public ActionResult Index()
        {
            var ciudades = db.Ciudades.Include(c => c.Provincias);
            return View(ciudades.ToList());
        }

        // GET: Ciudades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudades ciudades = db.Ciudades.Find(id);
            if (ciudades == null)
            {
                return HttpNotFound();
            }
            return View(ciudades);
        }

        // GET: Ciudades/Create
        public ActionResult Create()
        {
            ViewBag.ProvinciaId = new SelectList(db.Provincias, "ProvinciaId", "ProvinciaNombre");
            return View();
        }

        // POST: Ciudades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CiudadId,CiudadNombre,ProvinciaId")] Ciudades ciudades)
        {
            if (ModelState.IsValid)
            {
                db.Ciudades.Add(ciudades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProvinciaId = new SelectList(db.Provincias, "ProvinciaId", "ProvinciaNombre", ciudades.ProvinciaId);
            return View(ciudades);
        }

        // GET: Ciudades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudades ciudades = db.Ciudades.Find(id);
            if (ciudades == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProvinciaId = new SelectList(db.Provincias, "ProvinciaId", "ProvinciaNombre", ciudades.ProvinciaId);
            return View(ciudades);
        }

        // POST: Ciudades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CiudadId,CiudadNombre,ProvinciaId")] Ciudades ciudades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ciudades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProvinciaId = new SelectList(db.Provincias, "ProvinciaId", "ProvinciaNombre", ciudades.ProvinciaId);
            return View(ciudades);
        }

        // GET: Ciudades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudades ciudades = db.Ciudades.Find(id);
            if (ciudades == null)
            {
                return HttpNotFound();
            }
            return View(ciudades);
        }

        // POST: Ciudades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ciudades ciudades = db.Ciudades.Find(id);
            db.Ciudades.Remove(ciudades);
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
