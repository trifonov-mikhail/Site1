IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'StatusRequests_GetAll')
	BEGIN
		DROP  Procedure  StatusRequests_GetAll
	END

GO

CREATE Procedure StatusRequests_GetAll
AS
	SELECT *
	FROM StatusRequests
GO
