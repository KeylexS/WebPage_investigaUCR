CREATE TABLE [dbo].[ResearchProject](
	[ID] [varchar](50) NOT NULL PRIMARY KEY,
	[Name] [varchar](300) NOT NULL,
	[Description] [varchar](max) NULL,
	[GroupID] [int] NULL,
	[Start_date] [date] NOT NULL,
	[End_date] [date] NOT NULL,
	[PersonalIdentification] [int] NULL, 
    [Image] VARBINARY(MAX) NULL
)