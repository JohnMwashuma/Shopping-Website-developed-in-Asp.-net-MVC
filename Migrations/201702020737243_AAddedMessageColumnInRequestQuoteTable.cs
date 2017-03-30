namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AAddedMessageColumnInRequestQuoteTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RequestQuotes", "Message", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RequestQuotes", "Message");
        }
    }
}
