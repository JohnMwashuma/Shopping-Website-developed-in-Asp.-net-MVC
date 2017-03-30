namespace GrandLabFixers.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class populateminicategorytable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Minicategories (MinicategoryId, Name) VALUES(1, 'Ring Stands, Clamps and Supports')");
            Sql("INSERT INTO Minicategories (MinicategoryId, Name) VALUES(2, 'Thermometers')");
            Sql("INSERT INTO Minicategories (MinicategoryId, Name) VALUES(3, 'Distillation Glassware and Equipment')");
            Sql("INSERT INTO Minicategories (MinicategoryId, Name) VALUES(4, 'Organic Chemistry Equipment')");
            Sql("INSERT INTO Minicategories (MinicategoryId, Name) VALUES(5, 'Models and Periodic Tables')");
            Sql("INSERT INTO Minicategories (MinicategoryId, Name) VALUES(6, 'Glass and Rubber Tubing')");
            Sql("INSERT INTO Minicategories (MinicategoryId, Name) VALUES(7, 'Stoppers and Corks')");
            Sql("INSERT INTO Minicategories (MinicategoryId, Name) VALUES(8, 'Beakers')");
            Sql("INSERT INTO Minicategories (MinicategoryId, Name) VALUES(9, 'Flasks')");
            Sql("INSERT INTO Minicategories (MinicategoryId, Name) VALUES(10, 'Graduated Cylinders')");
            Sql("INSERT INTO Minicategories (MinicategoryId, Name) VALUES(11, 'Pyrex Lab Glassware')");
            Sql("INSERT INTO Minicategories (MinicategoryId, Name) VALUES(12, 'Test Tubes')");
            Sql("INSERT INTO Minicategories (MinicategoryId, Name) VALUES(13, 'Funnels')");
            Sql("INSERT INTO Minicategories (MinicategoryId, Name) VALUES(14, 'Burettes')");
            Sql("INSERT INTO Minicategories (MinicategoryId, Name) VALUES(15, 'Pipettes and Droppers')");
            Sql("INSERT INTO Minicategories (MinicategoryId, Name) VALUES(16, 'Bottles and Jars')");
            Sql("INSERT INTO Minicategories (MinicategoryId, Name) VALUES(17, 'Evaporating Dishes and Test Plates')");
            Sql("INSERT INTO Minicategories (MinicategoryId, Name) VALUES(18, 'Mortar and Pestles')");
            Sql("INSERT INTO Minicategories (MinicategoryId, Name) VALUES(19, 'Crucibles')");
            Sql("INSERT INTO Minicategories (MinicategoryId, Name) VALUES(20, 'Chemicals')");
            Sql("INSERT INTO Minicategories (MinicategoryId, Name) VALUES(21, 'Safety Equipment')");

            Sql("INSERT INTO Minicategories (MinicategoryId, Name) VALUES(22, 'Agar, Petri Dishes, And Bacteria')");
            Sql("INSERT INTO Minicategories (MinicategoryId, Name) VALUES(23, 'Dissection Tools')");
            Sql("INSERT INTO Minicategories (MinicategoryId, Name) VALUES(24, 'Life Science')");

            Sql("INSERT INTO Minicategories (MinicategoryId, Name) VALUES(25, 'Measuring Tools')");
            Sql("INSERT INTO Minicategories (MinicategoryId, Name) VALUES(26, 'Spring Scales and Balances')");
            Sql("INSERT INTO Minicategories (MinicategoryId, Name) VALUES(27, 'Masses and Weights')");
            Sql("INSERT INTO Minicategories (MinicategoryId, Name) VALUES(28, 'Physics Thermometers')");
            Sql("INSERT INTO Minicategories (MinicategoryId, Name) VALUES(29, 'Electricity')");
            Sql("INSERT INTO Minicategories (MinicategoryId, Name) VALUES(30, 'Magnets and Magnetism')");
        }

        public override void Down()
        {

        }
    }
}
