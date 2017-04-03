CREATE TABLE [dbo].[EPS] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (128) NOT NULL,
    [NIT]  BIGINT        NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

