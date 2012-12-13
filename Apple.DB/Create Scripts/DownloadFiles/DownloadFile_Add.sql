IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DownloadFile_Add')
	BEGIN
		DROP  Procedure  DownloadFile_Add
	END

GO

CREATE Procedure DownloadFile_Add

	(
	    @ID int OUTPUT,
		@TypeID int,
		@Name nvarchar(255),
		@Description nvarchar(500),
		@FileName nvarchar(255),
		@MimeType nvarchar(100)
		
	)


AS
  INSERT INTO DownloadFiles(TypeId, FileName, MimeType, Name, Description)
  VALUES(@TypeID, @FileName, @MimeType, @Name, @Description)
  SET @ID = scope_identity()

GO
