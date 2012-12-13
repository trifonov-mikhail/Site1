IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'SerialNumbers_DeleteItem')
	BEGIN
		DROP  Procedure  SerialNumbers_DeleteItem
	END

GO

CREATE Procedure SerialNumbers_DeleteItem
	(
		@ID int
	)
AS
	DELETE FROM SerialNumbers
	WHERE (ID = @ID)
GO
