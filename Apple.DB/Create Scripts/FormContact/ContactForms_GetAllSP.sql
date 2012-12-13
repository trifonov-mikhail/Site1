IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'ContactForms_GetAll')
	BEGIN
		DROP  Procedure  ContactForms_GetAll
	END

GO

CREATE Procedure ContactForms_GetAll
AS
	SELECT *
	FROM ContactForms
GO
