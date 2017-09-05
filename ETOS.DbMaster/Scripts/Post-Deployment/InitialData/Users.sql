DECLARE @Users TABLE(
	[Id]                   NVARCHAR (128) NOT NULL,
    [Email]                NVARCHAR (MAX) NULL,
    [EmailConfirmed]       BIT            NOT NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [SecurityStamp]        NVARCHAR (MAX) NULL,
    [PhoneNumber]          NVARCHAR (MAX) NULL,
    [PhoneNumberConfirmed] BIT            NOT NULL,
    [TwoFactorEnabled]     BIT            NOT NULL,
    [LockoutEndDateUtc]    DATETIME       NULL,
    [LockoutEnabled]       BIT            NOT NULL,
    [AccessFailedCount]    INT            NOT NULL,
    [UserName]             NVARCHAR (MAX) NULL,
    [Discriminator]        NVARCHAR (128) NOT NULL
	)

INSERT INTO @Users ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp],[PhoneNumber], [PhoneNumberConfirmed], 
					[TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Discriminator])
VALUES
	(N'20a6e00b-401f-4ff8-bee9-29dde5f1097f', N'buh@etos.com', 0, N'AFeXbyCKhBSrKpP3CZM0aIesRzupolln4e4Tee/VCmvx34vDZHltsbNdKxAn6wivsA==', N'67f484b2-d6d3-44db-b5e1-7018dba1d7ef', NULL, 0, 0, NULL, 0, 0, N'buh@etos.com', N'ApplicationUser'),
	(N'5027e93e-7e3a-4afe-8c86-c3008ce4e6ad', N'admin@etos.com', 0, N'AJrrdnIgGLRD/BzK1+HGRQvqP67NDURDeP73jNd8L5BS6sKep+JrPW0yVChzcNMDTw==', N'5bac86d8-88d2-434e-ab00-e50bd0ac326b', NULL, 0, 0, NULL, 0, 0, N'admin@etos.com', N'ApplicationUser'),
	(N'95693098-124e-4475-b7c0-70aa6f8c72e2', N'contractor@etos.com', 0, N'AL/JlRR4xNtzBL2IiYD7BU2eGd6bvJPzNLqIvG0+yuNmcjZTbZHj7XIM7aeWujpljA==', N'60dc1258-9fda-45e7-8915-008de3be7515', NULL, 0, 0, NULL, 0, 0, N'contractor@etos.com', N'ApplicationUser'),
	(N'fc01eb74-0048-462f-a270-2cbc167a054b', N'secret@etos.com', 0, N'AHVnxTXvkF/VB7eZKKL6u9qeBsSyTlRaz0VJTuv6t5AyVIBF7f3d7SjSA5hJUbupxA==', N'a91e72ef-6ba0-4665-8892-1a63ace52b14', NULL, 0, 0, NULL, 0, 0, N'secret@etos.com', N'ApplicationUser'),
	(N'357d265f-e78c-4f2e-ba82-3c3c015d804d', N'manager@etos.com', 0, N'APlbAkkfSMgFokkfTtA5wg1wWgBrzU1ZqdZfkQ8bW5bomXN5UU8PpbiebWOKUz3XbQ==', N'1fcf8fbb-e804-4aea-bf45-03a242023b44', NULL, 0, 0, NULL, 0, 0, N'manager@etos.com', N'ApplicationUser'),
	(N'f4c159d7-99c7-4466-a67f-e7dd7e81f518', N'user@etos.com', 0, N'ALE6ZXAdGh6sPUuoLH9Rc9Ghug0qPQFdP6NemsXVzwj+Hq451hEVDEdL1tBIk2IluA==', N'83588ff8-4b2f-43e9-8f91-f4e4fb08580c', NULL, 0, 0, NULL, 0, 0, N'user@etos.com', N'ApplicationUser')

MERGE INTO [Users] AS [target]
USING @Users AS [source] ON [target].[Id] = [source].[Id]
WHEN MATCHED THEN
	UPDATE
		SET	[target].[Email] = [source].[Email],
			[target].[EmailConfirmed] = [source].[EmailConfirmed],
			[target].[PasswordHash] = [source].[PasswordHash],
			[target].[SecurityStamp] = [source].[SecurityStamp],
			[target].[PhoneNumber] = [source].[PhoneNumber],
			[target].[PhoneNumberConfirmed] = [source].[PhoneNumberConfirmed],
			[target].[TwoFactorEnabled] = [source].[TwoFactorEnabled],
			[target].[LockoutEndDateUtc] = [source].[LockoutEndDateUtc],
			[target].[LockoutEnabled] = [source].[LockoutEnabled],
			[target].[AccessFailedCount] = [source].[AccessFailedCount],
			[target].[UserName] = [source].[UserName],
			[target].[Discriminator] = [source].[Discriminator]		 
WHEN NOT MATCHED BY TARGET THEN
	INSERT ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], 
			[TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Discriminator]) 
	VALUES ([source].[Id], [source].[Email], [source].[EmailConfirmed], [source].[PasswordHash], [source].[SecurityStamp], [source].[PhoneNumber], [source].[PhoneNumberConfirmed], 
			[source].[TwoFactorEnabled], [source].[LockoutEndDateUtc], [source].[LockoutEnabled], [source].[AccessFailedCount], [source].[UserName], [source].[Discriminator]);
GO