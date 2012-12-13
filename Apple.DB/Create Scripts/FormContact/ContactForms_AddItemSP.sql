IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'ContactForms_AddItem')
	BEGIN
		DROP  Procedure  ContactForms_AddItem
	END

GO

CREATE Procedure ContactForms_AddItem
	(
		@Name NVarChar (255) = null,
		@Subject NVarChar (255) = null,
		@To NVarChar (max) = null,
		@CC NVarChar (max) = null
	)
AS

	INSERT INTO ContactForms
	(
		[Name] ,
		[Subject] ,
		[To] ,
		[CC]
	)
	VALUES
	(
		@Name ,
		@Subject ,
		@To ,
		@CC
	);

	select scope_identity();
GO
