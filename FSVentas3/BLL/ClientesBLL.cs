using FSVentas2.DAL;
using FSVentas2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FSVentas3.BLL
{
    public class ClientesBLL
    {
        Clientes cliente = new Clientes();

        public static bool Insertar(Clientes c)
        {
            bool retornar = false;
            using (var db = new FSVentasDb())
            {
                try
                {
                    if (Buscar(c.ClienteId) == null)
                    {
                        db.Clientes.Add(c);
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

        public static Clientes Buscar(int id)
        {
            var db = new FSVentasDb();

            return db.Clientes.Find(id);


        }
        public static Clientes BuscarNombre(string nombre)
        {
            var db = new FSVentasDb();

            return db.Clientes.Find(nombre);


        }
       





        public static bool Eliminar(int id)
        {
            //bool retorna = false;
            try
            {

                using (var db = new FSVentasDb())
                {
                    Clientes c = new Clientes();
                    c = db.Clientes.Find(id);

                    db.Clientes.Remove(c);
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

        public static List<Clientes> GetLista()
        {
            List<Clientes> lista = new List<Clientes>();

            var db = new FSVentasDb();

            lista = db.Clientes.ToList();

            return lista;


        }

        public static List<Clientes> GetLista(int clienteId)
        {
            List<Clientes> lista = new List<Clientes>();

            var db = new FSVentasDb();

            lista = db.Clientes.Where(p => p.ClienteId == clienteId).ToList();

            return lista;

        }



        public static List<Clientes> GetListaNombreCliente(string aux)
        {
            List<Clientes> lista = new List<Clientes>();

            var db = new FSVentasDb();

            lista = db.Clientes.Where(p => p.Nombre == aux).ToList();

            return lista;

        }



        public static List<Clientes> GetListaSexo(string aux)
        {
            List<Clientes> lista = new List<Clientes>();

            var db = new FSVentasDb();

            lista = db.Clientes.Where(p => p.Sexo == aux).ToList();

            return lista;

        }

        public static List<Clientes> GetListaCedula(string aux)
        {
            List<Clientes> lista = new List<Clientes>();

            var db = new FSVentasDb();

            lista = db.Clientes.Where(p => p.Cedula == aux).ToList();

            return lista;

        }
        public static List<Clientes> GetListaFecha(DateTime aux)
        {
            List<Clientes> lista = new List<Clientes>();

            var db = new FSVentasDb();

            lista = db.Clientes.Where(p => p.Fecha == aux).ToList();

            return lista;

        }
        public static List<Clientes> GetListaFecha(DateTime Desde, DateTime Hasta)
        {
            List<Clientes> lista = new List<Clientes>();

            var db = new FSVentasDb();

            lista = db.Clientes.Where(p => p.Fecha >= Desde && p.Fecha <= Hasta).ToList();

            return lista;

        }
    }
}
