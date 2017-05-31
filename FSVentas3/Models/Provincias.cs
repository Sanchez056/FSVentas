using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FSVentas3.Models
{
    public class Provincias
    {
        [Key]
        public int ProvinciaId { get; set; }
        public string ProvinciaNombre { get; set; }
        public List<Ciudades> Ciudades { get; set; }

    }
}