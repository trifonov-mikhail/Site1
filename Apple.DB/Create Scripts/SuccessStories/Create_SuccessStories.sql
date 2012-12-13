SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SuccessStories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GroupID] [int] NOT NULL,
	[LangCode] [nchar](2) NOT NULL,
	[Date] [datetime] NULL,
	[Title] [nvarchar](255) NULL,
	[Text] [nvarchar](max) NULL,
	[ImageFile] [varbinary](max) NULL, -- shared for all languages
	[PdfFile] [varbinary](max) NULL, -- different for each languages
	[PdfFileName] nvarchar(max) NULL,
	[DateCreated] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SuccessStories] ADD  DEFAULT (getdate()) FOR [DateCreated]
GO

 