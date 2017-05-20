using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FSVentas2.Models
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = " Por Favor Introducir su Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = " Por Favor Introducir su Contraseña")]
        public string Contraseña { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = " Por Favor Elegir el Tipo de Usuarios")]
        public string Tipo { get; set; }
        

      
    }
}