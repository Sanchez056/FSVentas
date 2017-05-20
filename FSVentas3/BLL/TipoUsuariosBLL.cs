using FSVentas2.DAL;
using FSVentas2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FSVentas3.BLL
{
    public class TipoUsuariosBLL
    {
        TipoUsuarios usuario = new TipoUsuarios();
        public static bool Insertars(TipoUsuarios t)
        {

            bool retornar = false;
            using (var db = new FSVentasDb())
            {
                try
                {
                    if (Buscar(t.TipoId) == null)
                    {
                        db.TipoUsuarios.Add(t);
                    }
                    else
                        db.Entry(t).State = EntityState.Modified;
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
        


        public static TipoUsuarios Buscar(int id)
        {
            var db = new FSVentasDb();

            return db.TipoUsuarios.Find(id);


        }

        public static bool Eliminar(int id)
        {

            try
            {

                using (var db = new FSVentasDb())
                {
                    TipoUsuarios t = new TipoUsuarios();
                    t = db.TipoUsuarios.Find(id);

                    db.TipoUsuarios.Remove(t);
                    db.SaveChanges();
                    db.Dispose();
                    return false;
                }


            }
            catch (Exception)
            {
                return true;
                throw;


            }
        }
        public static List<TipoUsuarios> GetLista()
        {
            List<TipoUsuarios> lista = new List<TipoUsuarios>();

            var db = new FSVentasDb();

            lista = db.TipoUsuarios.ToList();

            return lista;


        }
        public static List<TipoUsuarios> GetLista(int tipoId)
        {
            List<TipoUsuarios> lista = new List<TipoUsuarios>();

            var db = new FSVentasDb();

            lista = db.TipoUsuarios.Where(p => p.TipoId == tipoId).ToList();

            return lista;

        }
        public static List<TipoUsuarios> GetListaDetalle(string detalle)
        {
            List<TipoUsuarios> lista = new List<TipoUsuarios>();

            var db = new FSVentasDb();

            lista = db.TipoUsuarios.Where(p => p.Detalle == detalle).ToList();

            return lista;

        }
    }
}
