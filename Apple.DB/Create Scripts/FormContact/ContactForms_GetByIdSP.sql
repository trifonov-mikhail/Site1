IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'ContactForms_GetByID')
	BEGIN
		DROP  Procedure  ContactForms_GetByID
	END

GO

CREATE Procedure ContactForms_GetByID
	(
		@ID int
	)
AS
	SELECT *
	FROM ContactForms
	WHERE (ID = @ID)
GO
