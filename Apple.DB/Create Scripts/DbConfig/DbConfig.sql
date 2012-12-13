IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'DbConfig')
	BEGIN
		DROP  Table DbConfig
	END
GO

CREATE TABLE DbConfig (
  	[Name] NVarChar (255) NOT NULL PRIMARY KEY ,
	[Value] NVarChar (max) NOT NULL ,
	[DateCreated] datetime NOT NULL DEFAULT (getdate()) 
)ON [PRIMARY]
GO