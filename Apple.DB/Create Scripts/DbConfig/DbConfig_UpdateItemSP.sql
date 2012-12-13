IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DbConfig_UpdateItem')
	BEGIN
		DROP  Procedure  DbConfig_UpdateItem
	END

GO

CREATE Procedure DbConfig_UpdateItem
	(
		@Name NVarChar (255),
		@Value NVarChar (max)
	)
AS

	UPDATE DbConfig
	SET 
		[Value] = @Value
	WHERE ([Name] = @Name)
GO
