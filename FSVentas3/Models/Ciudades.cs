using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FSVentas3.Models
{
    public class Ciudades
    {
        [Key]
        public int CiudadId { get; set; }
        public string CiudadNombre { get; set; }
       

        [ForeignKey("Provincias")]
        public int ProvinciaId { get; set; }
        public virtual Provincias Provincias { get; set; }

       

    } 

}