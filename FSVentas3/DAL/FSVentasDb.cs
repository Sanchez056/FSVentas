using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FSVentas2.Models;
using System.Data.Entity.Infrastructure;
using FSVentas3.Models;

namespace FSVentas2.DAL
{
    public partial class FSVentasDb : DbContext
    {
        public FSVentasDb() : base("Name=ConexionDb")
        {
           

        }
        
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<TipoUsuarios> TipoUsuarios { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Articulos> Articulos { get; set; }
        public virtual DbSet<Country> Countrys { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<City> Citys { get; set; }


        
    }
}