IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DbConfig_GetAll')
	BEGIN
		DROP  Procedure  DbConfig_GetAll
	END

GO

CREATE Procedure DbConfig_GetAll
AS
	SELECT [Name], Value, DateCreated
	FROM DbConfig
GO
