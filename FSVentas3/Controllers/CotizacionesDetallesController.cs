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
    public class CotizacionesDetallesController : Controller
    {
        private FSVentasDb db = new FSVentasDb();

        // GET: CotizacionesDetalles
        public ActionResult Index()
        {
            var cotizacionesDetalles = db.CotizacionesDetalles.Include(c => c.Articulos).Include(c => c.Cotizaciones);
            return View(cotizacionesDetalles.ToList());
        }

        // GET: CotizacionesDetalles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CotizacionesDetalles cotizacionesDetalles = db.CotizacionesDetalles.Find(id);
            if (cotizacionesDetalles == null)
            {
                return HttpNotFound();
            }
            return View(cotizacionesDetalles);
        }

        // GET: CotizacionesDetalles/Create
        public ActionResult Create()
        {
            ViewBag.ArticuloId = new SelectList(db.Articulos, "ArticuloId", "Nombre");
            ViewBag.CotizacionId = new SelectList(db.Cotizaciones, "CotizacionId", "CotizacionId");
            return View();
        }

        // POST: CotizacionesDetalles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,Cantidad,Precio,CotizacionId,ArticuloId")] CotizacionesDetalles cotizacionesDetalles)
        {
            if (ModelState.IsValid)
            {
                db.CotizacionesDetalles.Add(cotizacionesDetalles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArticuloId = new SelectList(db.Articulos, "ArticuloId", "Nombre", cotizacionesDetalles.ArticuloId);
            ViewBag.CotizacionId = new SelectList(db.Cotizaciones, "CotizacionId", "CotizacionId", cotizacionesDetalles.CotizacionId);
            return View(cotizacionesDetalles);
        }

        public JsonResult Save(List<CotizacionesDetalles> detalles)
        {
            bool resultado = DetalleCotizacionesBLL.Save(detalles);

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        // GET: CotizacionesDetalles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CotizacionesDetalles cotizacionesDetalles = db.CotizacionesDetalles.Find(id);
            if (cotizacionesDetalles == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticuloId = new SelectList(db.Articulos, "ArticuloId", "Nombre", cotizacionesDetalles.ArticuloId);
            ViewBag.CotizacionId = new SelectList(db.Cotizaciones, "CotizacionId", "CotizacionId", cotizacionesDetalles.CotizacionId);
            return View(cotizacionesDetalles);
        }

        // POST: CotizacionesDetalles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,Cantidad,Precio,CotizacionId,ArticuloId")] CotizacionesDetalles cotizacionesDetalles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cotizacionesDetalles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArticuloId = new SelectList(db.Articulos, "ArticuloId", "Nombre", cotizacionesDetalles.ArticuloId);
            ViewBag.CotizacionId = new SelectList(db.Cotizaciones, "CotizacionId", "CotizacionId", cotizacionesDetalles.CotizacionId);
            return View(cotizacionesDetalles);
        }

        // GET: CotizacionesDetalles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CotizacionesDetalles cotizacionesDetalles = db.CotizacionesDetalles.Find(id);
            if (cotizacionesDetalles == null)
            {
                return HttpNotFound();
            }
            return View(cotizacionesDetalles);
        }

        // POST: CotizacionesDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CotizacionesDetalles cotizacionesDetalles = db.CotizacionesDetalles.Find(id);
            db.CotizacionesDetalles.Remove(cotizacionesDetalles);
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
