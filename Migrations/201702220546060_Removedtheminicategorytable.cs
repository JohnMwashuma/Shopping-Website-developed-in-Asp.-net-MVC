namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removedtheminicategorytable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Minicategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Minicategories",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
