namespace GrandLabFixers.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulatedCountriesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Countries (Id, Name) VALUES(1, 'Kenya')");
            Sql("INSERT INTO Countries (Id, Name) VALUES(2, 'Uganda')");
            Sql("INSERT INTO Countries (Id, Name) VALUES(3, 'Tanzania')");
            Sql("INSERT INTO Countries (Id, Name) VALUES(4, 'South Africa')");
            Sql("INSERT INTO Countries (Id, Name) VALUES(5, 'Zimbia')");
            Sql("INSERT INTO Countries (Id, Name) VALUES(6, 'Ghana')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Countries WHERE Id IN(1, 2, 3, 4, 5, 6)");
        }
    }
}
