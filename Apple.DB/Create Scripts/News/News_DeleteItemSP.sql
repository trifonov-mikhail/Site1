IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'News_DeleteItem')
	BEGIN
		DROP  Procedure  News_DeleteItem
	END

GO

CREATE Procedure News_DeleteItem
	(
		@ID int
	)
AS
	DELETE FROM News
	WHERE (ID = @ID)
GO
