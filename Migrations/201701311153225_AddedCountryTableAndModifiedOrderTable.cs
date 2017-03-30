namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCountryTableAndModifiedOrderTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "Country_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "Country_Id");
            AddForeignKey("dbo.Orders", "Country_Id", "dbo.Countries", "Id", cascadeDelete: true);
            DropColumn("dbo.Orders", "State");
            DropColumn("dbo.Orders", "PostalCode");
            DropColumn("dbo.Orders", "Country");
            DropColumn("dbo.Orders", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "Country", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.Orders", "PostalCode", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.Orders", "State", c => c.String(nullable: false, maxLength: 40));
            DropForeignKey("dbo.Orders", "Country_Id", "dbo.Countries");
            DropIndex("dbo.Orders", new[] { "Country_Id" });
            DropColumn("dbo.Orders", "Country_Id");
            DropTable("dbo.Countries");
        }
    }
}
