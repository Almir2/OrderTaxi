SET IDENTITY_INSERT dbo.Brands ON

DECLARE @Brands TABLE(
	[Id]	INT				NOT NULL,
	[Name]	NVARCHAR(50)	NOT NULL
)
	
INSERT INTO @Brands ([Id], [Name]) VALUES
(1, N'LADA'),
(2, N'KIA'),
(3, N'Hyundai'),
(4, N'Nissan'),
(5, N'Skoda'),
(6, N'Renault'),
(7, N'Citroen')


MERGE INTO [Brands] AS [target]
USING @Brands AS [source] ON [target].[Id] = [source].[Id]
WHEN MATCHED THEN
	UPDATE
		SET	[target].[Name] = [source].[Name]
			 
WHEN NOT MATCHED BY TARGET THEN
	INSERT ([Id], [Name]) 
	VALUES ([source].[Id], [source].[Name]);

SET IDENTITY_INSERT dbo.Brands OFF
GO