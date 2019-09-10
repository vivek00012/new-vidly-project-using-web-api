BEGIN
    CREATE TABLE [dbo].[Customers] (
        [Id] [int] NOT NULL IDENTITY,
        [FirstName] [nvarchar](255) NOT NULL,
        [MiddleName] [nvarchar](256),
        [LastName] [nvarchar](255) NOT NULL,
        CONSTRAINT [PK_dbo.Customers] PRIMARY KEY ([Id])
    )

    CREATE TABLE [dbo].[Movies] (
        [Id] [int] NOT NULL IDENTITY,
        [Name] [nvarchar](255) NOT NULL,
        CONSTRAINT [PK_dbo.Movies] PRIMARY KEY ([Id])
    )
    CREATE TABLE [dbo].[AspNetRoles] (
        [Id] [nvarchar](128) NOT NULL,
        [Name] [nvarchar](256) NOT NULL,
        CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY ([Id])
    )
    CREATE UNIQUE INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]([Name])
    CREATE TABLE [dbo].[AspNetUserRoles] (
        [UserId] [nvarchar](128) NOT NULL,
        [RoleId] [nvarchar](128) NOT NULL,
        CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId])
    )
    CREATE INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]([UserId])
    CREATE INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]([RoleId])
    CREATE TABLE [dbo].[AspNetUsers] (
        [Id] [nvarchar](128) NOT NULL,
        [Email] [nvarchar](256),
        [EmailConfirmed] [bit] NOT NULL,
        [PasswordHash] [nvarchar](max),
        [SecurityStamp] [nvarchar](max),
        [PhoneNumber] [nvarchar](max),
        [PhoneNumberConfirmed] [bit] NOT NULL,
        [TwoFactorEnabled] [bit] NOT NULL,
        [LockoutEndDateUtc] [datetime],
        [LockoutEnabled] [bit] NOT NULL,
        [AccessFailedCount] [int] NOT NULL,
        [UserName] [nvarchar](256) NOT NULL,
        CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY ([Id])
    )
    CREATE UNIQUE INDEX [UserNameIndex] ON [dbo].[AspNetUsers]([UserName])
    CREATE TABLE [dbo].[AspNetUserClaims] (
        [Id] [int] NOT NULL IDENTITY,
        [UserId] [nvarchar](128) NOT NULL,
        [ClaimType] [nvarchar](max),
        [ClaimValue] [nvarchar](max),
        CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY ([Id])
    )
    CREATE INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]([UserId])
    CREATE TABLE [dbo].[AspNetUserLogins] (
        [LoginProvider] [nvarchar](128) NOT NULL,
        [ProviderKey] [nvarchar](128) NOT NULL,
        [UserId] [nvarchar](128) NOT NULL,
        CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey], [UserId])
    )
    CREATE INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]([UserId])
    ALTER TABLE [dbo].[AspNetUserRoles] ADD CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE
    ALTER TABLE [dbo].[AspNetUserRoles] ADD CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
    ALTER TABLE [dbo].[AspNetUserClaims] ADD CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
    ALTER TABLE [dbo].[AspNetUserLogins] ADD CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
    END

BEGIN
    ALTER TABLE [dbo].[Customers] ADD [IsSubscribedToNewsLetter] [bit] NOT NULL DEFAULT 0
END

BEGIN
    CREATE TABLE [dbo].[MembershipTypes] (
        [Id] [tinyint] NOT NULL,
        [SignUpFee] [smallint] NOT NULL,
        [DurationInMonths] [tinyint] NOT NULL,
        [DiscountRate] [tinyint] NOT NULL,
        CONSTRAINT [PK_dbo.MembershipTypes] PRIMARY KEY ([Id])
    )
    ALTER TABLE [dbo].[Customers] ADD [MembershipTypeId] [tinyint] NOT NULL DEFAULT 0
    CREATE INDEX [IX_MembershipTypeId] ON [dbo].[Customers]([MembershipTypeId])
    ALTER TABLE [dbo].[Customers] ADD CONSTRAINT [FK_dbo.Customers_dbo.MembershipTypes_MembershipTypeId] FOREIGN KEY ([MembershipTypeId]) REFERENCES [dbo].[MembershipTypes] ([Id]) ON DELETE CASCADE
