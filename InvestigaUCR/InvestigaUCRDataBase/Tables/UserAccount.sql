CREATE TABLE [dbo].[UserAccount]
(
	[Id] [nvarchar](450) NOT NULL,
	[Email] [nvarchar](256) NOT NULL,
	[Name] VARCHAR(30) NULL,
	[LastName1] VARCHAR(30) NULL,
	[LastName2] VARCHAR(30) NULL,
	[Descripcion] VARCHAR(500) NULL,
	[ProfilePicture] [varbinary](max) NULL,
	CONSTRAINT PK_USERACCOUNT PRIMARY KEY([Id]),
	CONSTRAINT FK_USERACCOUNT FOREIGN KEY([Id]) REFERENCES [dbo].[AspNetUsers](Id) ON UPDATE CASCADE ON DELETE CASCADE
)