IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'PagesHtml_AddItem')
	BEGIN
		DROP  Procedure  PagesHtml_AddItem
	END

GO

CREATE Procedure PagesHtml_AddItem
	(
		@Name nvarchar (100),
		@Html nvarchar (max) = null
	)
AS

	INSERT INTO PagesHtml
	(
		[Name] ,
		[Html]
	)
	VALUES
	(
		@Name ,
		@Html
	);
GO
