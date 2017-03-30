namespace GrandLabFixers.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class seedcategorytable : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (6, N'Glass and Rubber Tubing')
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (7, N'Stoppers and Corks')
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (8, N'Beakers')
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (9, N'Flasks')
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (10, N'Graduated Cylinders')
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (11, N'Pyrex Lab Glassware')
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (12, N'Test Tubes')
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (13, N'Funnels')
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (14, N'Burettes')
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (15, N'Pipettes and Droppers')
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (16, N'Bottles and Jars')
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (17, N'Evaporating Dishes and Test Plates')
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (18, N'Mortar and Pestles')
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (19, N'Crucibles')
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (20, N'Chemicals')
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (21, N'Safety Equipment')
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (22, N'Agar, Petri Dishes, And Bacteria')
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (23, N'Dissection Tools')
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (24, N'Life Science')
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (25, N'Measuring Tools')
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (26, N'Spring Scales and Balances')
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (27, N'Masses and Weights')
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (28, N'Physics Thermometers')
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (29, N'Electricity')
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (30, N'Magnets and Magnetism')
");

        }

        public override void Down()
        {
        }
    }
}
