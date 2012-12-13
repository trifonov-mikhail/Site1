IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'ContentSections_AddItem')
	BEGIN
		DROP  Procedure  ContentSections_AddItem
	END

GO

CREATE Procedure ContentSections_AddItem
	(
		@Name NVarChar (255)
	)
AS

	INSERT INTO ContentSections
	(
		[Name]
	)
	VALUES
	(
		@Name
	);

	select scope_identity();
GO
