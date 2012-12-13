IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Articles_GetAll')
	BEGIN
		DROP  Procedure  Articles_GetAll
	END

GO

CREATE Procedure Articles_GetAll
AS
	SELECT ID, GroupID, LangCode, Date, Title, Notice, Text, File, FileName, FileMime, FileSize, IsActive, OrderNumber, DateCreated
	FROM Articles
GO
