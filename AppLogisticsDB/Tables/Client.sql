CREATE TABLE [dbo].[Client] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [NIT]           BIGINT        NOT NULL,
    [Name]          VARCHAR (128) NOT NULL,
    [Address]       VARCHAR (128) NOT NULL,
    [BrachOfficeId] INT           NOT NULL,
    [Phone]         VARCHAR (50)  NULL,
    [Contact]       VARCHAR (128) NULL,
    CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED ([Id] ASC)
);

