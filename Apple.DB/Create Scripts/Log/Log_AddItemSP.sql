IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Log_AddItem')
	BEGIN
		DROP  Procedure  Log_AddItem
	END

GO

CREATE Procedure Log_AddItem
	(
		@MessageType int ,
		@Source NVarChar (255),
		@Message NVarChar (max)
	)
AS

	INSERT INTO [Log]
	(
		[MessageType] ,
		[Source] ,
		[Message]
	)
	VALUES
	(
		@MessageType ,
		@Source ,
		@Message
	);

	select scope_identity();
GO
