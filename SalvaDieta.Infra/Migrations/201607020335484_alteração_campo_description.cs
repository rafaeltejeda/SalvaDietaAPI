namespace SalvaDieta.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alteração_campo_description : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "Description", c => c.String(nullable: false, maxLength: 500));
            DropColumn("dbo.Category", "Decription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Category", "Decription", c => c.String(nullable: false, maxLength: 500));
            DropColumn("dbo.Category", "Description");
        }
    }
}
