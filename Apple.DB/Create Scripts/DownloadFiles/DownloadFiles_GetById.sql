IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DownloadFiles_GetById')
	BEGIN
		DROP  Procedure  DownloadFiles_GetById
	END

GO

CREATE Procedure DownloadFiles_GetById

	(
		@ID int
	)

AS
    SELECT * FROM DownloadFiles WHERE ID = @ID

GO

