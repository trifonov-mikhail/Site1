IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'StatusRequests_GetByStatus')
	BEGIN
		DROP  Procedure  StatusRequests_GetByStatus
	END

GO

CREATE Procedure StatusRequests_GetByStatus
(
	@Status nvarchar(5) = null
)
AS
	SELECT *
	FROM StatusRequests
	where (@Status is null)or(Status=@Status)
GO
