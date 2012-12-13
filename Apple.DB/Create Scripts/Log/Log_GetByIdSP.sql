IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Log_GetByID')
	BEGIN
		DROP  Procedure  Log_GetByID
	END

GO

CREATE Procedure Log_GetByID
	(
		@ID int
	)
AS
	SELECT *
	FROM [Log]
	WHERE (ID = @ID)
GO
