namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedUserNameConventionInOrderTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "UserName_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "UserName_Id" });
            AlterColumn("dbo.Orders", "UserName_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Orders", "UserName_Id");
            AddForeignKey("dbo.Orders", "UserName_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserName_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "UserName_Id" });
            AlterColumn("dbo.Orders", "UserName_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Orders", "UserName_Id");
            AddForeignKey("dbo.Orders", "UserName_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
