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
    public class TipoUsuariosController : Controller
    {
        private FSVentasDb db = new FSVentasDb();

        // GET: TipoUsuarios
        public ActionResult Consulta()
        {
            return View(TipoUsuariosBLL.GetLista());
        }

        // GET: TipoUsuarios/Details/5
        public ActionResult Detalle(int? id)
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
        public ActionResult Crear()
        {
            return View();
        }

        // POST: TipoUsuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear( TipoUsuarios tipoUsuarios)
        {
            if (ModelState.IsValid)
            {
                TipoUsuariosBLL.Insertars(tipoUsuarios);
                return RedirectToAction("Consulta");
            }

            return View(tipoUsuarios);
        }

        // GET: TipoUsuarios/Edit/5
        public ActionResult Editar(int? id)
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
        public ActionResult Editar(TipoUsuarios tipoUsuarios)
        {
            if (ModelState.IsValid)
            {
                TipoUsuariosBLL.Insertars(tipoUsuarios);
                return RedirectToAction("Consulta");
            }
            return View(tipoUsuarios);
        }

        // GET: TipoUsuarios/Delete/5
        public ActionResult Eliminar(int? id)
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
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoUsuariosBLL.Eliminar(id);
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
