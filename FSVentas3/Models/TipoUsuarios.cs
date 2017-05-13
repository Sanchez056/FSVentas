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
        public string Detalle {get;set;}
    }
}