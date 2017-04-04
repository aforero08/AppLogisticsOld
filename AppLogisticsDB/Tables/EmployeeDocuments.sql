CREATE TABLE [dbo].[EmployeeDocuments] (
    [EmployeeId]             INT NOT NULL,
    [CV]                     BIT NOT NULL,
    [DocumentCopy]           BIT NOT NULL,
    [Photos]                 BIT NOT NULL,
    [MilitaryIdCopy]         BIT NOT NULL,
    [LaborCertification]     BIT NOT NULL,
    [PersonalReference]      BIT NOT NULL,
    [DisciplinaryBackground] BIT NOT NULL,
    [KnowledgeTest]          BIT NOT NULL,
    [AdmissionTest]          BIT NOT NULL,
    [Contract]               BIT NOT NULL,
    [InternalRegulations]    BIT NOT NULL,
    [EndownmentLetter]       BIT NOT NULL,
    [CriticalPosition]       BIT NOT NULL,
    CONSTRAINT [PK_EmployeeDocuments] PRIMARY KEY CLUSTERED ([EmployeeId] ASC),
    CONSTRAINT [FK_EmployeeDocuments_Employee] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employee] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);

