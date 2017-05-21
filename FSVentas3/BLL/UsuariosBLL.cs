using FSVentas2.DAL;
using FSVentas2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FSVentas3.BLL
{
    public class UsuariosBLL
    {
        Usuarios usuario = new Usuarios();

        public static bool Insertar(Usuarios u)
        {
            bool retornar = false;
            using (var db = new FSVentasDb())
            {
                try
                {
                    if (Buscar(u.UsuarioId) == null)
                    {
                        db.Usuarios.Add(u);
                    }
                    else
                        db.Entry(u).State = EntityState.Modified;
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

    
    

        public static Usuarios Buscar(int id)
        {
            var db = new FSVentasDb();
            return db.Usuarios.Find(id);
        }

        public static bool Eliminar(int id)
        {
            //bool retorna = false;
            try
            {

                using (var db = new FSVentasDb())
                {
                    Usuarios us = new Usuarios();
                    us = db.Usuarios.Find(id);

                    db.Usuarios.Remove(us);
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





        public static List<Usuarios> GetListaNombreUsuario(string aux)
        {
            List<Usuarios> lista = new List<Usuarios>();

            var db = new FSVentasDb();

            lista = db.Usuarios.Where(p => p.Nombre == aux).ToList();

            return lista;

        }


        public static List<Usuarios> GetLista()
        {
            List<Usuarios> lista = new List<Usuarios>();

            using (var db = new FSVentasDb())
                try
                {

                    lista = db.Usuarios.ToList();

                    return lista;

                }
                catch (Exception)
                {
                    throw;
                }
        }
        public static List<Usuarios> GetLista(int usuarioId,String Nombre)
        {
            List<Usuarios> lista = new List<Usuarios>();

            var db = new FSVentasDb();

            lista = db.Usuarios.Where(p => p.UsuarioId == usuarioId).ToList();

            return lista;

        }

        public static List<Usuarios> getContraseña(string aux)
        {
            List<Usuarios> lista = new List<Usuarios>();

            var db = new FSVentasDb();

            lista = db.Usuarios.Where(p => p.Contraseña == aux).ToList();

            return lista;

        }
    }
}
