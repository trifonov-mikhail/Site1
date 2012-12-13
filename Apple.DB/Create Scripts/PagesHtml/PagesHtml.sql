IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'PagesHtml')
	BEGIN
		DROP  Table PagesHtml
	END
GO

CREATE TABLE PagesHtml (
  	[Name] nvarchar (100) NOT NULL PRIMARY KEY ,
	[Html] nvarchar (max) NULL ,
	[DateCreated] datetime NOT NULL DEFAULT (getdate()) 
)ON [PRIMARY]
GO