namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b5deb496-187b-4fb2-86ab-5befb1ab9af6', N'vivek.sinha@happiestminds.com', 0, N'AIUnxY/8lUYCfu8x1irNqPfJGAwT3Z2Fyg11V7+rVfslqwySo9Bhj5ZVRQUl0w89nw==', N'66aada86-173d-4094-ab89-1470245b41eb', NULL, 0, 0, NULL, 1, 0, N'vivek.sinha@happiestminds.com')
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cef0ea60-e31f-451d-965c-071762f14cb4', N'admin@vidly.com', 0, N'ADsu7oOBnK9ZKuhLNaA0K8xj055Bviuh3vYQzxe+ev5HPUpAN3j4LfnaUZhJdaLwpg==', N'63b6da10-a260-462f-b5ef-a3a8e70c892f', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'76fec0b4-48f8-4c8a-8c70-2e02968cdb56', N'CanManageMovies')
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'cef0ea60-e31f-451d-965c-071762f14cb4', N'76fec0b4-48f8-4c8a-8c70-2e02968cdb56')

");
        }
        
        public override void Down()
        {
        }
    }
}
