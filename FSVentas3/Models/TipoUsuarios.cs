using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FSVentas2.Models
{
    public class TipoUsuarios
    {
        [Key]
        public int TipoId { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = " Por Favor Introducir el Nombre de Tipo de Usuarios")]
        public string Detalle {get;set;}
    }
}