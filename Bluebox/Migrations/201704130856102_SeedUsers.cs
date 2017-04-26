namespace Bluebox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5ef7a7c3-c37d-4220-aa34-54749d2a5135', N'admin@bluebox.com', 0, N'AFwaW8ejmcx7WquuRgIxN+kaUFMpDnbroxG48nbGnG6jPtU72nW5u7r6Zrtzb34P6A==', N'5737ea08-cb86-4584-9bb0-aabc09ecf0fb', NULL, 0, 0, NULL, 1, 0, N'admin@bluebox.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c26dea54-a90f-496e-bb06-b5509a7ef37c', N'guest@bluebox.com', 0, N'AE3eC3jgR0TGc+GUL+lrNFR/RiEbvvgY3dADJZt/DB6ERCwo1UPuh34VME5VVAqkeQ==', N'8f6e89df-43e8-4203-a373-ba25706b454e', NULL, 0, 0, NULL, 1, 0, N'guest@bluebox.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'46d6a35b-b086-4b06-9699-cb70b948edab', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5ef7a7c3-c37d-4220-aa34-54749d2a5135', N'46d6a35b-b086-4b06-9699-cb70b948edab')


");
        }
        
        public override void Down()
        {
        }
    }
}
