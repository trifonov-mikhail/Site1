SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [SuccessStories_DeleteGroup]
(
	@GroupID int = 0
)
AS
	DELETE FROM SuccessStories WHERE GroupID = @GroupID
GO 