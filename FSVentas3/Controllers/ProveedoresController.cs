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
using FSVentas3.BLL;

namespace FSVentas3.Controllers
{
    public class ProveedoresController : Controller
    {
        private FSVentasDb db = new FSVentasDb();

        // GET: Proveedores
        public ActionResult Consulta()
        {
            return View(ProveedoresBLL.GetLista());
        }

        // GET: Proveedores/Details/5
        public ActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedores proveedores = db.Proveedores.Find(id);
            if (proveedores == null)
            {
                return HttpNotFound();
            }
            return View(proveedores);
        }

        // GET: Proveedores/Create
        public ActionResult Crear()
        {
            return View();
        }

        // POST: Proveedores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear( Proveedores proveedores)
        {
            if (ModelState.IsValid)
            {
                ProveedoresBLL.Insertar(proveedores);
                return RedirectToAction("Consulta");
            }

            return View(proveedores);
        }

        // GET: Proveedores/Edit/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedores proveedores = db.Proveedores.Find(id);
            if (proveedores == null)
            {
                return HttpNotFound();
            }
            return View(proveedores);
        }

        // POST: Proveedores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Proveedores proveedores)
        {
            if (ModelState.IsValid)
            {
                ProveedoresBLL.Insertar(proveedores);
                return RedirectToAction("Consulta");
            }
            return View(proveedores);
        }

        // GET: Proveedores/Delete/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedores proveedores = db.Proveedores.Find(id);
            if (proveedores == null)
            {
                return HttpNotFound();
            }
            return View(proveedores);
        }

        // POST: Proveedores/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProveedoresBLL.Eliminar(id);
            return RedirectToAction("Consulta");
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
