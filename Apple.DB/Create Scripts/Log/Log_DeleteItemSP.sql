IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Log_DeleteItem')
	BEGIN
		DROP  Procedure  Log_DeleteItem
	END

GO

CREATE Procedure Log_DeleteItem
	(
		@ID int
	)
AS
	DELETE FROM [Log]
	WHERE (ID = @ID)
GO
