﻿using FSVentas2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FSVentas3.Models
{
    public class Articulos
    {
        [Key]
        public int ArticuloId { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = "Introducir su Nombre de Articulo")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = "Introducir la Descripcion de Articulos")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = "Introducir la Marca")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = "Elegir Nombre de Proveedor")]
        [ForeignKey("Proveedores")]
        public int ProveedorId { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
       // [Display(Name = "Elegir la Categoria del Articulo")]
        [ForeignKey("Categorias")]
        public int CategoriaId{ get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = "Introducir Cantidad Dispodible")]
        public int CantidadDispodible { get; set; }

        public int Cantidad { get; set; }
        [Display(Name = "Introducir si Tiene Descuento el Articulo")]
        public double Descuento { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = " Introducir el Precio de Compra")]
        public double PrecioCompra { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = "Introducir el Precio de Venta")]
        public double Precio { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = "Introducir Importe")]
        public double Importe { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy - mm - dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
      

        public virtual Categorias Categorias { get; set; }
        public virtual Proveedores Proveedores { get; set; }

        public virtual ICollection<CotizacionesDetalles> CotizacionesDetalles { get; set; }

        public Articulos()
        {
            this.CotizacionesDetalles = new HashSet<CotizacionesDetalles>();
        }

        public override string ToString()
        {
            return string.Format("ArticuloId: {0}, Descripción: {1}", this.ArticuloId, this.Nombre);
        }

    }
}