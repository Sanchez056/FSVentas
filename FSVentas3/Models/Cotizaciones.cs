using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FSVentas3.Models
{
    public class Cotizaciones
    {
        [Key]
        public int CotizacionId { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }

        public virtual ICollection<CotizacionesDetalles> Detalle { get; set; } //Muchos

        public Cotizaciones()
        {
            this.Detalle = new HashSet<CotizacionesDetalles>();
        }

        public void AgregarDetalle(Articulos articulos, int cantidad)
        {
            this.Detalle.Add(new CotizacionesDetalles(articulos.ArticuloId, articulos.Descripcion, cantidad,articulos.Precio));
        }
    }
}
