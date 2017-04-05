CREATE TABLE [dbo].[Holding] (
    [Id]         INT NOT NULL,
    [ServiceId]  INT NOT NULL,
    [EmployeeId] INT NOT NULL,
    [Price]      INT NOT NULL,
    CONSTRAINT [PK_Holding] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Holding_Employee] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employee] ([Id]),
    CONSTRAINT [FK_Holding_Service] FOREIGN KEY ([ServiceId]) REFERENCES [dbo].[Service] ([Id])
);



