IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'ContentPages_GetAll')
	BEGIN
		DROP  Procedure  ContentPages_GetAll
	END

GO

CREATE Procedure ContentPages_GetAll
AS
	SELECT *
	FROM ContentPages
GO
