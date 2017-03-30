namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRequestserviceAndServiceTypeTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RequestServices",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        RequestDate = c.DateTime(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 160),
                        LastName = c.String(nullable: false, maxLength: 160),
                        Company = c.String(nullable: false, maxLength: 160),
                        Department = c.String(nullable: false, maxLength: 160),
                        Address = c.String(nullable: false, maxLength: 70),
                        Email = c.String(nullable: false),
                        City = c.String(nullable: false, maxLength: 40),
                        PhoneNumber = c.String(nullable: false, maxLength: 24),
                        PostalCode = c.String(nullable: false, maxLength: 10),
                        Quantity = c.Int(nullable: false),
                        Message = c.String(nullable: false, maxLength: 255),
                        OtherServiceType = c.String(),
                        Country_Id = c.Byte(nullable: false),
                        Salutation_Id = c.Byte(nullable: false),
                        ServiceType_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.ServiceId)
                .ForeignKey("dbo.Countries", t => t.Country_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Salutations", t => t.Salutation_Id, cascadeDelete: true)
                .ForeignKey("dbo.ServiceTypes", t => t.ServiceType_Id)
                .Index(t => t.ProductId)
                .Index(t => t.Country_Id)
                .Index(t => t.Salutation_Id)
                .Index(t => t.ServiceType_Id);
            
            CreateTable(
                "dbo.ServiceTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RequestServices", "ServiceType_Id", "dbo.ServiceTypes");
            DropForeignKey("dbo.RequestServices", "Salutation_Id", "dbo.Salutations");
            DropForeignKey("dbo.RequestServices", "ProductId", "dbo.Products");
            DropForeignKey("dbo.RequestServices", "Country_Id", "dbo.Countries");
            DropIndex("dbo.RequestServices", new[] { "ServiceType_Id" });
            DropIndex("dbo.RequestServices", new[] { "Salutation_Id" });
            DropIndex("dbo.RequestServices", new[] { "Country_Id" });
            DropIndex("dbo.RequestServices", new[] { "ProductId" });
            DropTable("dbo.ServiceTypes");
            DropTable("dbo.RequestServices");
        }
    }
}
