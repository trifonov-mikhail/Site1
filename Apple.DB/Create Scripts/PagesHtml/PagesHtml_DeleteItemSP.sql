IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'PagesHtml_DeleteItem')
	BEGIN
		DROP  Procedure  PagesHtml_DeleteItem
	END

GO

CREATE Procedure PagesHtml_DeleteItem
	(
		@Name nvarchar(100)
	)
AS
	DELETE FROM PagesHtml
	WHERE ([Name] = @Name)
GO
