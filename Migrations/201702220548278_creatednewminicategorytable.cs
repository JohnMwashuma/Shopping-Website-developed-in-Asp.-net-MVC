namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creatednewminicategorytable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Minicategories",
                c => new
                    {
                        MinicategoryId = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.MinicategoryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Minicategories");
        }
    }
}
