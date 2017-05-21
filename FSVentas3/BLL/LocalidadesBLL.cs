using FSVentas2.DAL;
using FSVentas3.Models.Direccion;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FSVentas3.BLL
{
    public class LocalidadesBLL
    {
        Localidades localidades = new Localidades();

        public static bool Insertar(Localidades l)
        {
            bool retornar = false;
            using (var db = new FSVentasDb())
            {
                try
                {
                    if (Buscar(l.Id) == null)
                    {
                        db.Localidades.Add(l);
                    }
                    else
                        db.Entry(l).State = EntityState.Modified;
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


        public static Localidades Buscar(int id)
        {
            var db = new FSVentasDb();

            return db.Localidades.Find(id);


        }



        public static bool Eliminar(int id)
        {
            //bool retorna = false;
            try
            {

                using (var db = new FSVentasDb())
                {
                    Localidades c = new Localidades();
                    c = db.Localidades.Find(id);

                    db.Localidades.Remove(c);
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




        public static List<Localidades> GetLista()
        {
            List<Localidades> lista = new List<Localidades>();

            var db = new FSVentasDb();

            lista = db.Localidades.ToList();

            return lista;


        }



        public static List<Localidades> GetLista(int id)
        {
            List<Localidades> lista = new List<Localidades>();

            var db = new FSVentasDb();

            lista = db.Localidades.Where(p => p.Id == id).ToList();

            return lista;

        }



        public static List<Localidades> GetListaDescripcion(string aux)
        {
            List<Localidades> lista = new List<Localidades>();

            var db = new FSVentasDb();

            lista = db.Localidades.Where(p => p.Nombre == aux).ToList();

            return lista;

        }
    }
}
