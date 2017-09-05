CREATE TABLE [dbo].[Logs]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [CreatorFirstName] NVARCHAR(MAX) NULL, 
    [CreatorLastName] NVARCHAR(MAX) NULL, 
    [BrowserName] NVARCHAR(MAX) NULL, 
    [IpAddress] NVARCHAR(MAX) NULL, 
    [RequestPrice] DECIMAL(9,2) NULL, 
    [RequestMile] FLOAT NULL, 
    [CreationDateTime] DATETIME NOT NULL DEFAULT GETDATE(),
)
