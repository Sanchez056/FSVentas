using FSVentas2.DAL;
using FSVentas3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FSVentas3.BLL
{
    public class CityBLL
    {
        public static List<City> GetLista()
        {
            List<City> lista = new List<City>();

            var db = new FSVentasDb();

            lista = db.Citys.ToList();

            return lista;


        }



        public static List<City> GetLista(int id)
        {
            List<City> lista = new List<City>();

            var db = new FSVentasDb();

            lista = db.Citys.Where(p => p.CityId == id).ToList();

            return lista;

        }
    }
}