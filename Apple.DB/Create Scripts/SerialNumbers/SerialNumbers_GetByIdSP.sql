IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'SerialNumbers_GetByID')
	BEGIN
		DROP  Procedure  SerialNumbers_GetByID
	END

GO

CREATE Procedure SerialNumbers_GetByID
	(
		@ID int
	)
AS
	SELECT [ID], [SerialNumber], [ServiceID], [AdminID], [CreatedDate], [ModifiedDate] 
	FROM SerialNumbers
	WHERE (ID = @ID)
GO
