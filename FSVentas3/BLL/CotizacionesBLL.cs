using FSVentas2.DAL;
using FSVentas3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace FSVentas3.BLL
{
    public class CotizacionesBLL
    {
        public static bool Insertar(Cotizaciones a)
        {

            bool retornar = false;
            using (var db = new FSVentasDb())
            {
                try
                {
                    if (Buscar(a.CotizacionId) == null)
                    {
                        db.Cotizaciones.Add(a);
                    }
                    else
                        db.Entry(a).State = EntityState.Modified;
                    db.SaveChanges();

                    retornar = true;

                }
                catch (Exception)
                {
                    throw;
                }
                return retornar;
            }
        }


        public static Cotizaciones Buscar(int id)
        {
            var cotizaciones = new Cotizaciones();
            using (var db = new FSVentasDb())
            {
                try
                {
                    cotizaciones = db.Cotizaciones.Find(id);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return cotizaciones;

        }
        public static Cotizaciones BuscarNombre(string nombre)
        {
            var db = new FSVentasDb();

            return db.  Cotizaciones.Find(nombre);

        }


        public static bool Eliminar(int id)
        {
            //bool retorna = false;
            try
            {

                using (var db = new FSVentasDb())
                {
                    Cotizaciones a = new Cotizaciones();
                    a = db.Cotizaciones.Find(id);

                    db.Cotizaciones.Remove(a);
                    db.SaveChanges();
                    //db.Dispose();
                    return false;
                }


            }
            catch (Exception)
            {
                return true;
                throw;


            }

        }








        public static List<Cotizaciones> GetLista()
        {
            List<Cotizaciones> lista = new List<Cotizaciones>();

            using (var db = new FSVentasDb())
            {
                try
                {
                    lista = db.Cotizaciones.ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                return lista;
            }


        }



        public static List<Cotizaciones> GetLista(int Id)
        {
            List<Cotizaciones> lista = new List<Cotizaciones>();

            using (var db = new FSVentasDb())
            {
                try
                {
                    lista = db.Cotizaciones.Where(p => p.CotizacionId == Id).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return lista;

        }



       
       
        public static double GetListaPrecio(int id)
        {
            double precio = 0;
            using (var db = new FSVentasDb())
            {
                try
                {
                    Cotizaciones a = db.Cotizaciones.Where(aO => aO.CotizacionId == id).FirstOrDefault();
                    precio = a.Precio;
                }
                catch (Exception)
                {
                    throw;
                }
                return precio;
            }

        }





        public static List<Cotizaciones> GetListaFecha(DateTime aux)
        {
            List<Cotizaciones> lista = new List<Cotizaciones>();

            var db = new FSVentasDb();

            lista = db.Cotizaciones.Where(p => p.Fecha == aux).ToList();

            return lista;

        }
       

    }
}



   
