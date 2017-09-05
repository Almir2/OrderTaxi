CREATE TABLE [dbo].[Roles] (
    [Id]            NVARCHAR (128) NOT NULL,
    [Name]          NVARCHAR (MAX) NULL,
    [Discriminator] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.Roles] PRIMARY KEY CLUSTERED ([Id] ASC)
);

