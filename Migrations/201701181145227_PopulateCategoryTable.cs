namespace GrandLabFixers.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateCategoryTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Id, Name) VALUES(1, 'Biology')");
            Sql("INSERT INTO Categories (Id, Name) VALUES(2, 'Chemistry')");
            Sql("INSERT INTO Categories (Id, Name) VALUES(3, 'Physics')");
            Sql("INSERT INTO Categories (Id, Name) VALUES(4, 'Lab Equipment')");
            Sql("INSERT INTO Categories (Id, Name) VALUES(5, 'Lab Consumables')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Categories WHERE Id IN(1, 2, 3, 4, 5)");
        }
    }
}
