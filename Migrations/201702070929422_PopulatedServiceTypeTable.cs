namespace GrandLabFixers.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulatedServiceTypeTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ServiceTypes (Id, Name) VALUES(1, 'Installation')");
            Sql("INSERT INTO ServiceTypes (Id, Name) VALUES(2, 'Repair')");
            Sql("INSERT INTO ServiceTypes (Id, Name) VALUES(3, 'Upgrade')");
        }

        public override void Down()
        {
            Sql("DELETE FROM ServiceTypes WHERE Id IN(1, 2, 3)");
        }
    }
}