END

BEGIN
    ALTER TABLE [dbo].[MembershipTypes] ADD [Name] [nvarchar](255) NOT NULL DEFAULT ''
END

BEGIN
    INSERT INTO MembershipTypes (Id,SignUpFee,DurationInMonths,DiscountRate) VALUES (1,0,0,0)
    INSERT INTO MembershipTypes (Id,SignUpFee,DurationInMonths,DiscountRate) VALUES (2,30,1,10)
    INSERT INTO MembershipTypes (Id,SignUpFee,DurationInMonths,DiscountRate) VALUES (3,90,3,15)
    INSERT INTO MembershipTypes (Id,SignUpFee,DurationInMonths,DiscountRate) VALUES (4,300,12,20)
END


BEGIN
 Update MembershipTypes set Name = 'Pay As You Go' where SignUpFee = 0
    Update MembershipTypes set Name = 'Monthly' where SignUpFee = 30
    Update MembershipTypes set Name = 'Quaterly' where SignUpFee = 90
    Update MembershipTypes set Name = 'Annually' where SignUpFee = 300
END

BEGIN
    ALTER TABLE [dbo].[Customers] ADD [BirthDate] [datetime]
END

BEGIN
    ALTER TABLE [dbo].[Movies] ADD [DateAdded] [datetime] NOT NULL DEFAULT '1900-01-01T00:00:00.000'
    ALTER TABLE [dbo].[Movies] ADD [ReleaseDate] [datetime] NOT NULL DEFAULT '1900-01-01T00:00:00.000'
    ALTER TABLE [dbo].[Movies] ADD [NumberInStock] [int] NOT NULL DEFAULT 0
END

BEGIN
    CREATE TABLE [dbo].[Genres] (
        [Id] [tinyint] NOT NULL,
        [Name] [nvarchar](255) NOT NULL,
        CONSTRAINT [PK_dbo.Genres] PRIMARY KEY ([Id])
    )
    ALTER TABLE [dbo].[Movies] ADD [GenreId] [tinyint] NOT NULL DEFAULT 0
    CREATE INDEX [IX_GenreId] ON [dbo].[Movies]([GenreId])
    ALTER TABLE [dbo].[Movies] ADD CONSTRAINT [FK_dbo.Movies_dbo.Genres_GenreId] FOREIGN KEY ([GenreId]) REFERENCES [dbo].[Genres] ([Id]) ON DELETE CASCADE
END

BEGIN
    INSERT INTO Genres (Id,Name) VALUES(1,'Comedy')
    INSERT INTO Genres (Id,Name) VALUES(2,'Action')
    INSERT INTO Genres (Id,Name) VALUES(3,'Family')
    INSERT INTO Genres (Id,Name) VALUES(4,'Romance')
    INSERT INTO Genres (Id,Name) VALUES(5,'Horror')
    INSERT INTO Genres (Id,Name) VALUES(6,'Suspense')
END

BEGIN
    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b5deb496-187b-4fb2-86ab-5befb1ab9af6', N'vivek.sinha@happiestminds.com', 0, N'AIUnxY/8lUYCfu8x1irNqPfJGAwT3Z2Fyg11V7+rVfslqwySo9Bhj5ZVRQUl0w89nw==', N'66aada86-173d-4094-ab89-1470245b41eb', NULL, 0, 0, NULL, 1, 0, N'vivek.sinha@happiestminds.com')
                      INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cef0ea60-e31f-451d-965c-071762f14cb4', N'admin@vidly.com', 0, N'ADsu7oOBnK9ZKuhLNaA0K8xj055Bviuh3vYQzxe+ev5HPUpAN3j4LfnaUZhJdaLwpg==', N'63b6da10-a260-462f-b5ef-a3a8e70c892f', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                      INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'76fec0b4-48f8-4c8a-8c70-2e02968cdb56', N'CanManageMovies')
                      INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'cef0ea60-e31f-451d-965c-071762f14cb4', N'76fec0b4-48f8-4c8a-8c70-2e02968cdb56')
END

BEGIN
    ALTER TABLE [dbo].[AspNetUsers] ADD [DrivingLicense] [nvarchar](255) NOT NULL DEFAULT ''
END

