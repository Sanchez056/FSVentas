using FSVentas2.DAL;
using FSVentas3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FSVentas3.BLL
{
    public class StateBLL
    {
        public static List<State> GetLista()
        {
            List<State> lista = new List<State>();

            var db = new FSVentasDb();

            lista = db.States.ToList();

            return lista;


        }



        public static List<State> GetLista(int id)
        {
            List<State> lista = new List<State>();

            var db = new FSVentasDb();

            lista = db.States.Where(p => p.StateId == id).ToList();

            return lista;

        }
    }
}