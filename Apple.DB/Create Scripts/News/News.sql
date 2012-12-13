IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'News')
	BEGIN
		DROP  Table News
	END
GO

CREATE TABLE News (
  	[ID] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[GroupID] int NOT NULL ,
	[LangCode] NChar (2) NOT NULL ,
	[Date] datetime NOT NULL ,
	[Title] NVarChar (255) NULL ,
	[Notice] NVarChar (1024) NULL ,
	[Text] NVarChar (max) NULL ,
	[ImageFile] varbinary (max) NULL ,
	[IsActive] bit NOT NULL DEFAULT (0) ,
	[OrderNumber] int NOT NULL DEFAULT (0) ,
	[DateCreated] datetime NOT NULL DEFAULT (getdate()) 
)ON [PRIMARY]
GO