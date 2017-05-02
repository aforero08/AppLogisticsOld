/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


----------------------------------------------
--	1. Insertar AFPs
----------------------------------------------
MERGE INTO AFP AS Target 
USING (VALUES 
        (1, 'Protección', 800138188), 
        (2, 'Porvenir', 800144331), 
        (3, 'Horizonte', 800147502),
		(4, 'Colfondos', 800227940)
) 
AS Source (Id, [Name], NIT) 
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Name], NIT) 
VALUES ([Name], NIT);


----------------------------------------------
--	2. Insertar EPSs
----------------------------------------------
MERGE INTO EPS AS Target 
USING (VALUES 
        (1, 'Sura', 800088702), 
        (2, 'Salud Total', 800130907), 
        (3, 'CafeSalud', 800140949),
		(4, 'SaludCoop', 800250119),
		(5, 'Sanitas', 800251440),
		(6, 'Famisanar', 830003664),
		(7, 'SaludVida', 830074184),
		(8, 'Compensar', 860066942),
		(9, 'Nueva EPS', 900156264),
		(10, 'Capital Salud', 900298372)
) 
AS Source (Id, [Name], NIT) 
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Name], NIT) 
VALUES ([Name], NIT);


----------------------------------------------
--	3. Insertar Sucursales
----------------------------------------------
MERGE INTO BranchOffice AS Target
USING (VALUES
		(1, 'Bogotá'),
		(2, 'Cali'),
		(3, 'Medellín'),
		(4, 'Cartagena')
)
AS Source (Id, [Name])
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Name])
VALUES ([Name]);


----------------------------------------------
--	4. Insertar Clientes
----------------------------------------------
MERGE INTO Client AS Target
USING (VALUES
	(1, 900464619, 'Brahama Concept SAS', 'Cr 42B No. 12-64', 1, '6919696', 'Catherine Melo'),
	(2, 800162451, 'Cindu Andina SAS', 'Calle 10 No. 41B 14', 1, '4861900', 'Vivian Cury'),
	(3, 860511886, 'Industrias La Coruña', 'Autopista Medellin Km 7 Celta Park Bog. 38', 1, '8985364', 'Lord Álvarez'),
	(4, 900485128, 'Logística y Distribuciones Sobre Ruedas SAS', 'Calle 7 No. 30-59', 1, '3003027', 'Jose Megid Cataño'),
	(5, 800238072, 'Logistics Cargo SAS', 'Cr 14 No. 100-19 Of 501', 1, '7587389', 'Álvaro Almeida'),
	(6, 860530547, 'Multidimensionales SAS', 'Calle 17F No. 126-90', 1, '4222000', 'Yesenia Zamora'),
	(7, 900091465, 'R&M Aduanas Ltda.', 'Cr 96H No. 22L 40 Of. 01', 1, '7027576', NULL),
	(8, 860009034, 'Stanton SAS', 'Km. 25 Via Sibaté', 1, '7198415', 'Emigdio Peña')
)
AS Source ([Id],[NIT],[Name],[Address],[BranchOfficeId],[Phone],[Contact])
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT ([NIT],[Name],[Address],[BranchOfficeId],[Phone],[Contact])
VALUES ([NIT],[Name],[Address],[BranchOfficeId],[Phone],[Contact]);


----------------------------------------------
--	5. Insertar Estados civiles
----------------------------------------------
MERGE INTO MaritalStatus AS Target
USING (VALUES
		(1, 'Soltero'),
		(2, 'Casado'),
		(3, 'Unión Libre'),
		(4, 'Divorciado'),
		(5, 'Viudo')
)
AS Source (Id, [Name])
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Name])
VALUES ([Name]);


----------------------------------------------
--	6. Insertar Empleados
----------------------------------------------
MERGE INTO Employee AS Target
USING (VALUES
		(1, 85154527, 'Luis Gabriel', 'Melo Mendez', '1985-03-01', '2017-01-11', '2017-08-31', 'Bogotá', 'CALLE 14B NO. 119-17 FONTIBON', '3013419708', NULL, NULL, 'MAYLIS CANO', '3218857146', 1, 2, 2, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, NULL)
)
AS Source ([Id],[DocumentNumber],[Name],[Surname],[BornDate],[HireDate],[RetirementDate],[City],[Address],[MobilePhone],[Phone],[Email],[EmergencyContact],[EmergencyContactPhone],[MaritalStatusId],[AfpId],[EpsId],[CV],[DocumentCopy],[Photos],[MilitaryIdCopy],[LaborCertification],[PersonalReference],[DisciplinaryBackground],[KnowledgeTest],[AdmissionTest],[Contract],[InternalRegulations],[EndownmentLetter],[CriticalPosition],[Comments])
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT ([DocumentNumber],[Name],[Surname],[BornDate],[HireDate],[RetirementDate],[City],[Address],[MobilePhone],[Phone],[Email],[EmergencyContact],[EmergencyContactPhone],[MaritalStatusId],[AfpId],[EpsId],[CV],[DocumentCopy],[Photos],[MilitaryIdCopy],[LaborCertification],[PersonalReference],[DisciplinaryBackground],[KnowledgeTest],[AdmissionTest],[Contract],[InternalRegulations],[EndownmentLetter],[CriticalPosition],[Comments])
VALUES ([DocumentNumber],[Name],[Surname],[BornDate],[HireDate],[RetirementDate],[City],[Address],[MobilePhone],[Phone],[Email],[EmergencyContact],[EmergencyContactPhone],[MaritalStatusId],[AfpId],[EpsId],[CV],[DocumentCopy],[Photos],[MilitaryIdCopy],[LaborCertification],[PersonalReference],[DisciplinaryBackground],[KnowledgeTest],[AdmissionTest],[Contract],[InternalRegulations],[EndownmentLetter],[CriticalPosition],[Comments]);


