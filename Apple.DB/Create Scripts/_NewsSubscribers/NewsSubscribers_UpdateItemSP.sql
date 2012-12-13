IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'NewsSubscribers_UpdateItem')
	BEGIN
		DROP  Procedure  NewsSubscribers_UpdateItem
	END

GO

CREATE Procedure NewsSubscribers_UpdateItem
	(
		@ID int,
		@Name nvarchar (255),
		@Email nvarchar (255)
	)
AS

	UPDATE NewsSubscribers
	SET 
		[Name] = @Name,
		[Email] = @Email
	WHERE (ID = @ID)
GO
