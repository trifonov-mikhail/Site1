IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'Articles')
	BEGIN
		DROP  Table Articles
	END
GO

CREATE TABLE Articles (
  	[ID] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[GroupID] int NOT NULL ,
	[LangCode] NChar (2) NOT NULL ,
	[Date] datetime NOT NULL ,
	[Title] NVarChar (255) NULL ,
	[Notice] NVarChar (1024) NULL ,
	[Text] NVarChar (max) NULL ,
	[File] varbinary (max) NULL ,
	[FileName] NVarChar (255) NULL ,
	[FileMime] NVarChar (255) NULL ,
	[FileSize] NVarChar (50) NULL ,
	[IsActive] bit NOT NULL DEFAULT (0) ,
	[OrderNumber] int NOT NULL DEFAULT (0) ,
	[DateCreated] datetime NOT NULL DEFAULT (getdate()) 
)ON [PRIMARY]
GO