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


MERGE INTO AFP AS Target 
USING (VALUES 
        (1, 'Protección', 800138188), 
        (2, 'Porvenir', 800144331), 
        (3, 'Horizonte', 800147502),
		(4, 'Colfondos', 800227940)
) 
AS Source (Id, Name, NIT) 
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN 
INSERT (Name, NIT) 
VALUES (Name, NIT);


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
AS Source (Id, Name, NIT) 
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN 
INSERT (Name, NIT) 
VALUES (Name, NIT);
