IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'ContactForms_GetByName')
	BEGIN
		DROP  Procedure  ContactForms_GetByName
	END

GO

CREATE Procedure ContactForms_GetByName
	(
		@Name nvarchar (255)
	)
AS
	SELECT *
	FROM ContactForms
	WHERE ([Name] = @Name)
GO
