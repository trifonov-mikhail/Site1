IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'SerialNumbers')
	BEGIN
		DROP  Table SerialNumbers
	END
GO

CREATE TABLE SerialNumbers (
  	[ID] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[SerialNumber] NVarChar (20) NOT NULL UNIQUE,
	[ServiceID] int NULL ,
	[AdminID] int NOT NULL ,
	[CreatedDate] datetime NOT NULL DEFAULT (getdate()) ,
	[ModifiedDate] datetime NULL 
)ON [PRIMARY]
GO