using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FSVentas2.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }

        public string Nombre { get; set; }


        public string Sexo { get; set; }

        public string Cedula { get; set; }


        public string Direccion { get; set; }

        public string Ciudad { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        public DateTime Fecha { get; set; }
    }
}