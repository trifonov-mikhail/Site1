IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'ContentSections_GetAll')
	BEGIN
		DROP  Procedure  ContentSections_GetAll
	END

GO

CREATE Procedure ContentSections_GetAll
AS
	SELECT *
	FROM ContentSections
GO
