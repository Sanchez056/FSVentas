using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FSVentas3.Models
{
    public class Articulos
    {
        [Key]
        public int ArticuloId { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = " Por Favor Introducir su Nombre de Articulo")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = " Por Favor Introducir la Descripcion de Articulos")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = " Por Favor Introducir la Marca")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = " Por Favor Elegir Nombre de Proveedor")]
        public string NombreProveedor { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = " Por Favor Elegir la Categoria del Articulo")]
        public string Categoria { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = " Por Favor Introducir Cantidad Dispodible")]
        public int CantidadDispodible { get; set; }

        public int Cantidad { get; set; }
        [Display(Name = " Por Favor Introducir si Tiene Descuento el Articulo")]
        public double Descuento { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = " Por Favor Introducir el Precio de Compra")]
        public double PrecioCompra { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = " Por Favor Introducir el Precio de Venta")]
        public double Precio { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = " Por Favor Introducir Importe")]
        public double Importe { get; set; }

        public DateTime Fecha { get; set; }

    }
}