namespace Torneio.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version_12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TimeCampeonato", "TimeId", "dbo.Time");
            DropForeignKey("dbo.TimeCampeonato", "CampeonatoId", "dbo.Campeonato");
            DropIndex("dbo.TimeCampeonato", new[] { "TimeId" });
            DropIndex("dbo.TimeCampeonato", new[] { "CampeonatoId" });
            DropTable("dbo.TimeCampeonato");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TimeCampeonato",
                c => new
                    {
                        TimeId = c.Int(nullable: false),
                        CampeonatoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TimeId, t.CampeonatoId });
            
            CreateIndex("dbo.TimeCampeonato", "CampeonatoId");
            CreateIndex("dbo.TimeCampeonato", "TimeId");
            AddForeignKey("dbo.TimeCampeonato", "CampeonatoId", "dbo.Campeonato", "CampeonatoId");
            AddForeignKey("dbo.TimeCampeonato", "TimeId", "dbo.Time", "TimeId");
        }
    }
}
