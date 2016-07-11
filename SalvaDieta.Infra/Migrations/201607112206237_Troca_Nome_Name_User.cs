namespace SalvaDieta.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Troca_Nome_Name_User : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Name", c => c.String());
            DropColumn("dbo.User", "Nome");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Nome", c => c.String());
            DropColumn("dbo.User", "Name");
        }
    }
}