BEGIN
    DECLARE @var1 nvarchar(128)
    SELECT @var1 = name
    FROM sys.default_constraints
    WHERE parent_object_id = object_id(N'dbo.AspNetUsers')
    AND col_name(parent_object_id, parent_column_id) = 'PhoneNumber';
    IF @var1 IS NOT NULL
        EXECUTE('ALTER TABLE [dbo].[AspNetUsers] DROP CONSTRAINT [' + @var1 + ']')
    ALTER TABLE [dbo].[AspNetUsers] ALTER COLUMN [PhoneNumber] [nvarchar](15) NULL
END

BEGIN
    CREATE TABLE [dbo].[Rentals] (
        [Id] [int] NOT NULL IDENTITY,
        [DateRented] [datetime] NOT NULL,
        [DateReturned] [datetime],
        [Customer_Id] [int] NOT NULL,
        [Movie_Id] [int] NOT NULL,
        CONSTRAINT [PK_dbo.Rentals] PRIMARY KEY ([Id])
    )
    CREATE INDEX [IX_Customer_Id] ON [dbo].[Rentals]([Customer_Id])
    CREATE INDEX [IX_Movie_Id] ON [dbo].[Rentals]([Movie_Id])
    ALTER TABLE [dbo].[Rentals] ADD CONSTRAINT [FK_dbo.Rentals_dbo.Customers_Customer_Id] FOREIGN KEY ([Customer_Id]) REFERENCES [dbo].[Customers] ([Id]) ON DELETE CASCADE
    ALTER TABLE [dbo].[Rentals] ADD CONSTRAINT [FK_dbo.Rentals_dbo.Movies_Movie_Id] FOREIGN KEY ([Movie_Id]) REFERENCES [dbo].[Movies] ([Id]) ON DELETE CASCADE
END

BEGIN
    EXECUTE sp_rename @objname = N'dbo.Rentals.Customer_Id', @newname = N'CustomerId', @objtype = N'COLUMN'
    EXECUTE sp_rename @objname = N'dbo.Rentals.Movie_Id', @newname = N'MovieId', @objtype = N'COLUMN'
    EXECUTE sp_rename @objname = N'dbo.Rentals.IX_Customer_Id', @newname = N'IX_CustomerId', @objtype = N'INDEX'
    EXECUTE sp_rename @objname = N'dbo.Rentals.IX_Movie_Id', @newname = N'IX_MovieId', @objtype = N'INDEX'
END

BEGIN
    ALTER TABLE [dbo].[Movies] ADD [NumberAvailable] [tinyint] NOT NULL DEFAULT 0
END

BEGIN
DECLARE @var2 nvarchar(128)
    SELECT @var2 = name
    FROM sys.default_constraints
    WHERE parent_object_id = object_id(N'dbo.Movies')
    AND col_name(parent_object_id, parent_column_id) = 'NumberInStock';
    IF @var2 IS NOT NULL
        EXECUTE('ALTER TABLE [dbo].[Movies] DROP CONSTRAINT [' + @var2 + ']')
    ALTER TABLE [dbo].[Movies] ALTER COLUMN [NumberInStock] [tinyint] NOT NULL
    UPDATE Movies SET NumberAvailable=NumberInStock
END

BEGIN
    ALTER TABLE [dbo].[Movies] ADD [MovieThumbnailLocation] [nvarchar](255) NOT NULL DEFAULT ''
    ALTER TABLE [dbo].[Movies] ADD [MovieThumbnailName] [nvarchar](255)
    ALTER TABLE [dbo].[Movies] ADD [MovieImageLocation] [nvarchar](255)
    ALTER TABLE [dbo].[Movies] ADD [MovieImageName] [nvarchar](255)
END

BEGIN
    DECLARE @var3 nvarchar(128)
    SELECT @var3 = name
    FROM sys.default_constraints
    WHERE parent_object_id = object_id(N'dbo.Movies')
    AND col_name(parent_object_id, parent_column_id) = 'MovieThumbnailLocation';
    IF @var3 IS NOT NULL
        EXECUTE('ALTER TABLE [dbo].[Movies] DROP CONSTRAINT [' + @var3 + ']')
    ALTER TABLE [dbo].[Movies] ALTER COLUMN [MovieThumbnailLocation] [nvarchar](255) NULL
END
