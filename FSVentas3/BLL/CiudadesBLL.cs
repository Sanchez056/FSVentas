using FSVentas2.DAL;
using FSVentas3.Models.Direccion;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FSVentas3.BLL
{
    public class CiudadesBLL
    {
        Ciudades ciudades = new Ciudades();
/*
        public static bool Insertar(Ciudades c)
        {
            bool retornar = false;
            using (var db = new FSVentasDb())
            {
                try
                {
                    if (Buscar(c.) == null)
                    {
                        db.Ciudades.Add(c);
                    }
                    else
                        db.Entry(c).State = EntityState.Modified;
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


        public static Ciudades Buscar(int id)
        {
            var db = new FSVentasDb();

            return db.Ciudades.Find(id);


        }



        public static bool Eliminar(int id)
        {
            //bool retorna = false;
            try
            {

                using (var db = new FSVentasDb())
                {
                    Ciudades c = new Ciudades();
                    c = db.Ciudades.Find(id);

                    db.Ciudades.Remove(c);
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

            lista = db.Ciudades.Where(p => p.IdCiudad == id).ToList();

            return lista;

        }



        public static List<Ciudades> GetListaDescripcion(string aux)
        {
            List<Ciudades> lista = new List<Ciudades>();

            var db = new FSVentasDb();

            lista = db.Ciudades.Where(p => p.NombreCiudad == aux).ToList();

            return lista;

        }
        */
    }
}
