namespace Torneio.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version_11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Campeonato", "Campeao_TimeId", "dbo.Time");
            DropIndex("dbo.Campeonato", new[] { "Campeao_TimeId" });
            DropColumn("dbo.Campeonato", "Campeao_TimeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Campeonato", "Campeao_TimeId", c => c.Int());
            CreateIndex("dbo.Campeonato", "Campeao_TimeId");
            AddForeignKey("dbo.Campeonato", "Campeao_TimeId", "dbo.Time", "TimeId");
        }
    }
}
