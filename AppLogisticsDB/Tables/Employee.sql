CREATE TABLE [dbo].[Employee] (
    [Id]                     INT           IDENTITY (1, 1) NOT NULL,
    [DocumentNumber]         BIGINT        NOT NULL,
    [Name]                   VARCHAR (128) NOT NULL,
    [Surname]                VARCHAR (128) NOT NULL,
    [BornDate]               DATE          NOT NULL,
    [HireDate]               DATE          NOT NULL,
    [RetirementDate]         DATE          NULL,
    [City]                   VARCHAR (64)  NOT NULL,
    [Address]                VARCHAR (64)  NOT NULL,
    [MobilePhone]            VARCHAR (50)  NOT NULL,
    [Phone]                  VARCHAR (50)  NULL,
    [Email]                  VARCHAR (256) NULL,
    [EmergencyContact]       VARCHAR (128) NULL,
    [EmergencyContactPhone]  VARCHAR (50)  NULL,
    [MaritalStatusId]        INT           NOT NULL,
    [AfpId]                  INT           NOT NULL,
    [EpsId]                  INT           NOT NULL,
    [CV]                     BIT           NOT NULL,
    [DocumentCopy]           BIT           NOT NULL,
    [Photos]                 BIT           NOT NULL,
    [MilitaryIdCopy]         BIT           NOT NULL,
    [LaborCertification]     BIT           NOT NULL,
    [PersonalReference]      BIT           NOT NULL,
    [DisciplinaryBackground] BIT           NOT NULL,
    [KnowledgeTest]          BIT           NOT NULL,
    [AdmissionTest]          BIT           NOT NULL,
    [Contract]               BIT           NOT NULL,
    [InternalRegulations]    BIT           NOT NULL,
    [EndownmentLetter]       BIT           NOT NULL,
    [CriticalPosition]       BIT           NOT NULL,
    [Comments]               VARCHAR (500) NULL,
    CONSTRAINT [PK__Employee] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Employee_AFP] FOREIGN KEY ([AfpId]) REFERENCES [dbo].[AFP] ([Id]),
    CONSTRAINT [FK_Employee_EPS] FOREIGN KEY ([EpsId]) REFERENCES [dbo].[EPS] ([Id]),
    CONSTRAINT [FK_Employee_MaritalStatus] FOREIGN KEY ([MaritalStatusId]) REFERENCES [dbo].[MaritalStatus] ([Id])
);







