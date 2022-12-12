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
MERGE INTO [Coordinator] AS TARGET
USING (VALUES
    ('marcelo.jenkins@ecci.ucr.ac.cr', 'CRCUCRCITICGP'),
    ('sivana.hamer@ucr.ac.cr', 'CRCUCRCITICHCI'),
    ('alexandra.martinez@ecci.ucr.ac.cr', 'CRCUCRCITICIA'),
    ('cristian.quesadalopez@ucr.ac.cr', 'CRCUCRCITICESE')
)
AS Source([CoordinatorId, [GroupId])
ON TARGET.[CoordinatorId] = Source.[CoordinatorId]
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([CoordinatorId], [GroupId]) 
VALUES ([CoordinatorId], [GroupId]);