IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DbConfig_AddUpdateItem')
	BEGIN
		DROP  Procedure  DbConfig_AddUpdateItem
	END

GO

CREATE Procedure DbConfig_AddUpdateItem
	(
		@Name NVarChar (255),
		@Value NVarChar (max)
	)
AS

	UPDATE DbConfig
	SET 
		[Value] = @Value
	WHERE ([Name] = @Name)
	
	if (@@ROWCOUNT=0)
	BEGIN
	INSERT INTO DbConfig
	(
		[Name] ,
		[Value]
	)
	VALUES
	(
		@Name ,
		@Value
	);
	END
GO
