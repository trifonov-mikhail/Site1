IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'ContentSections_GetByID')
	BEGIN
		DROP  Procedure  ContentSections_GetByID
	END

GO

CREATE Procedure ContentSections_GetByID
	(
		@ID int
	)
AS
	SELECT *
	FROM ContentSections
	WHERE (ID = @ID)
GO
