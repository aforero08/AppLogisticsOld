CREATE TABLE [dbo].[Service] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [ExecutionDate]   DATE          NOT NULL,
    [CreationDate]    DATETIME      NOT NULL,
    [ClientId]        INT           NOT NULL,
    [ClientAreaId]    INT           NULL,
    [ActivityId]      INT           NOT NULL,
    [ProductId]       INT           NULL,
    [ProductQuantity] INT           NULL,
    [VehicleTypeId]   INT           NULL,
    [VehicleNumber]   VARCHAR (50)  NULL,
    [CarrierId]       INT           NULL,
    [ExternalId]      VARCHAR (128) NULL,
    [FullPrice]       INT           NOT NULL,
    [HoldingPrice]    INT           NOT NULL,
    [Comments]        VARCHAR (500) NULL,
    CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Service_Activity] FOREIGN KEY ([ActivityId]) REFERENCES [dbo].[Activity] ([Id]),
    CONSTRAINT [FK_Service_Carrier] FOREIGN KEY ([CarrierId]) REFERENCES [dbo].[Carrier] ([Id]),
    CONSTRAINT [FK_Service_Client] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([Id]),
    CONSTRAINT [FK_Service_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id]),
    CONSTRAINT [FK_Service_VehicleType] FOREIGN KEY ([VehicleTypeId]) REFERENCES [dbo].[VehicleType] ([Id])
);





