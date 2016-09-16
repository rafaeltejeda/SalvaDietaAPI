namespace SalvaDieta.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_database_Day_Hour : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Day",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DayOfWeek = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Reserved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Hour",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HourOfDay = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Reserved = c.Boolean(nullable: false),
                        DayId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Day", t => t.DayId, cascadeDelete: true)
                .Index(t => t.DayId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hour", "DayId", "dbo.Day");
            DropIndex("dbo.Hour", new[] { "DayId" });
            DropTable("dbo.Hour");
            DropTable("dbo.Day");
        }
    }
}
