IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DownloadFile_Update')
	BEGIN
		DROP  Procedure  DownloadFile_Update
	END

GO

CREATE Procedure DownloadFile_Update
(
        @ID int,
		@TypeID int,
		@Name nvarchar(255),
		@Description nvarchar(500),
		@FileName nvarchar(255),
		@MimeType nvarchar(100)
		
	)
AS
    UPDATE DownloadFiles 
       SET TypeID = @TypeID,
            Name = @Name,
            Description = @Description,
            FileName = @FileName,
            MimeType = @MimeType
    WHERE ID = @ID

GO
