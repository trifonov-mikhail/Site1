IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CaseStudies_GetAll')
	BEGIN
		DROP  Procedure  CaseStudies_GetAll
	END

GO

CREATE Procedure CaseStudies_GetAll
AS
	SELECT ID, GroupID, LangCode, Date, Title, Notice, Text, File, FileName, FileMime, FileSize, IsActive, OrderNumber, DateCreated
	FROM CaseStudies
GO
