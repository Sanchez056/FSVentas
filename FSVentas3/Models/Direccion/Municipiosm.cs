using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FSVentas3.Models.Direccion
{
    public class Municipiosm
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}