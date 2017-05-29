using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace FSVentas3.Migracion
{
    public class CodigoUtilidad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                {
                    CountryId = c.Int(nullable: false, identity: true),
                    CountryName = c.String(),
                })
                .PrimaryKey(t => t.CountryId);

            CreateTable(
                "dbo.States",
                c => new
                {
                    StateId = c.Int(nullable: false, identity: true),
                    StateName = c.String(),
                    CountryId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.StateId)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);

            CreateTable(
                "dbo.Cities",
                c => new
                {
                    CityId = c.Int(nullable: false, identity: true),
                    CityName = c.String(),
                    StateId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.CityId)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .Index(t => t.StateId);

        }

        public override void Down()
        {
            DropIndex("dbo.Cities", new[] { "StateId" });
            DropIndex("dbo.States", new[] { "CountryId" });
            DropForeignKey("dbo.Cities", "StateId", "dbo.States");
            DropForeignKey("dbo.States", "CountryId", "dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.States");
            DropTable("dbo.Countries");
        }
    }
    }
