IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'PagesHtml_GetAll')
	BEGIN
		DROP  Procedure  PagesHtml_GetAll
	END

GO

CREATE Procedure PagesHtml_GetAll
AS
	SELECT [Name],'' as [Html], DateCreated
	FROM PagesHtml
GO
