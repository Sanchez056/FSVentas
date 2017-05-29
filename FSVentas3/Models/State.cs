using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FSVentas3.Models
{
    public class State
    {
        [Key]
        public int StateId { get; set; }
        public string StateName { get; set; }
        [ForeignKey("Country")]
        public string CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<City> Citys { get; set; }
        static int cnt = 0;   // For simple demo. Normally a DBMS would use Identity.

        public static IQueryable<State> GetStates()
        {
            cnt = 0;
            return new List<State>
            {
                 new State
                    {
                        CountryId = "1",
                        StateId=cnt++,   // using cnt++ we can insert a new element anywhere
                        StateName = "Nunavut"
                    },
                new State
                    {
                        CountryId= "2",
                        StateId=cnt++,
                        StateName = "Ontario"
                    },

            }.AsQueryable();
        }
    }
}