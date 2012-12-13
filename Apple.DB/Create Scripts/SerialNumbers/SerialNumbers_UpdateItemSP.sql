IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'SerialNumbers_UpdateItem')
	BEGIN
		DROP  Procedure  SerialNumbers_UpdateItem
	END

GO

CREATE Procedure SerialNumbers_UpdateItem
	(
		@ID int,
		@SerialNumber NVarChar (20),
		@ServiceID int = NULL ,
		@AdminID int 
	)
AS

	UPDATE SerialNumbers
	SET 
		[SerialNumber] = @SerialNumber,
		[ServiceID] = @ServiceID,
		[AdminID] = @AdminID,
		[ModifiedDate] = getdate()
	WHERE (ID = @ID)
GO
