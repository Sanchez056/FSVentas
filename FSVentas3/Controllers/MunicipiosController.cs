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
    public class MunicipiosController : Controller
    {
        private FSVentasDb db = new FSVentasDb();

        // GET: Municipios
        public ActionResult Index()
        {
            var municipios = db.Municipios.Include(m => m.Ciudades).Include(m => m.Provincias);
            return View(municipios.ToList());
        }

        // GET: Municipios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Municipios municipios = db.Municipios.Find(id);
            if (municipios == null)
            {
                return HttpNotFound();
            }
            return View(municipios);
        }

        // GET: Municipios/Create
        public ActionResult Create()
        {
            List<Provincias> lstProvincia = db.Provincias.ToList();
            lstProvincia.Insert(0, new Provincias{ ProvinciaId = 0,ProvinciaNombre = "--Select Provincia--" });
            List<Ciudades> lstCiudades = new List<Ciudades>();
            ViewBag.ProvinciaId = new SelectList(lstProvincia, "ProvinciaId", "ProvinciaNombre");
            ViewBag.CiudadId = new SelectList(lstCiudades, "CiudadId", "CiudadNombre");
            return View();
        }

        // POST: Municipios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MunicipioId,MunicipioNombre,ProvinciaId,CiudadId")] Municipios municipios)
        {
            if (ModelState.IsValid)
            {
                db.Municipios.Add(municipios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CiudadId = new SelectList(db.Ciudades, "CiudadId", "CiudadNombre", municipios.CiudadId);
            ViewBag.ProvinciaId = new SelectList(db.Provincias, "ProvinciaId", "ProvinciaNombre", municipios.ProvinciaId);
            return View(municipios);
        }

        // GET: Municipios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Municipios municipios = db.Municipios.Find(id);
            if (municipios == null)
            {
                return HttpNotFound();
            }
            ViewBag.CiudadId = new SelectList(db.Ciudades, "CiudadId", "CiudadNombre", municipios.CiudadId);
            ViewBag.ProvinciaId = new SelectList(db.Provincias, "ProvinciaId", "ProvinciaNombre", municipios.ProvinciaId);
            return View(municipios);
        }
        public JsonResult GetCiudadByProvinciaId(int id)
        {
            List<Ciudades> ciudades = new List<Ciudades>();
            if (id > 0)
            {
                ciudades = db.Ciudades.Where(p => p.ProvinciaId == id).ToList();

            }
            else
            {
                ciudades.Insert(0, new Ciudades { CiudadId = 0, CiudadNombre = "--Select a category first--" });
            }
            var result = (from r in ciudades
                          select new
                          {
                              id = r.CiudadId,
                              name = r.CiudadNombre
                          }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // POST: Municipios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MunicipioId,MunicipioNombre,ProvinciaId,CiudadId")] Municipios municipios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(municipios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CiudadId = new SelectList(db.Ciudades, "CiudadId", "CiudadNombre", municipios.CiudadId);
            ViewBag.ProvinciaId = new SelectList(db.Provincias, "ProvinciaId", "ProvinciaNombre", municipios.ProvinciaId);
            return View(municipios);
        }

        // GET: Municipios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Municipios municipios = db.Municipios.Find(id);
            if (municipios == null)
            {
                return HttpNotFound();
            }
            return View(municipios);
        }

        // POST: Municipios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Municipios municipios = db.Municipios.Find(id);
            db.Municipios.Remove(municipios);
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
