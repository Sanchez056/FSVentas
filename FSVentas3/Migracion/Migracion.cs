using FSVentas2.DAL;
using FSVentas3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace FSVentas3.Migracion
{
    public class Migracion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Provincias", "MuncipioId", "dbo.Municipios");
            DropForeignKey("dbo.Ciudades", "MunicipioId", "dbo.Municipios");
            DropIndex("dbo.Provincias", new[] { "Municipio_Id" });
            DropIndex("dbo.Ciudades", new[] { "MunicipioId" });
            CreateIndex("dbo.Municipios", "ProvinciaId");
            CreateIndex("dbo.Muncipios", "CiudadId");

            AddForeignKey("dbo.Municipios", "ProvinciaId", "dbo.Provincias", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Municipios", "CiudadId", "dbo.Ciudades", "Id", cascadeDelete: false);

            DropColumn("dbo.Provincias", "MunicipioId");
            DropColumn("dbo.Products", "MunicipioId");
        }

        public override void Down()
        {
            AddColumn("dbo.Ciudades", "MunicipioId", c => c.Int());
            AddColumn("dbo.Provincias", "MunicipioId", c => c.Int());
            DropForeignKey("dbo.Municipios", "CiudadId", "dbo.Ciudades");
            DropForeignKey("dbo.Municipios", "ProvinciaId", "dbo.Provincias");
            DropIndex("dbo.Municipios", new[] { "CiudadId" });
            DropIndex("dbo.Municipios", new[] { "ProvinciaId" });
            CreateIndex("dbo.Ciudades", "MunicipioId");
            CreateIndex("dbo.Provincias", "MunicipioId");
            AddForeignKey("dbo.Ciudades", "MunicipioId", "dbo.Municipios", "Id");
            AddForeignKey("dbo.Provincias", "MunicipioId", "dbo.Municipios", "Id");
        }
        internal sealed class Configuration : DbMigrationsConfiguration<FSVentasDb>
        {
            public Configuration()
            {
                AutomaticMigrationsEnabled = false;
            }

            protected override void Seed(FSVentasDb context)
            {
                context.Provincias.AddOrUpdate(
                    p => p.ProvinciaNombre,
                    new Provincias
                    {
                        ProvinciaNombre= "ProvinciaNombre",
                        Ciudades = new List<Ciudades> {
                        new Ciudades{CiudadNombre = "Mobile"},
                        new Ciudades{CiudadNombre = "Laptop"},
                        new Ciudades{CiudadNombre = "Television"},
                        new Ciudades{CiudadNombre = "Camera"}
                        }

                    },

                    new Provincias
                    {
                        ProvinciaNombre = "Men ware",
                        Ciudades = new List<Ciudades>
                        {
                        new Ciudades{CiudadNombre = "Footware"},
                        new Ciudades{CiudadNombre = "Clothings"},
                        new Ciudades{CiudadNombre = "Watches"},
                        new Ciudades{CiudadNombre = "Hand bag"},
                        new Ciudades{CiudadNombre = "Sun Glass"}
                        }
                    }

                    

                    );
            }
        }

    }
}