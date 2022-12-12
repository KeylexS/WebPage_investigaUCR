CREATE TABLE [dbo].[Person](
	[Id] [varchar](90) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[LastName1] [varchar](30) NULL,
	[LastName2] [varchar](30) NOT NULL,
	[HighestDegree] [varchar](20) NULL,
	[University] [varchar](90) NULL,
	[ProfilePicture] [varbinary](max) NULL,
	CHECK  (([HighestDegree]='Dr.' OR [HighestDegree]='Dra.' OR [HighestDegree]='Lic.' OR [HighestDegree]='MSc.' OR [HighestDegree]='Bach.')),
  CHECK  (([Id] like '%@%')),
 CONSTRAINT [PK_PERSON] PRIMARY KEY CLUSTERED 
 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

--ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [HighestDegreeCheck] CHECK  (([HighestDegree]='Dr.' OR [HighestDegree]='Dra.' OR [HighestDegree]='Lic.' OR [HighestDegree]='MSc.' OR [HighestDegree]='Bach.'))
--GO

--ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [HighestDegreeCheck]
--GO

--ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [IdCheck]
--GO

--ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [IdCheck]
--GO

