IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Log_GetAll')
	BEGIN
		DROP  Procedure  Log_GetAll
	END

GO

CREATE Procedure Log_GetAll
AS
	SELECT *
	FROM [Log]
GO
