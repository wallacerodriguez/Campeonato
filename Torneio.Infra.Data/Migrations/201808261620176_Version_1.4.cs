namespace Torneio.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version_14 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TimeCampeonato", "CampeonatoId", "dbo.Campeonato");
            DropForeignKey("dbo.TimeCampeonato", "TimeId", "dbo.Time");
            AddForeignKey("dbo.TimeCampeonato", "CampeonatoId", "dbo.Campeonato", "CampeonatoId", cascadeDelete: true);
            AddForeignKey("dbo.TimeCampeonato", "TimeId", "dbo.Time", "TimeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeCampeonato", "TimeId", "dbo.Time");
            DropForeignKey("dbo.TimeCampeonato", "CampeonatoId", "dbo.Campeonato");
            AddForeignKey("dbo.TimeCampeonato", "TimeId", "dbo.Time", "TimeId");
            AddForeignKey("dbo.TimeCampeonato", "CampeonatoId", "dbo.Campeonato", "CampeonatoId");
        }
    }
}
