IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'NewsSubscribers_GetAll')
	BEGIN
		DROP  Procedure  NewsSubscribers_GetAll
	END

GO

CREATE Procedure NewsSubscribers_GetAll
AS
	SELECT *
	FROM NewsSubscribers
GO
