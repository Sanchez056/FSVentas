using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FSVentas3.Models.Direccion
{
    public class Ciudades
    {

        public string CodigoCiudad { get; set; }
        public string NombreCiudad{ get; set; }

        public static IQueryable<Ciudades> GetCiudades()
        {
            return new List<Ciudades>
            {
                new Ciudades
                {
                CodigoCiudad = "DU",
                NombreCiudad ="San Francisco de Macoris"
              },
                new Ciudades
                {
                    CodigoCiudad ="DN",
                    NombreCiudad="Distrito Nacional"

                }
        }.AsQueryable();
        }
    }
}