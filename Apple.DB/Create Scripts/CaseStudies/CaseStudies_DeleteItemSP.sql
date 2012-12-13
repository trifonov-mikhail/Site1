IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CaseStudies_DeleteItem')
	BEGIN
		DROP  Procedure  CaseStudies_DeleteItem
	END

GO

CREATE Procedure CaseStudies_DeleteItem
	(
		@ID int
	)
AS
	DELETE FROM CaseStudies
	WHERE (ID = @ID)
GO
