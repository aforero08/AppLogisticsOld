CREATE TABLE [dbo].[Rate] (
    [Id]            INT IDENTITY (1, 1) NOT NULL,
    [ClientId]      INT NOT NULL,
    [ActivityId]    INT NOT NULL,
    [VehicleTypeId] INT NULL,
    [Price]         INT NOT NULL,
    [PercentCost]   INT NOT NULL,
    CONSTRAINT [PK_Rate] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Rate_Activity] FOREIGN KEY ([ActivityId]) REFERENCES [dbo].[Activity] ([Id]),
    CONSTRAINT [FK_Rate_Client] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([Id]),
    CONSTRAINT [FK_Rate_VehicleType] FOREIGN KEY ([VehicleTypeId]) REFERENCES [dbo].[VehicleType] ([Id])
);

