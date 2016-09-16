namespace SalvaDieta.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up_banco : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Day", "HourId", c => c.Int(nullable: false));
            CreateIndex("dbo.Day", "HourId");
            AddForeignKey("dbo.Day", "HourId", "dbo.Hour", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Day", "HourId", "dbo.Hour");
            DropIndex("dbo.Day", new[] { "HourId" });
            DropColumn("dbo.Day", "HourId");
        }
    }
}
