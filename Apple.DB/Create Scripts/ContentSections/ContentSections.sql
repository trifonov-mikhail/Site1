IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ContentSections')
	BEGIN
		DROP  Table ContentSections
	END
GO

CREATE TABLE ContentSections (
  	[ID] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] NVarChar  (255) NOT NULL  unique
)ON [PRIMARY]
GO