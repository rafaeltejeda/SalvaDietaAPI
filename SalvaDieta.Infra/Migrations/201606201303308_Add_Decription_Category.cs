namespace SalvaDieta.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Decription_Category : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "Decription", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Category", "Decription");
        }
    }
}
