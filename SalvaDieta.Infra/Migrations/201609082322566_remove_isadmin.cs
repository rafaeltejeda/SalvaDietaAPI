namespace SalvaDieta.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_isadmin : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.User", "IsAdmin");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "IsAdmin", c => c.Boolean(nullable: false));
        }
    }
}
