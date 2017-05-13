using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FSVentas2.DAL;
using FSVentas2.Models;

namespace FSVentas3.Controllers
{
    public class TipoUsuariosController : Controller
    {
        private FSVentasDb db = new FSVentasDb();

        // GET: TipoUsuarios
        public ActionResult Index()
        {
            return View(db.TipoUsuarios.ToList());
        }

        // GET: TipoUsuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoUsuarios tipoUsuarios = db.TipoUsuarios.Find(id);
            if (tipoUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(tipoUsuarios);
        }

        // GET: TipoUsuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoUsuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoId,Detalle")] TipoUsuarios tipoUsuarios)
        {
            if (ModelState.IsValid)
            {
                db.TipoUsuarios.Add(tipoUsuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoUsuarios);
        }

        // GET: TipoUsuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoUsuarios tipoUsuarios = db.TipoUsuarios.Find(id);
            if (tipoUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(tipoUsuarios);
        }

        // POST: TipoUsuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoId,Detalle")] TipoUsuarios tipoUsuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoUsuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoUsuarios);
        }

        // GET: TipoUsuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoUsuarios tipoUsuarios = db.TipoUsuarios.Find(id);
            if (tipoUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(tipoUsuarios);
        }

        // POST: TipoUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoUsuarios tipoUsuarios = db.TipoUsuarios.Find(id);
            db.TipoUsuarios.Remove(tipoUsuarios);
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
