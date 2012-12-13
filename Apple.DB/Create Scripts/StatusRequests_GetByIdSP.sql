IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'StatusRequests_GetByID')
	BEGIN
		DROP  Procedure  StatusRequests_GetByID
	END

GO

CREATE Procedure StatusRequests_GetByID
	(
		@ID int
	)
AS
	SELECT *
	FROM StatusRequests
	WHERE (ID = @ID)
GO
