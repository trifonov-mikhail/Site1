IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'SeminarsRegistration')
	BEGIN
		DROP  Table SeminarsRegistration
	END
GO

CREATE TABLE SeminarsRegistration (
  	[ID] int IDENTITY(1,1) NOT NULL,
  	[TypeId] int NOT NULL,
	[FIO] nvarchar(255) NOT NULL,
	[CompanyName] NVarChar (255) NOT NULL ,
	[JobTitle] NVarChar (255) NOT NULL ,
	[Email] NVarChar (255) NOT NULL ,
	[JobAction] int NOT NULL,
	[SentEmailType] int DEFAULT((0)),-- 1 - win, 2 - sorry, 3 - remind
	[EmailSent] Datetime NULL,
	[DateCreated] DateTime NOT NULL DEFAULT (getdate()) ,
	[Site] nvarchar(500) NULL
	CONSTRAINT [PK_SeminarsRegistration] PRIMARY KEY (ID desc)
)ON [PRIMARY]
GO 