namespace GrandLabFixers.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class seededcategoriesinservicecategoriestable : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[ServiceCategories] ([ServiceCategoryId], [Name]) VALUES (1, N'Fumigation Services')
INSERT INTO [dbo].[ServiceCategories] ([ServiceCategoryId], [Name]) VALUES (2, N'Bed Bug Control Services')
INSERT INTO [dbo].[ServiceCategories] ([ServiceCategoryId], [Name]) VALUES (3, N'Rodent Control Services')
INSERT INTO [dbo].[ServiceCategories] ([ServiceCategoryId], [Name]) VALUES (4, N'Termite Control Services')
INSERT INTO [dbo].[ServiceCategories] ([ServiceCategoryId], [Name]) VALUES (5, N'Rodent Control Services')
INSERT INTO [dbo].[ServiceCategories] ([ServiceCategoryId], [Name]) VALUES (6, N'CockRoach Control Services')
INSERT INTO [dbo].[ServiceCategories] ([ServiceCategoryId], [Name]) VALUES (7, N'Mosquito Control Services')
INSERT INTO [dbo].[ServiceCategories] ([ServiceCategoryId], [Name]) VALUES (8, N'Ant Control Services')
INSERT INTO [dbo].[ServiceCategories] ([ServiceCategoryId], [Name]) VALUES (9, N'Flies Control Services')
INSERT INTO [dbo].[ServiceCategories] ([ServiceCategoryId], [Name]) VALUES (10, N'Mite Control Services')
INSERT INTO [dbo].[ServiceCategories] ([ServiceCategoryId], [Name]) VALUES (11, N'Sanitary Bins Cleaning Services')

");
        }

        public override void Down()
        {
        }
    }
}
