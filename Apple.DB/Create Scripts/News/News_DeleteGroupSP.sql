IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'News_DeleteGroup')
	BEGIN
		DROP  Procedure  News_DeleteGroup
	END

GO

CREATE Procedure News_DeleteGroup
	(
		@GroupID int
	)
AS
	DELETE FROM News
	WHERE (GroupID = @GroupID)
GO
