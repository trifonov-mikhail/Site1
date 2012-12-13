IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'StatusRequests_DeleteItem')
	BEGIN
		DROP  Procedure  StatusRequests_DeleteItem
	END

GO

CREATE Procedure StatusRequests_DeleteItem
	(
		@ID int
	)
AS
	DELETE FROM StatusRequests
	WHERE (ID = @ID)
GO
