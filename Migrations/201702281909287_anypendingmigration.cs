namespace GrandLabFixers.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class anypendingmigration : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [MiddleName], [LastName]) VALUES (N'4be2bd32-1814-4843-92b8-5d284088602c', N'john.mwashuma@gmail.com', 0, N'AHc9poM8h8AAZ+M+R6bYwU6rfXMIiIMMC1DpoVPy6tUOxUP7HR+L+OmDwWuoEdISbA==', N'2475c9cf-dbf1-4501-a90e-825a56253f75', NULL, 0, 0, NULL, 1, 0, N'john.mwashuma@gmail.com', N'John', N'K', N'Mwashuma')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [MiddleName], [LastName]) VALUES (N'ad197736-e96b-4c9c-ba43-779f94d49412', N'clemence.chambela@gmail.com', 0, N'ANSnctbNhoIkgpJF0eQTlsSa8VOEbEssv0Ok3CU73ARpKqLQBSNvjvA7R2jyd2c4Dw==', N'e9d19a56-9798-4896-ae40-e848f54b3d68', NULL, 0, 0, NULL, 1, 0, N'clemence.chambela@gmail.com', N'Clemence', N'Mwakisaghu', N'Chambela')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [MiddleName], [LastName]) VALUES (N'f108b27d-2b40-45e0-a6a9-3c9eefd29c29', N'jmwashuma@live.com', 0, N'AKD8Y0lZNbOnoI5sIObUfxOvhFr6W35H/1IEsHK+0ZKE114JST1ehVIfJAg0imXhlQ==', N'0c9973ff-7ae0-4336-9b91-71c29dd3b08d', NULL, 0, 0, NULL, 1, 0, N'jmwashuma@live.com', N'Paul', N'K', N'Mwashuma')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [MiddleName], [LastName]) VALUES (N'fb63c99f-ddcd-4520-974b-c9a1831f74b9', N'glabdigitalfixers@gmail.com', 0, N'AAcr3VwIXN0JrKHTjnRbhEpx54AiOa+vTCjxt5nOjE8aTJ+1gcfPiOOp5zoE98mgnQ==', N'b7884250-6186-49f7-83a0-60a3f5eac1c2', NULL, 0, 0, NULL, 1, 0, N'glabdigitalfixers@gmail.com', N'GrandLab', N'G', N'DigitalFixers')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9af52fdd-4d24-4f66-bafc-d15757fd0039', N'CanManageProducts')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fb63c99f-ddcd-4520-974b-c9a1831f74b9', N'9af52fdd-4d24-4f66-bafc-d15757fd0039')
");
        }

        public override void Down()
        {
        }
    }
}
