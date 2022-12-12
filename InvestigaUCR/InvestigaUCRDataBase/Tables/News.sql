CREATE TABLE [dbo].[News]
(
	Id VARCHAR(30) NOT NULL PRIMARY KEY,
    [Title] VARCHAR(200) NULL,
    [Description] NVARCHAR(MAX) NULL,
    [Author] NCHAR(100) NULL,
    [PublicationDate] DATETIME NULL,
)
