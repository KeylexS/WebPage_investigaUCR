CREATE TABLE [dbo].[GroupWorksOnArea]
(
	[ResearchAreaID] INT NOT NULL, 
    [ResearchGroupID] VARCHAR(30) NOT NULL,
    CONSTRAINT FK_ResearchArea_ResearchAreaId FOREIGN KEY(ResearchAreaID) REFERENCES ResearchArea(Id),
    CONSTRAINT FK_Groupid FOREIGN KEY(ResearchGroupID) REFERENCES dbo.[Group](Id),
    CONSTRAINT [PK_WorksOnArea] PRIMARY KEY (ResearchAreaID,ResearchGroupID)
)
