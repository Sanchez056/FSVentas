using FSVentas2.DAL;
using FSVentas3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FSVentas3.BLL
{
    public class CategoriasBLL
    {
        Categorias categoria = new Categorias();

        public static bool Insertar(Categorias c)
        {
            bool retornar = false;
            using (var db = new FSVentasDb())
            {
                try
                {
                    if (Buscar(c.CategoriaId) == null)
                    {
                        db.Categorias.Add(c);
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
        

        public static Categorias Buscar(int id)
        {
            var db = new FSVentasDb();

            return db.Categorias.Find(id);


        }



        public static bool Eliminar(int id)
        {
            //bool retorna = false;
            try
            {

                using (var db = new FSVentasDb())
                {
                    Categorias c = new Categorias();
                    c = db.Categorias.Find(id);

                    db.Categorias.Remove(c);
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




        public static List<Categorias> GetLista()
        {
            List<Categorias> lista = new List<Categorias>();

            var db = new FSVentasDb();

            lista = db.Categorias.ToList();

            return lista;


        }



        public static List<Categorias> GetLista(int id)
        {
            List<Categorias> lista = new List<Categorias>();

            var db = new FSVentasDb();

            lista = db.Categorias.Where(p => p.CategoriaId == id).ToList();

            return lista;

        }



        public static List<Categorias> GetListaDescripcion(string aux)
        {
            List<Categorias> lista = new List<Categorias>();

            var db = new FSVentasDb();

            lista = db.Categorias.Where(p => p.Descripcion == aux).ToList();

            return lista;

        }
    }
}
