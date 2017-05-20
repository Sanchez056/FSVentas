using FSVentas2.DAL;
using FSVentas2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FSVentas3.BLL
{
    public class ProveedoresBLL
    {
        Proveedores proveedores = new Proveedores();

        public static bool Insertar(Proveedores p)
        {
            bool retornar = false;
            using (var db = new FSVentasDb())
            {
                try
                {
                    if (Buscar(p.ProveedorId) == null)
                    {
                        db.Proveedores.Add(p);
                    }
                    else
                        db.Entry(p).State = EntityState.Modified;
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
       


        public static Proveedores Buscar(int id)
        {
            var db = new FSVentasDb();

            return db.Proveedores.Find(id);


        }

        public static bool Eliminar(int id)
        {
            //bool retorna = false;
            try
            {

                using (var db = new FSVentasDb())
                {
                    Proveedores p = new Proveedores();
                    p = db.Proveedores.Find(id);

                    db.Proveedores.Remove(p);
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


        public static List<Proveedores> GetLista()
        {
            List<Proveedores> lista = new List<Proveedores>();

            var db = new FSVentasDb();

            lista = db.Proveedores.ToList();

            return lista;


        }

        public static List<Proveedores> GetLista(int proveedorId)
        {
            List<Proveedores> lista = new List<Proveedores>();

            var db = new FSVentasDb();

            lista = db.Proveedores.Where(p => p.ProveedorId == proveedorId).ToList();

            return lista;

        }



        public static List<Proveedores> GetListaNombreProveedor(string aux)
        {
            List<Proveedores> lista = new List<Proveedores>();

            var db = new FSVentasDb();

            lista = db.Proveedores.Where(p => p.Nombre == aux).ToList();

            return lista;

        }




        public static List<Proveedores> GetListaFecha(DateTime aux)
        {
            List<Proveedores> lista = new List<Proveedores>();

            var db = new FSVentasDb();

            lista = db.Proveedores.Where(p => p.Fecha == aux).ToList();

            return lista;

        }
        public static List<Proveedores> GetListaFecha(DateTime Desde, DateTime Hasta)
        {
            List<Proveedores> lista = new List<Proveedores>();

            var db = new FSVentasDb();

            lista = db.Proveedores.Where(p => p.Fecha >= Desde && p.Fecha <= Hasta).ToList();

            return lista;

        }



    }
}
