using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FSVentas3.Models
{
    public class Country
    {
        [Key]
        public string CountryId { get; set; }
        public string CountryName { get; set; }

        public static IQueryable<Country> GetCountries()
        {
            return new List<Country>
            {
                new Country {
                    CountryId = "1",
                   CountryName = "Canada"
                },
                new Country{
                    CountryId = "2",
                    CountryName= "United States"
                },
                new Country{
                    CountryId = "3",
                    CountryName = "United Kingdom"
                }
                // ,new Country{    // verify check for ' works
                //    Code = "CD'",
                //    Name = "Côte D'ivoire"
                //}
            }.AsQueryable();
        }
        public virtual ICollection<State> States { get; set; }
    }
}