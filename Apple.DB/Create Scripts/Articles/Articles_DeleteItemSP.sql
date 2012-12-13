IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Articles_DeleteItem')
	BEGIN
		DROP  Procedure  Articles_DeleteItem
	END

GO

CREATE Procedure Articles_DeleteItem
	(
		@ID int
	)
AS
	DELETE FROM Articles
	WHERE (ID = @ID)
GO
