IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ContentPages')
	BEGIN
		DROP  Table ContentPages
	END
GO

CREATE TABLE ContentPages (
  	[ID] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] NVarChar (255) NOT NULL Unique
)ON [PRIMARY]
GO