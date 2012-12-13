IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'StatusRequests_AddItem')
	BEGIN
		DROP  Procedure  StatusRequests_AddItem
	END

GO

CREATE Procedure StatusRequests_AddItem
	(
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

	INSERT INTO StatusRequests
	(
		[Status] ,
		[CompanyName] ,
		[Address] ,
		[ContactName] ,
		[Phone] ,
		[Email] ,
		[IsPartner] ,
		[IsServicePartner]
	)
	VALUES
	(
		@Status ,
		@CompanyName ,
		@Address ,
		@ContactName ,
		@Phone ,
		@Email ,
		@IsPartner ,
		@IsServicePartner
	);

	select scope_identity();
GO
