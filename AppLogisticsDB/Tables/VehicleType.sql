CREATE TABLE [dbo].[VehicleType] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_VehicleType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

