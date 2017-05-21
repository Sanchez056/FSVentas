using FSVentas3.Models.Direccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FSVentas3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CiudadesList()
        {
            IQueryable ciudades = Ciudades.GetCiudades();

            if(HttpContext.Request.IsAjaxRequest())
            {
                return Json(new SelectList(
                    ciudades,
                    "CodigoCiudad",
                    "NombreCiudad"), JsonRequestBehavior.AllowGet
                    );
            }
           return View(ciudades);
        }
        public ActionResult MunicipioList(string codigo)
        {
            IQueryable municipio = Municipios.GetMunicipio().Where(x=>x.CodigoCiudad==codigo);

            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(new SelectList(
                    municipio,
                    "MunicipioId",
                    "NombreMunicipio"), JsonRequestBehavior.AllowGet
                    );
            }

            return View(municipio);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}