IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'ContentPages_DeleteItem')
	BEGIN
		DROP  Procedure  ContentPages_DeleteItem
	END

GO

CREATE Procedure ContentPages_DeleteItem
	(
		@ID int
	)
AS
	DELETE FROM ContentPages
	WHERE (ID = @ID)
GO
