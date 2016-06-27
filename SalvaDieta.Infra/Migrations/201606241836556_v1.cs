namespace SalvaDieta.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 60),
                        Decription = c.String(nullable: false, maxLength: 500),
                        Icon = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 60),
                        Description = c.String(nullable: false, maxLength: 1024),
                        Weight = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QuantityOnHand = c.Int(nullable: false),
                        Image = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 60),
                        IsActved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Weight = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Email = c.String(nullable: false, maxLength: 160),
                        Password = c.String(nullable: false, maxLength: 32, fixedLength: true),
                        Address = c.String(),
                        Complement = c.String(),
                        Number = c.String(),
                        District = c.String(),
                        City = c.String(),
                        Zip = c.String(),
                        State = c.String(),
                        Homephone = c.String(),
                        Cellphone = c.String(),
                        Photo = c.String(),
                        Facebook = c.String(),
                        Twitter = c.String(),
                        Instagram = c.String(),
                        YouTube = c.String(),
                        Role = c.Int(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        LastLoginDate = c.DateTime(nullable: false),
                        Joined = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Order", "UserId", "dbo.User");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropIndex("dbo.Order", new[] { "UserId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropIndex("dbo.OrderItems", new[] { "ProductId" });
            DropIndex("dbo.Product", new[] { "CategoryId" });
            DropTable("dbo.User");
            DropTable("dbo.Order");
            DropTable("dbo.OrderItems");
            DropTable("dbo.City");
            DropTable("dbo.Product");
            DropTable("dbo.Category");
        }
    }
}
