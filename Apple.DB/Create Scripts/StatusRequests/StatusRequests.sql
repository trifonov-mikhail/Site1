IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'StatusRequests')
	BEGIN
		DROP  Table StatusRequests
	END
GO

CREATE TABLE StatusRequests (
  	[ID] int IDENTITY(1,1) NOT NULL,
	[Status] NVarChar (5) NOT NULL ,
	[CompanyName] NVarChar (255) NOT NULL ,
	[Address] NVarChar (255) NOT NULL ,
	[ContactName] NVarChar (255) NOT NULL ,
	[Phone] VarChar (20) NOT NULL ,
	[Email] NVarChar (255) NOT NULL ,
	[IsPartner] bit NOT NULL ,
	[IsServicePartner] bit NOT NULL ,
	[DateCreated] DateTime NOT NULL DEFAULT (getdate()) ,
	CONSTRAINT [PK_StatusRequests] PRIMARY KEY (ID desc)
)ON [PRIMARY]
GO