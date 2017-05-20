using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FSVentas2.Models
{
    public class Proveedores
    {
        [Key]
        public int ProveedorId { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = " Por Favor Introducir su Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = " Por Favor Introducir Elegir la Ciudad")]
        public string Ciudad { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = " Por Favor Introducir su Direccion")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = " Por Favor Introducir su Numero Telefono ")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = " Por Favor Introducir su Numero de Fax")]
        public string Fax { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = " Por Favor Introducir su Correo Eletronico")]
        public string Correo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy - mm - dd}", ApplyFormatInEditMode = true) ]   
        public DateTime Fecha { get; set; }
    }
}