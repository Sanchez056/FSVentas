using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FSVentas3.Models
{
    public class Municipios
    {

        [Key]
        public int MunicipioId { get; set; }
        public string MunicipioNombre { get; set; }

        [ForeignKey("Provincias")]
        public int ProvinciaId { get; set; }
        public virtual Provincias Provincias { get; set; }

       
        public int CiudadId { get; set; }
        [ForeignKey("CiudadId")]
        public Ciudades Ciudades { get; set; }
    }
}
