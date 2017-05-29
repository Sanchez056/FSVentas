using FSVentas2.DAL;
using FSVentas3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FSVentas3.BLL
{
    public class CountryBLL
    {
        public static List<Country> GetLista()
        {
            List<Country> lista = new List<Country>();

            var db = new FSVentasDb();

            lista = db.Countrys.ToList();

            return lista;


        }


/*
        public static List<Country> GetLista(int id)
        {
            List<Country> lista = new List<Country>();

            var db = new FSVentasDb();

            lista = db.Countrys.Where(p => p.CountryId == id).ToList();

            return lista;

        }
        */
    }
    
    

}