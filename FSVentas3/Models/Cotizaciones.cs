﻿using FSVentas2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FSVentas3.Models
{
    public class Cotizaciones
    {
        [Key]
        public int CotizacionId { get; set; }
        [ForeignKey("Clientes")]
        public int  ClienteId {get;set;}
        [ForeignKey("Articulos")]
        public int ArticuloId { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }
        [DataType(DataType.Currency)]
        public double Precio{ get; set; }

        public virtual Clientes Clientes { get; set; }
        public virtual Articulos Articulos { get; set; }
        public virtual ICollection<CotizacionesDetalles> Detalle { get; set; } 

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
