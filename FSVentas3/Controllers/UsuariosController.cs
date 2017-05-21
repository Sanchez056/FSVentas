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
    public class UsuariosController : Controller
    {
        private FSVentasDb db = new FSVentasDb();
        UsuariosBLL usuarios =new UsuariosBLL();
        public UsuariosController()
        {
            usuarios = new UsuariosBLL();
        }
        // GET: Usuarios
        public ActionResult Consulta()
        {
            //return View(db.Usuarios.ToList());
           
           return View(UsuariosBLL.GetLista());

        }

        // GET: Usuarios/Details/5
        public ActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // GET: Usuarios/Create
        public ActionResult Crear()
        {

            //TipoUsuarios Detalle= new TipoUsuarios();
           
           ViewBag.Tipo = TipoUsuariosBLL.GetLista();
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                UsuariosBLL.Insertar(usuarios);
                //db.Usuarios.Add(usuarios);
                //db.SaveChanges();
                return RedirectToAction("Consulta");
            }

            return View(usuarios);
        }
        Usuarios uss=new  Usuarios();

        // GET: Usuarios/Edit/5
        public ActionResult Editar(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios== null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar( Usuarios usuarios)
        {
            UsuariosBLL.Insertar(usuarios);
            return View(usuarios);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
       
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsuariosBLL.Eliminar(id);
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
