namespace Torneio.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version_15 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Partidas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PrimeiroTimeId = c.Int(nullable: false),
                        SegundoTimeId = c.Int(nullable: false),
                        GolsPrimeiroTime = c.Int(nullable: false),
                        GolsSegundoTime = c.Int(nullable: false),
                        CampeonatoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campeonato", t => t.CampeonatoId, cascadeDelete: true)
                .Index(t => t.CampeonatoId);
            
            CreateTable(
                "dbo.TimePartida",
                c => new
                    {
                        TimeId = c.Int(nullable: false),
                        PartidaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TimeId, t.PartidaId })
                .ForeignKey("dbo.Partidas", t => t.PartidaId, cascadeDelete: true)
                .ForeignKey("dbo.Time", t => t.TimeId, cascadeDelete: true)
                .Index(t => t.TimeId)
                .Index(t => t.PartidaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimePartida", "TimeId", "dbo.Time");
            DropForeignKey("dbo.TimePartida", "PartidaId", "dbo.Partidas");
            DropForeignKey("dbo.Partidas", "CampeonatoId", "dbo.Campeonato");
            DropIndex("dbo.TimePartida", new[] { "PartidaId" });
            DropIndex("dbo.TimePartida", new[] { "TimeId" });
            DropIndex("dbo.Partidas", new[] { "CampeonatoId" });
            DropTable("dbo.TimePartida");
            DropTable("dbo.Partidas");
        }
    }
}
