namespace GrandLabFixers.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulatedSalutationTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Salutations (Id, Name) VALUES(1, 'Mr.')");
            Sql("INSERT INTO Salutations (Id, Name) VALUES(2, 'Ms.')");
            Sql("INSERT INTO Salutations (Id, Name) VALUES(3, 'Mrs.')");
            Sql("INSERT INTO Salutations (Id, Name) VALUES(4, 'Dr.')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Salutations WHERE Id IN(1, 2, 3, 4)");
        }
    }
}
