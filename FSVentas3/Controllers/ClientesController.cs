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
using FSVentas3.Models;

namespace FSVentas3.Controllers
{
    public class ClientesController : Controller
    {
        private FSVentasDb db = new FSVentasDb();

      
        // GET: Clientes
        public ActionResult Consulta()
        {
            return View();
        }

        // GET: Clientes/Details/5
        public ActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // GET: Clientes/Create
        public ActionResult Crear()
        {
            /*
            if (id != 0)
            {
                ViewBag.paises = PaisesBLL.GetLista();
                ViewBag.ciudades = CiudadesBLL.GetLista();
                ViewBag.municipios = MunicipiosBLL.GetLista();
                ViewBag.localidades = LocalidadesBLL.GetLista();
            }
            else
            {
                ViewBag.paises = PaisesBLL.GetLista();
                ViewBag.ciudades = "";
                ViewBag.municipios = "";
                ViewBag.localidades = "";
            }

            ViewBag.Titulo = "Catálogo Aval";
            return View(id == 0 ? new PaisesBLL():
            C.ListarAval(id));
            */
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                ClientesBLL.Insertar(clientes);
                return RedirectToAction("Consulta");
            }

            return View(clientes);
        }

        // GET: Clientes/Edit/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar( Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                ClientesBLL.Insertar(clientes);
                return RedirectToAction("Consulta");
            }
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientesBLL.Eliminar(id);
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
