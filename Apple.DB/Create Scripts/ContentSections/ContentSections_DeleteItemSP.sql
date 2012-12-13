IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'ContentSections_DeleteItem')
	BEGIN
		DROP  Procedure  ContentSections_DeleteItem
	END

GO

CREATE Procedure ContentSections_DeleteItem
	(
		@ID int
	)
AS
	DELETE FROM ContentSections
	WHERE (ID = @ID)
GO
