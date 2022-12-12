CREATE TABLE [dbo].[Coordinator]
(
	[Id] VARCHAR(90) NOT NULL,
	[GroupId] VARCHAR(30) NOT NULL,
	CONSTRAINT PK_COORDINATOR PRIMARY KEY([Id], [GroupId]),
	CONSTRAINT FK_COORDINATOR_PERSON FOREIGN KEY([Id]) REFERENCES Person(Id),
	CONSTRAINT FK_COORDINATOR_GROUP FOREIGN KEY([GroupId]) REFERENCES [dbo].[Group](Id),
	CONSTRAINT [CoordinatorIdCheck] CHECK  (([Id] like '%@%'))
)

GO

CREATE TRIGGER COORDINATOR_CORRECT_GROUPID_BY_ID
ON dbo.Coordinator
INSTEAD OF INSERT
AS BEGIN
	DECLARE @newGroupId VARCHAR(30); SELECT @newGroupId = GroupId FROM inserted
	DECLARE @newEmail VARCHAR(90); SELECT @newEmail = Id FROM inserted
	
	IF ((@newEmail LIKE '%@ucr.ac.cr') OR (@newEmail LIKE '%@ecci.ucr.ac.cr')
		AND (@newGroupId LIKE 'CRCUCRCITIC%'))
		INSERT INTO dbo.Coordinator(Id, GroupId)
		SELECT Id, GroupID FROM inserted;
	ELSE
		SELECT 'Groups from Universidad de Costa Rica can only
		be coordinated by someone from the same university' AS Error
END
