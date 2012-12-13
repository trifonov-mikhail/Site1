IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'Log')
	BEGIN
		DROP  Table Log
	END
GO

CREATE TABLE Log (
  	[ID] int IDENTITY(1,1) NOT NULL,
	[MessageType] int NOT NULL ,
	[Source] NVarChar (255) NOT NULL ,
	[Message] NVarChar (max) NOT NULL ,
	[DateCreated] DateTime NOT NULL DEFAULT (getdate()) ,
	Constraint [PK_Log] PRIMARY KEY (id desc)
)ON [PRIMARY]
GO