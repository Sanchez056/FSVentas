using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FSVentas2.Models
{
    public class Proveedores
    {
        [Key]
        public int ProveedorId { get; set; }

        public string Nombre { get; set; }

        public string Ciudad { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Fax { get; set; }

        public string Correo { get; set; }

        public DateTime Fecha { get; set; }
    }
}