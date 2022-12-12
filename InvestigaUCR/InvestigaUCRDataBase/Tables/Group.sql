CREATE TABLE [dbo].[Group]
(
	[Id] VARCHAR(30) NOT NULL ,
    [Name] VARCHAR(100) NOT NULL,
    [ResearchCenterID] INT NOT NULL,
    [Description] NVARCHAR(MAX) NOT NULL,
    [Start_Date] DATE NULL, 
    [Image] VARBINARY(MAX) NULL,
    UNIQUE ([Name],[ResearchCenterID]),
    CONSTRAINT [FK_Center_ID] FOREIGN KEY ([ResearchCenterID]) REFERENCES [ResearchCenter]([Id]),
    CONSTRAINT [PK_Grupo] PRIMARY KEY (Id)
)