----------------------------------------------
--	7. Insertar Áreas de clientes
----------------------------------------------
MERGE INTO ClientArea AS Target
USING (VALUES
		(1, 1, 'Nacional CL1'),
		(2, 1, 'Importaciones CL1'),
		(3, 1, 'Exportaciones CL1'),
		(4, 1, 'Distribución Local CL1'),
		(5, 1, 'Maquila CL1'),
		(6, 1, 'Materia Prima CL1'),
		(7, 2, 'Nacional CL2'),
		(8, 2, 'Importaciones CL2'),
		(9, 2, 'Exportaciones CL2'),
		(10, 2, 'Distribución Local CL2'),
		(11, 2, 'Maquila CL2'),
		(12, 2, 'Materia Prima CL2'),
		(13, 3, 'Nacional CL3'),
		(14, 3, 'Importaciones  CL3'),
		(15, 3, 'Exportaciones CL3'),
		(16, 3, 'Distribución Local CL3'),
		(17, 3, 'Maquila CL3'),
		(18, 3, 'Materia Prima CL3'),
		(19, 4, 'Nacional CL4'),
		(20, 4, 'Importaciones CL4'),
		(21, 4, 'Exportaciones CL4'),
		(22, 4, 'Distribución Local CL4'),
		(23, 4, 'Maquila CL4'),
		(24, 4, 'Materia Prima CL4'),
		(25, 5, 'Nacional CL5'),
		(26, 5, 'Importaciones CL5'),
		(27, 5, 'Exportaciones CL5'),
		(28, 5, 'Distribución Local CL5'),
		(29, 5, 'Maquila CL5'),
		(30, 5, 'Materia Prima CL5'),
		(31, 6, 'Nacional CL6'),
		(32, 6, 'Importaciones CL6'),
		(33, 6, 'Exportaciones CL6'),
		(34, 6, 'Distribución Local CL6'),
		(35, 6, 'Maquila CL6'),
		(36, 6, 'Materia Prima CL6'),
		(37, 7, 'Nacional CL7'),
		(38, 7, 'Importaciones CL7'),
		(39, 7, 'Exportaciones CL7'),
		(40, 7, 'Distribución Local CL7'),
		(41, 7, 'Maquila CL7'),
		(42, 7, 'Materia Prima CL7'),
		(43, 8, 'Nacional CL8'),
		(44, 8, 'Importaciones CL8'),
		(45, 8, 'Exportaciones CL8'),
		(46, 8, 'Distribución Local CL8'),
		(47, 8, 'Maquila CL8'),
		(48, 8, 'Materia Prima CL8')
)
AS Source (Id,[ClientId],[Name])
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT ([ClientId],[Name])
VALUES ([ClientId],[Name]);


----------------------------------------------
--	8. Insertar Vehículos
----------------------------------------------
MERGE INTO VehicleType AS Target
USING (VALUES
		(1, 'Carry'),
		(2, 'Turbo'),
		(3, 'Sencillo'),
		(4, 'Dobletroque'),
		(5, 'Minimula'),
		(6, 'Tractomula'),
		(7, 'Contenedor 20'),
		(8, 'Contenedor 40')
)
AS Source (Id, [Name])
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Name])
VALUES ([Name]);


----------------------------------------------
--	9. Insertar Actividades
----------------------------------------------
MERGE INTO Activity AS Target
USING (VALUES
		(1, 'Cargue'),
		(2, 'Descargue'),
		(3, 'Turno'),
		(4, 'Medio Turno'),
		(5, 'Hora Extra Diurna'),
		(6, 'Hora Extra Nocturna'),
		(7, 'Hora Extra Dominical')
)
AS Source (Id, [Name])
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Name])
VALUES ([Name]);



----------------------------------------------
--	10. Insertar Productos
----------------------------------------------
MERGE INTO Product AS Target
USING (VALUES
		(1, 'Cajas'),
		(2, 'Bultos'),
		(3, 'Bolsones'),
		(4, 'Estibas'),
		(5, 'Guacales'),
		(6, 'Tambores'),
		(7, 'Toneladas')
)
AS Source (Id, [Name])
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Name])
VALUES ([Name]);


----------------------------------------------
-- 11. Insertar Transportadoras
----------------------------------------------
MERGE INTO Carrier AS Target
USING (VALUES
		(1, 'C&M Logistics', 800084241)
)
AS Source (Id, [Name], NIT)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Name], NIT)
VALUES ([Name], NIT);


