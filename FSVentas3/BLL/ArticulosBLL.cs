using FSVentas2.DAL;
using FSVentas3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FSVentas3.BLL
{
    public class ArticulosBLL
    {

        public static bool Insertar(Articulos a)
        {

            bool retornar = false;
            using (var db = new FSVentasDb())
            {
                try
                {
                    if (Buscar(a.ArticuloId) == null)
                    {
                        db.Articulos.Add(a);
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

       
        public static Articulos Buscar(int id)
        {
            var articulos = new Articulos();
            using (var db = new FSVentasDb())
            {
                try
                {
                    articulos = db.Articulos.Find(id);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return articulos;

        }
        public static Articulos BuscarNombre(string nombre)
        {
            var db = new FSVentasDb();

            return db.Articulos.Find(nombre);

        }


        public static bool Eliminar(int id)
        {
            //bool retorna = false;
            try
            {

                using (var db = new FSVentasDb())
                {
                    Articulos a = new Articulos();
                    a = db.Articulos.Find(id);

                    db.Articulos.Remove(a);
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








        public static List<Articulos> GetLista()
        {
            List<Articulos> lista = new List<Articulos>();

            using (var db = new FSVentasDb())
            {
                try
                {
                    lista = db.Articulos.ToList();
                }
                catch (Exception )
                {
                    throw;
                }
                return lista;
            }


        }



        public static List<Articulos> GetLista(int Id)
        {
            List<Articulos> lista = new List<Articulos>();

            using (var db = new FSVentasDb())
            {
                try
                {
                    lista = db.Articulos.Where(p => p.ArticuloId == Id).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return lista;

        }



        public static List<Articulos> GetListaNombreArticulo(string aux)
        {
            List<Articulos> lista = new List<Articulos>();

            var db = new FSVentasDb();

            lista = db.Articulos.Where(p => p.Nombre == aux).ToList();

            return lista;

        }
        public static List<Articulos> GetListaMarcaArticulo(string aux)
        {
            List<Articulos> lista = new List<Articulos>();

            var db = new FSVentasDb();

            lista = db.Articulos.Where(p => p.Marca == aux).ToList();

            return lista;

        }
        public static double GetListaPrecio(int id)
        {
            double precio = 0;
            using (var db = new FSVentasDb())
            {
                try
                {
                    Articulos a = db.Articulos.Where(aO => aO.ArticuloId == id).FirstOrDefault();
                    precio = a.Precio;
                }
                catch (Exception )
                {
                    throw;
                }
                return precio;
            }

        }





        public static List<Articulos> GetListaFecha(DateTime aux)
        {
            List<Articulos> lista = new List<Articulos>();

            var db = new FSVentasDb();

            lista = db.Articulos.Where(p => p.Fecha == aux).ToList();

            return lista;

        }
        public static List<Articulos> GetListaFecha(DateTime Desde, DateTime Hasta)
        {
            List<Articulos> lista = new List<Articulos>();

            var db = new FSVentasDb();

            lista = db.Articulos.Where(p => p.Fecha >= Desde && p.Fecha <= Hasta).ToList();

            return lista;

        }

    }
}
