using FSVentas2.DAL;
using FSVentas3.BLL;
using FSVentas3.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FSVentas3.Controllers
{
    public class HomeController : Controller
    {
        private FSVentasDb db = new FSVentasDb();

        public ActionResult Index()

        {




            return View();

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

