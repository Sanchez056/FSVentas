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
        //Post action for Save data to database
        [HttpPost]
        public JsonResult SaveOrder(OrderVM O)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (FSVentasDb dc = new FSVentasDb())
                {
                    Order order = new Order { OrderNo = O.OrderNo, OrderDate = O.OrderDate, Description = O.Description };
                    foreach (var i in O.OrderDetails)
                    {
                        order.OrderDetails.Add(i);
                    }
                    dc.Orders.Add(order);
                    dc.SaveChanges();
                    status = true;
                }
            }
            else
            {
                status = false;
            }
            return new JsonResult { Data = new { status = status } };
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

