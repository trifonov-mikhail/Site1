IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'ContentPages_UpdateItem')
	BEGIN
		DROP  Procedure  ContentPages_UpdateItem
	END

GO

CREATE Procedure ContentPages_UpdateItem
	(
		@ID int,
		@Name NVarChar (255)
	)
AS

	UPDATE ContentPages
	SET 
		[Name] = @Name
	WHERE (ID = @ID)
GO
