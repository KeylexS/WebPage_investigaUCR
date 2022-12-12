CREATE TABLE [dbo].[ResearchAreaKeyword]
(
	[ResearchAreaID] INT NOT NULL, 
    [Keyword] VARCHAR(50) NOT NULL,
	CONSTRAINT [FK_ResearchArea_ID] FOREIGN KEY ([ResearchAreaID]) REFERENCES [ResearchArea]([Id]),
    CONSTRAINT [PK_ResearchAreaKeyword] PRIMARY KEY (ResearchAreaID,Keyword)
)
