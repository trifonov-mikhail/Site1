IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CaseStudies_GetByID')
	BEGIN
		DROP  Procedure  CaseStudies_GetByID
	END

GO

CREATE Procedure CaseStudies_GetByID
	(
		@ID int
	)
AS
	SELECT ID, GroupID, LangCode, Date, Title, Notice, Text, File, FileName, FileMime, FileSize, IsActive, OrderNumber, DateCreated 
	FROM CaseStudies
	WHERE (ID = @ID)
GO
