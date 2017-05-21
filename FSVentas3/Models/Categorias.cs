using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FSVentas3.Models
{
    public class Categorias
    {
        [Key]
        public int CategoriaId { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = "Introducir Nombre de Categoria")]
        public string Descripcion { get; set; }
    }
}