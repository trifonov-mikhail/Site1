IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DbConfig_GetByID')
	BEGIN
		DROP  Procedure  DbConfig_GetByID
	END

GO

CREATE Procedure DbConfig_GetByID
	(
		@Name NVarChar(255)
	)
AS
	SELECT [Name], Value, DateCreated 
	FROM DbConfig
	WHERE ([Name] = @Name)
GO
