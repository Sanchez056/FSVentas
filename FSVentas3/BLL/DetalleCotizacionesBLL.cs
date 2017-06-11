using FSVentas2.DAL;
using FSVentas3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FSVentas3.BLL
{
    public class DetalleCotizacionesBLL
    {
       
        public static bool Guardar(CotizacionesDetalles detalle)
        {
            bool resultado = false;
            using (var db = new FSVentasDb())
            {
                try
                {
                    db.CotizacionesDetalles.Add(detalle);
                    db.SaveChanges();
                    resultado = true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }
        public static CotizacionesDetalles Buscar(int? detalleCotizacionId)
        {
            CotizacionesDetalles detalle = null;
            using (var db = new FSVentasDb())
            {
                try
                {
                    detalle = db.CotizacionesDetalles.Find(detalleCotizacionId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return detalle;
        }
        public static bool Modificar(CotizacionesDetalles detalle)
        {
            bool resultado = false;
            using (var db = new FSVentasDb())
            {
                try
                {
                    db.Entry(detalle).State = EntityState.Modified;
                    db.SaveChanges();
                    resultado = true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }
        public static bool Eliminar(CotizacionesDetalles detalle)
        {
            bool resultado = false;
            using (var db = new FSVentasDb())
            {
                try
                {
                    db.Entry(detalle).State = EntityState.Deleted;
                    db.SaveChanges();
                    resultado = true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }
        public static List<CotizacionesDetalles> Listar()
        {
            List<CotizacionesDetalles> listado = null;
            using (var db = new FSVentasDb())
            {
                try
                {
                    listado = db.CotizacionesDetalles.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listado;
        }
        public static bool Save(List<CotizacionesDetalles> detalles)
        {
            bool resultado = false;
            foreach (CotizacionesDetalles detail in detalles)
            {
                resultado = Guardar(detail);
            }
            return resultado;
        }
       
    }
}