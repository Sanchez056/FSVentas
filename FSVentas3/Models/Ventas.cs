using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FSVentas3.Models
{
    public class Ventas
    {    [Key]
        public int VentaId { get; set; }
        public int UsuarioId { get; set; }
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
    }
}