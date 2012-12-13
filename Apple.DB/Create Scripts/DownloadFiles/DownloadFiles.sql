IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'DownloadFiles')
	BEGIN
		DROP  Table DownloadFiles
	END
GO

CREATE TABLE DownloadFiles
(
    id  int IDENTITY(1,1) not null,
    TypeId int not null,
    FileName NVARCHAR(255),
    MimeType nvarchar(550),
    Name nvarchar(255),
    Description nvarchar(255)
)
GO

