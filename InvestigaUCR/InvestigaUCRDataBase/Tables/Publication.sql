CREATE TABLE [dbo].[Publication](
	[DOI] [varchar](50) NOT NULL,
	[Reference] [varchar](400) NULL,
	[Visibility] [tinyint] NOT NULL,
	[Type] [varchar](50) NULL,
	[Publisher_name] [varchar](50) NULL,
	[Name] [varchar](150) NULL,
	[Abstract] [varchar](5000) NULL,
	[_Date] [date] NULL,
	[ResearchGroupId] [varchar](30) NULL,

	PRIMARY KEY(DOI),
	FOREIGN KEY(ResearchGroupId) REFERENCES [Group](Id)
	)
