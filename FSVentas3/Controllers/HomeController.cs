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


        [HttpPost]
        public ActionResult Index(string Countries, string States)
        {

            int stateId = -1;
            if (!int.TryParse(States, out stateId))
            {
                ViewBag.YouSelected = "You must select a Country and State";
                return View();
            }

            var state = from s in State.GetStates()
                        where s.StateId == stateId
                        select s.StateName;

            var country = from s in Country.GetCountries()
                          where s.CountryId == Countries
                          select s.CountryName;


            ViewBag.YouSelected = "You selected " + country.SingleOrDefault()
                                 + " And " + state.SingleOrDefault();
            return View("Info");
        }

       

        public SelectList GetCountrySelectList()
        {

            var countries = Country.GetCountries();
            return new SelectList(countries.ToArray(),
                                "CountryId",
                                "CountryName");

        }

        public ActionResult Index()
        {

            ViewBag.Country = GetCountrySelectList();
            return View();
        }

       

        public ActionResult CountryList()
        {
            var countries = Country.GetCountries();

            if (HttpContext.Request.IsAjaxRequest())
                return Json(GetCountrySelectList(), JsonRequestBehavior.AllowGet);

            return RedirectToAction("Index");
        }

        public ActionResult StateList(string ID)
        {
            string Code = ID;
            var states = from s in State.GetStates()
                         where s.CountryId == Code
                         select s;

            if (HttpContext.Request.IsAjaxRequest())
                return Json(new SelectList(
                                states.ToArray(),
                                "StateId",
                                "StateName")
                           , JsonRequestBehavior.AllowGet);

            return RedirectToAction("Index");
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
