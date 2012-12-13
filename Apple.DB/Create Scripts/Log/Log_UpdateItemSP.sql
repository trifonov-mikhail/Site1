IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Log_UpdateItem')
	BEGIN
		DROP  Procedure  Log_UpdateItem
	END

GO

CREATE Procedure Log_UpdateItem
	(
		@ID int,
		@MessageType int ,
		@Source NVarChar (255),
		@Message NVarChar (max)
	)
AS

	UPDATE [Log]
	SET 
		MessageType = @MessageType,
		Source = @Source,
		Message = @Message
	WHERE (ID = @ID)
GO
