IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ContactForms')
	BEGIN
		DROP  Table ContactForms
	END
GO

CREATE TABLE ContactForms (
  	[ID] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] NVarChar (255) NOT NULL ,
	[Subject] NVarChar (255) NOT NULL ,
	[To] NVarChar (max) NOT NULL ,
	[CC] NVarChar (max) NULL ,
	[DateCreated] DateTime NOT NULL DEFAULT (getdate()) 
)ON [PRIMARY]
GO