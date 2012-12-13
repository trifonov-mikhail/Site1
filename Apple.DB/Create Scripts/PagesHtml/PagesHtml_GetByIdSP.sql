IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'PagesHtml_GetByID')
	BEGIN
		DROP  Procedure  PagesHtml_GetByID
	END

GO

CREATE Procedure PagesHtml_GetByID
	(
		@Name nvarchar(100)
	)
AS
	SELECT [Name], [Html], DateCreated 
	FROM PagesHtml
	WHERE ([Name] = @Name)
GO
