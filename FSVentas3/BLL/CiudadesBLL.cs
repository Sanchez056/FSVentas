using FSVentas2.DAL;
using FSVentas3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FSVentas3.BLL
{
    public class CiudadesBLL
    {
        public static List<Ciudades> GetLista()
        {
            List<Ciudades> lista = new List<Ciudades>();

            var db = new FSVentasDb();

            lista = db.Ciudades.ToList();

            return lista;


        }



        public static List<Ciudades> GetLista(int id)
        {
            List<Ciudades> lista = new List<Ciudades>();

            var db = new FSVentasDb();

            lista = db.Ciudades.Where(p => p.CiudadId == id).ToList();

            return lista;

        }
    }
}