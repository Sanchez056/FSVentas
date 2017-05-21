using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FSVentas3.Models.Direccion
{
    public class Municipios
    {
        public string CodigoCiudad { get; set; }
        public int MunicipioId { get; set; }
        public string NombreMunicipio { get; set; }

        public static IQueryable<Municipios> GetMunicipio()
        {
            return new List<Municipios>
            {
                new Municipios
                {
                CodigoCiudad = "DU",
                MunicipioId=1,
                NombreMunicipio ="ontario"
              },
                new Municipios
                {
                    CodigoCiudad ="DN",
                    MunicipioId=2,
                    NombreMunicipio="quebec"

                },
                new Municipios
                {
                    CodigoCiudad ="DU",
                    MunicipioId=3,
                    NombreMunicipio="orde"

                },
                new Municipios
                {
                    CodigoCiudad ="DN",
                    MunicipioId=4,
                    NombreMunicipio="new your"

                },
                new Municipios
                {
                    CodigoCiudad ="DN",
                    MunicipioId=5,
                    NombreMunicipio="Mastes"

                }

        }.AsQueryable();
        }
    }
}