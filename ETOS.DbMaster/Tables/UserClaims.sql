CREATE TABLE [dbo].[UserClaims] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [UserId]     NVARCHAR (128) NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.UserClaims] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.UserClaims_dbo.Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[UserClaims]([UserId] ASC);

