namespace Torneio.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Campeonato",
                c => new
                    {
                        CampeonatoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 40, unicode: false),
                        Quantidade = c.Int(nullable: false),
                        Campeao_TimeId = c.Int(),
                    })
                .PrimaryKey(t => t.CampeonatoId)
                .ForeignKey("dbo.Time", t => t.Campeao_TimeId)
                .Index(t => t.Campeao_TimeId);
            
            CreateTable(
                "dbo.Time",
                c => new
                    {
                        TimeId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 60, unicode: false),
                        QuantidadeVitorias = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TimeId);
            
            CreateTable(
                "dbo.TimeCampeonato",
                c => new
                    {
                        TimeId = c.Int(nullable: false),
                        CampeonatoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TimeId, t.CampeonatoId })
                .ForeignKey("dbo.Time", t => t.TimeId)
                .ForeignKey("dbo.Campeonato", t => t.CampeonatoId)
                .Index(t => t.TimeId)
                .Index(t => t.CampeonatoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Campeonato", "Campeao_TimeId", "dbo.Time");
            DropForeignKey("dbo.TimeCampeonato", "CampeonatoId", "dbo.Campeonato");
            DropForeignKey("dbo.TimeCampeonato", "TimeId", "dbo.Time");
            DropIndex("dbo.TimeCampeonato", new[] { "CampeonatoId" });
            DropIndex("dbo.TimeCampeonato", new[] { "TimeId" });
            DropIndex("dbo.Campeonato", new[] { "Campeao_TimeId" });
            DropTable("dbo.TimeCampeonato");
            DropTable("dbo.Time");
            DropTable("dbo.Campeonato");
        }
    }
}
