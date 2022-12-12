CREATE TRIGGER TR_AddNews ON dbo.News
INSTEAD OF INSERT AS
BEGIN
	SET NOCOUNT ON;

	set implicit_transactions off;
	set transaction isolation level
	read committed;
	BEGIN TRANSACTION taddnews;
		DECLARE @FechaGrupo Date;
		SELECT @FechaGrupo = [Start_Date]
		FROM [Group]
		WHERE Id IN (SELECT GroupId FROM inserted)

		DECLARE @FechaNoticia Date;
		SELECT @FechaNoticia = [PublicationDate]
		FROM inserted
	COMMIT TRANSACTION 

		IF @FechaGrupo IS NULL OR  @FechaNoticia >= @FechaGrupo 
			BEGIN
			INSERT INTO News (Id,Title,Description,Image,Author,PublicationDate,GroupId)
			SELECT *
			FROM inserted
			END
		ELSE
			BEGIN
			PRINT 'La noticia tiene una fecha menor a la creacion del grupo'
			END

END