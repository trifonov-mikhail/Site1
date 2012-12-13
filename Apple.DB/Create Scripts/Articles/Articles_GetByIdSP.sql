IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Articles_GetByID')
	BEGIN
		DROP  Procedure  Articles_GetByID
	END

GO

CREATE Procedure Articles_GetByID
	(
		@ID int
	)
AS
	SELECT ID, GroupID, LangCode, Date, Title, Notice, Text, File, FileName, FileMime, FileSize, IsActive, OrderNumber, DateCreated 
	FROM Articles
	WHERE (ID = @ID)
GO
