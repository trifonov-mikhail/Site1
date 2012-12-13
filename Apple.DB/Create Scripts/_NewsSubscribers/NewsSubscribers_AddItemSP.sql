IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'NewsSubscribers_AddItem')
	BEGIN
		DROP  Procedure  NewsSubscribers_AddItem
	END

GO

CREATE Procedure NewsSubscribers_AddItem
	(
		@Name nvarchar (255),
		@Email nvarchar (255)
	)
AS

	INSERT INTO NewsSubscribers
	(
		[Name] ,
		[Email]
	)
	VALUES
	(
		@Name ,
		@Email
	);

	select scope_identity();
GO
