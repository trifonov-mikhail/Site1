IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'ContentPages_AddItem')
	BEGIN
		DROP  Procedure  ContentPages_AddItem
	END

GO

CREATE Procedure ContentPages_AddItem
	(
		@Name NVarChar (255)
	)
AS

	INSERT INTO ContentPages
	(
		[Name]
	)
	VALUES
	(
		@Name
	);

	select scope_identity();
GO
