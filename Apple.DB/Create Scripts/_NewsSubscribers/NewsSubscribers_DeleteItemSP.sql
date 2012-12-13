IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'NewsSubscribers_DeleteItem')
	BEGIN
		DROP  Procedure  NewsSubscribers_DeleteItem
	END

GO

CREATE Procedure NewsSubscribers_DeleteItem
	(
		@ID int
	)
AS
	DELETE FROM NewsSubscribers
	WHERE (ID = @ID)
GO
