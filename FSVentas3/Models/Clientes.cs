using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FSVentas2.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = " Por Favor Introducir su Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = " Por Favor Elegir su Sexo")]
        public string Sexo { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = " Por Favor Introducir Numero de Cedula")]
        public string Cedula { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = " Por Favor Introducir Su Direccion")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = " Por Favor Elegir Su Ciudad")]
        public string Ciudad { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = " Por Favor Introducir su Telefono Recidencial")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = " Por Favor Introducir su Numero  de Celular")]
        public string Celular { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy - mm - dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
    }
}