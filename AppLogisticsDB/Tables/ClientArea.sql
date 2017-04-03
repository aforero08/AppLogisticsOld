CREATE TABLE [dbo].[ClientArea] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [ClientId] INT           NOT NULL,
    [Name]     VARCHAR (128) NOT NULL,
    CONSTRAINT [PK_ClientArea] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ClientArea_Client] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([Id])
);

