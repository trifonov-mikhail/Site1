IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'PagesHtml_UpdateItem')
	BEGIN
		DROP  Procedure  PagesHtml_UpdateItem
	END

GO

CREATE Procedure PagesHtml_UpdateItem
	(
		@Name nvarchar (100),
		@Html nvarchar (max) = null
	)
AS

	UPDATE PagesHtml
	SET 
		[Html] = @Html
	WHERE ([Name] = @Name)
GO
