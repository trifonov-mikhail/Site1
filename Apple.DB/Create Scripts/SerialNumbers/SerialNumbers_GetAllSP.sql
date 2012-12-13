IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'SerialNumbers_GetAll')
	BEGIN
		DROP  Procedure  SerialNumbers_GetAll
	END

GO

CREATE Procedure SerialNumbers_GetAll
AS
	SELECT [ID], [SerialNumber], [ServiceID], [AdminID], [CreatedDate], [ModifiedDate]
	FROM SerialNumbers
GO
