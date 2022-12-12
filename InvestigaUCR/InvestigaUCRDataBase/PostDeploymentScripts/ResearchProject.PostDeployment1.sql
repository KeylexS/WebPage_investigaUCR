/*
    US: PIIB22II02 - 9
    TASK: PIIB22II02 - 319
*/

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
MERGE INTO [ResearchCenter] AS TARGET
USING (VALUES
	    (1, 'Centro1')
)
AS Source([Id], [Name])
ON TARGET.[Id] = Source.[Id]
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Id], [Name]) 
VALUES ([Id], [Name]);

MERGE INTO [Group] AS Target 
USING (VALUES 
	('ABCD1','Comida',1,'Descripcion generica de prueba para el testeo de la funcionalidad de cortar la descripcion si esta es muy larga más texto para rellenar','2022/4/14')
) 
AS Source ([Id], [Name], [ResearchCenterId], [Description], [Start_Date]) 
ON Target.[Id] = Source.[Id] 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Id], [Name], [ResearchCenterId], [Description], [Start_Date]) 
VALUES ([Id], [Name], [ResearchCenterId], [Description], [Start_Date]);

--MERGE INTO ResearchProjects AS Target 
--USING (VALUES 
--	('834-B7-766',1,'Apoyo a la creación de grupos de investigación y a la divulgación de la investigación','2020/3/30','2023/3/29','Apoyar la creación de grupos de investigación y facilitar la divulgación de la investigación realizada en el PCI y en el CITIC.'), 
--	('834-B4-745',1,'Apoyo a procesos de investigación y divulgación de proyectos del CITIC','2021/1/11','2021/12/31','Apoyo a procesos de investigación y divulgación de proyectos del CITIC'),
--	('834-C0-272',1,'Caracterización de las necesidades de capacitación y desarrollo profesional en Ciencia de Datos en Costa Rica','2021/5/16','2023/6/30','Este proyecto busca determinar la cobertura de las ofertas educativas en Ciencia de Datos con respecto a las necesidades de los profesionales en el área y las empresas en Costa Rica.'), 
--	('834-C0-006',1,'Clasificación de vehículos y peatones en vídeos de tráfico vial','2021/3/9','2023/3/8','En este proyecto se pretende desarrollar una herramienta de software que permita identificar objetos en movimiento como automóviles, buses, vehículos pesados, motocicletas, bicicletas, peatones y animales que cruzan por una vía pública como carreteras o intersecciones vigiladas por cámaras.'),
--	('834-B9-095',1,'Creación de una herramienta sistémica y con apoyo automático parcial para el aseguramiento de la información en sistemas de computadoras, software y redes','2021/3/1','2023/2/28','Esta investigación se propone con el fin de construir un prototipo de herramienta tecnológica, basada en software, para realizar procesos de aseguramiento de la información en sistemas de software e infraestructura tecnológica, que operen sobre computadoras y redes.'),
--	('834-C0-02',1,'Determinando la interacción de sistemas robóticos en diversos entornos','2022/3/7','2022/7/31','Determinar estrategias de interacción que permitan a los agentes de los sistemas robóticas, en escenarios de interacción humano-robot del mundo real, coordinar sus acciones e integrar sus recursos para realizar tareas en diversos entornos.'), 
--	('834-C0-007',1,'Diseño automático de hiperparámetros en redes neuronales artificiales profundas mediante computación evolutiva','2022/03/01','2023/2/28','Diseñar automáticamente redes neuronales artificiales profundas mediante la evolución artificial de hiperparámetros.'),
--	('834-C1-016',1,'Diseño y evaluación de un prototipo de plataforma de servicios de telerehabilitación para personas con antecedente de cáncer de mama','2021/3/1','2023/2/28','Diseñar y evaluar un prototipo de una plataforma de servicios de telerehabilitación para personas con antecedente de cáncer de mama.'),
--	('834-C2-145',1,'Edificios inteligentes y computación afectiva para mejorar la interacción humano robot','2022/3/7','2025/3/6','Construir una solución tecnológica que permita que un edificio inteligente facilite la interacción afectiva entre humanos y robots'),
--	('834-B4-412',1,'Fortalecimiento de la capacidad de desarrollo, adopción y mantenimiento de software del Instituto Costarricense de Electricidad','2021/10/15','2022/10/14','Apoyar al ICE a mejorar su capacidad interna para desarrollar, adaptar y mantener software para sus procesos de negocio.')
--) 
--AS Source ([Id], [GroupId], [Name], [Start_date], [End_date], [description]) 
--ON Target.[Id] = Source.[Id] 
--WHEN NOT MATCHED BY TARGET THEN 
--INSERT ([Id], [GroupId], [Name], [Start_date], [End_date], [description]) 
--VALUES ([Id], [GroupId], [Name], [Start_date], [End_date], [description]);