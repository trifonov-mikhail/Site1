IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DbConfig_DeleteItem')
	BEGIN
		DROP  Procedure  DbConfig_DeleteItem
	END

GO

CREATE Procedure DbConfig_DeleteItem
	(
		@Name NVarChar
	)
AS
	DELETE FROM DbConfig
	WHERE ([Name] = @Name)
GO
