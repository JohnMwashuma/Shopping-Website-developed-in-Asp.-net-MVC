namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCountryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "Country_Id", c => c.Byte(nullable: false));
            CreateIndex("dbo.Orders", "Country_Id");
            AddForeignKey("dbo.Orders", "Country_Id", "dbo.Countries", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Country_Id", "dbo.Countries");
            DropIndex("dbo.Orders", new[] { "Country_Id" });
            DropColumn("dbo.Orders", "Country_Id");
            DropTable("dbo.Countries");
        }
    }
}
