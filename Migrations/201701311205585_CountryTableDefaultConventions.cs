namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CountryTableDefaultConventions : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Country_Id", "dbo.Countries");
            DropIndex("dbo.Orders", new[] { "Country_Id" });
            DropColumn("dbo.Orders", "Country_Id");
            DropTable("dbo.Countries");
        }
        
        public override void Down()
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
        }
    }
}
