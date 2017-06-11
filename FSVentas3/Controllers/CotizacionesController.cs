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
using FSVentas3.BLL;

namespace FSVentas3.Controllers
{
    public class CotizacionesController : Controller
    {
        private FSVentasDb db = new FSVentasDb();

        // GET: Cotizaciones
        public ActionResult Index()
        {
            var cotizaciones = db.Cotizaciones.Include(c => c.Articulos).Include(c => c.Clientes);
            return View(cotizaciones.ToList());
        }

        // GET: Cotizaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotizaciones cotizaciones = db.Cotizaciones.Find(id);
            if (cotizaciones == null)
            {
                return HttpNotFound();
            }
            return View(cotizaciones);
        }

        // GET: Cotizaciones/Create
        public ActionResult Create()
        {
            ViewBag.ArticuloId = new SelectList(db.Articulos, "ArticuloId", "Nombre");
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombre");
            return View();
        }

        // POST: Cotizaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CotizacionId,ClienteId,ArticuloId,Fecha,Precio")] Cotizaciones cotizaciones)
        {
            if (ModelState.IsValid)
            {
                db.Cotizaciones.Add(cotizaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArticuloId = new SelectList(db.Articulos, "ArticuloId", "Nombre", cotizaciones.ArticuloId);
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombre", cotizaciones.ClienteId);
            return View(cotizaciones);
        }
        public JsonResult Save(Cotizaciones cotizacion)
        {
            int id = 0; if (ModelState.IsValid) { if (CotizacionesBLL.Insertar(cotizacion)) { id = cotizacion.CotizacionId; } } else { id = +1; }
            return Json(id, JsonRequestBehavior.AllowGet);
        }



        // GET: Cotizaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotizaciones cotizaciones = db.Cotizaciones.Find(id);
            if (cotizaciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticuloId = new SelectList(db.Articulos, "ArticuloId", "Nombre", cotizaciones.ArticuloId);
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombre", cotizaciones.ClienteId);
            return View(cotizaciones);
        }

        // POST: Cotizaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CotizacionId,ClienteId,ArticuloId,Fecha,Precio")] Cotizaciones cotizaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cotizaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArticuloId = new SelectList(db.Articulos, "ArticuloId", "Nombre", cotizaciones.ArticuloId);
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombre", cotizaciones.ClienteId);
            return View(cotizaciones);
        }

        // GET: Cotizaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotizaciones cotizaciones = db.Cotizaciones.Find(id);
            if (cotizaciones == null)
            {
                return HttpNotFound();
            }
            return View(cotizaciones);
        }

        // POST: Cotizaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cotizaciones cotizaciones = db.Cotizaciones.Find(id);
            db.Cotizaciones.Remove(cotizaciones);
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
