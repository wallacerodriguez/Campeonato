namespace Torneio.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version_13 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TimeCampeonato",
                c => new
                    {
                        TimeId = c.Int(nullable: false),
                        CampeonatoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TimeId, t.CampeonatoId })
                .ForeignKey("dbo.Campeonato", t => t.CampeonatoId)
                .ForeignKey("dbo.Time", t => t.TimeId)
                .Index(t => t.TimeId)
                .Index(t => t.CampeonatoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeCampeonato", "TimeId", "dbo.Time");
            DropForeignKey("dbo.TimeCampeonato", "CampeonatoId", "dbo.Campeonato");
            DropIndex("dbo.TimeCampeonato", new[] { "CampeonatoId" });
            DropIndex("dbo.TimeCampeonato", new[] { "TimeId" });
            DropTable("dbo.TimeCampeonato");
        }
    }
}
