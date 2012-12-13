IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'NewsSubscribers_GetByID')
	BEGIN
		DROP  Procedure  NewsSubscribers_GetByID
	END

GO

CREATE Procedure NewsSubscribers_GetByID
	(
		@ID int
	)
AS
	SELECT * 
	FROM NewsSubscribers
	WHERE (ID = @ID)
GO
