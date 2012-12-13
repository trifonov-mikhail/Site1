IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DbConfig_AddItem')
	BEGIN
		DROP  Procedure  DbConfig_AddItem
	END

GO

CREATE Procedure DbConfig_AddItem
	(
		@Name NVarChar (255),
		@Value NVarChar (max)
	)
AS

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

GO
