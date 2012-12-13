SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER Procedure [dbo].[SuccessStories_GetAll]
(
	@LangCode nchar(2) = 'ru'
)
AS
	SELECT 
    ID, 
    GroupID, 
    LangCode, 
    [Date], 
    Title, 
    [Text], 
    PdfFileName
    --ImageFile, 
    --PdfFile,
	FROM SuccessStories
	where  (LangCode=@LangCode)

GO

