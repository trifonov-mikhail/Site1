IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'SerialNumbers_AddItem')
	BEGIN
		DROP  Procedure  SerialNumbers_AddItem
	END

GO

CREATE Procedure SerialNumbers_AddItem
	(
		@SerialNumber NVarChar (20),
		@ServiceID int = NULL ,
		@AdminID int
	)
AS

	INSERT INTO SerialNumbers
	(
		[SerialNumber] ,
		[ServiceID] ,
		[AdminID]
	)
	VALUES
	(
		@SerialNumber ,
		@ServiceID ,
		@AdminID
	);

	select scope_identity();
GO
