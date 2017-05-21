using FSVentas2.DAL;
using FSVentas3.Models.Direccion;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FSVentas3.BLL
{
    public class MunicipiosBLL
    {
        Municipiosm municipios = new Municipiosm();

        public static bool Insertar(Municipiosm m)
        {
            bool retornar = false;
            using (var db = new FSVentasDb())
            {
                try
                {
                    if (Buscar(m.Id) == null)
                    {
                        db.Municipios.Add(m);
                    }
                    else
                        db.Entry(m).State = EntityState.Modified;
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


        public static Municipiosm Buscar(int id)
        {
            var db = new FSVentasDb();

            return db.Municipios.Find(id);


        }



        public static bool Eliminar(int id)
        {
            //bool retorna = false;
            try
            {

                using (var db = new FSVentasDb())
                {
                    Municipiosm c = new Municipiosm();
                    c = db.Municipios.Find(id);

                    db.Municipios.Remove(c);
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




        public static List<Municipiosm> GetLista()
        {
            List<Municipiosm> lista = new List<Municipiosm>();

            var db = new FSVentasDb();

            lista = db.Municipios.ToList();

            return lista;


        }



        public static List<Municipiosm> GetLista(int id)
        {
            List<Municipiosm> lista = new List<Municipiosm>();

            var db = new FSVentasDb();

            lista = db.Municipios.Where(p => p.Id== id).ToList();

            return lista;

        }



        public static List<Municipiosm> GetListaDescripcion(string aux)
        {
            List<Municipiosm> lista = new List<Municipiosm>();

            var db = new FSVentasDb();

            lista = db.Municipios.Where(p => p.Nombre == aux).ToList();

            return lista;

        }
    }
}
