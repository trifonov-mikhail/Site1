IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'News_GetByID')
	BEGIN
		DROP  Procedure  News_GetByID
	END

GO

CREATE Procedure News_GetByID
	(
		@ID int
	)
AS
	SELECT ID, GroupID, LangCode, [Date], Title, Notice, [Text], ImageFile, IsActive, OrderNumber, DateCreated 
	FROM News
	WHERE (ID = @ID)
GO
