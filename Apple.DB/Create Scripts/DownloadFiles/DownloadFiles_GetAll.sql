IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DownloadFile_GetAll')
	BEGIN
		DROP  Procedure  DownloadFile_GetAll
	END

GO

CREATE Procedure DownloadFile_GetAll

AS
    SELECT * FROM DownloadFiles

GO


