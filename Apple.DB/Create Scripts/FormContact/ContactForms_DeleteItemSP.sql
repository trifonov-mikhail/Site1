IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'ContactForms_DeleteItem')
	BEGIN
		DROP  Procedure  ContactForms_DeleteItem
	END

GO

CREATE Procedure ContactForms_DeleteItem
	(
		@ID int
	)
AS
	DELETE FROM ContactForms
	WHERE (ID = @ID)
GO
