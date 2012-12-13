IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'NewsSubscribers')
	BEGIN
		DROP  Table NewsSubscribers
	END
GO

CREATE TABLE NewsSubscribers (
  	[ID] int IDENTITY(1,1) NOT NULL,
	[Name] nvarchar (255) NOT NULL ,
	[Email] nvarchar (255) NOT NULL UNIQUE,
	[DateCreated] datetime NOT NULL DEFAULT (getdate()) ,
	Constraint [PK_NewsSubscribers] PRIMARY KEY (id desc)
)ON [PRIMARY]
GO