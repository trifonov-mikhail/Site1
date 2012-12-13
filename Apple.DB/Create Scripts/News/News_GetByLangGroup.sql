IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'News_GetByLangGroup')
	BEGIN
		DROP  Procedure  News_GetByLangGroup
	END

GO

CREATE Procedure News_GetByLangGroup
	(
		@LangCode nchar(2) = 'ru',
		@GroupID int
	)
AS
	SELECT ID, GroupID, LangCode, [Date], Title, Notice, [Text], ImageFile, IsActive, OrderNumber, DateCreated 
	FROM News
	WHERE LangCode = @LangCode AND GroupID = @GroupID
GO
