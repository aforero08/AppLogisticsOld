CREATE TABLE [dbo].[Carrier] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (128) NOT NULL,
    [NIT]  VARCHAR (20)  NOT NULL,
    CONSTRAINT [PK_Carrier] PRIMARY KEY CLUSTERED ([Id] ASC)
);



