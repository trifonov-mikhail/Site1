IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'ContentPages_GetByID')
	BEGIN
		DROP  Procedure  ContentPages_GetByID
	END

GO

CREATE Procedure ContentPages_GetByID
	(
		@ID int
	)
AS
	SELECT *
	FROM ContentPages
	WHERE (ID = @ID)
GO
