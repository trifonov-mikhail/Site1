IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'StatusRequests_UpdateItem')
	BEGIN
		DROP  Procedure  StatusRequests_UpdateItem
	END

GO

CREATE Procedure StatusRequests_UpdateItem
	(
		@ID int,
		@Status NVarChar (5),
		@CompanyName NVarChar (255),
		@Address NVarChar (255),
		@ContactName NVarChar (255),
		@Phone NVarChar (100),
		@Email NVarChar (255),
		@IsPartner bit ,
		@IsServicePartner bit
	)
AS

	UPDATE StatusRequests
	SET 
		Status = @Status,
		CompanyName = @CompanyName,
		Address = @Address,
		ContactName = @ContactName,
		Phone = @Phone,
		Email = @Email,
		IsPartner = @IsPartner,
		IsServicePartner = @IsServicePartner
	WHERE (ID = @ID)
GO
