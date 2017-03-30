namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRequestQouteAndSalutationTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RequestQuotes",
                c => new
                    {
                        QuoteId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
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
                        Country_Id = c.Byte(nullable: false),
                        Salutation_Id = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.QuoteId)
                .ForeignKey("dbo.Countries", t => t.Country_Id, cascadeDelete: true)
                .ForeignKey("dbo.Salutations", t => t.Salutation_Id, cascadeDelete: true)
                .Index(t => t.Country_Id)
                .Index(t => t.Salutation_Id);
            
            CreateTable(
                "dbo.Salutations",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RequestQuotes", "Salutation_Id", "dbo.Salutations");
            DropForeignKey("dbo.RequestQuotes", "Country_Id", "dbo.Countries");
            DropIndex("dbo.RequestQuotes", new[] { "Salutation_Id" });
            DropIndex("dbo.RequestQuotes", new[] { "Country_Id" });
            DropTable("dbo.Salutations");
            DropTable("dbo.RequestQuotes");
        }
    }
}
