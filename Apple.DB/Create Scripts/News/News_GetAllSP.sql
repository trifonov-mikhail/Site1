IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'News_GetAll')
	BEGIN
		DROP  Procedure  News_GetAll
	END

GO

CREATE Procedure News_GetAll
(
	@LangCode nchar(2) = 'ru'
)
AS
	SELECT ID, GroupID, LangCode, [Date], Title, Notice, [Text], IsActive, OrderNumber, DateCreated
	FROM News
	where  (LangCode=@LangCode)
GO
