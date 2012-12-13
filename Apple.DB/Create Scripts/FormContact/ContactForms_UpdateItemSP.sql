IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'ContactForms_UpdateItem')
	BEGIN
		DROP  Procedure  ContactForms_UpdateItem
	END

GO

CREATE Procedure ContactForms_UpdateItem
	(
		@ID int,
		@Subject NVarChar (255) = null,
		@To NVarChar (max) = null,
		@CC NVarChar (max) = null,
		@SetForAll bit = 0
	)
AS

	if (@SetForAll=1)
		BEGIN
			UPDATE ContactForms
			SET 
				[To] = @To,
				[CC] = @CC
		END
	ELSE
		BEGIN
			UPDATE ContactForms
			SET 
				[Subject] = @Subject,
				[To] = @To,
				[CC] = @CC
			WHERE (ID = @ID)
		END
GO
