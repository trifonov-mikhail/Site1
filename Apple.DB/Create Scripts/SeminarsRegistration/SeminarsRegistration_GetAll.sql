IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'SeminarsRegistration_GetAll')
	BEGIN
		DROP  Procedure  SeminarsRegistration_GetAll
	END

GO

CREATE Procedure SeminarsRegistration_GetAll(@TypeId int=1, @emailType int = 0)
AS
	IF @emailType = 1 
	BEGIN
		SELECT * FROM SeminarsRegistration WHERE TypeId = @TypeId
		AND SentEmailType IN (1,3) Order By [DateCreated] DESC 
	END
	ELSE
	BEGIN
		SELECT * FROM SeminarsRegistration WHERE TypeId = @TypeId
		AND (SentEmailType=@emailType) Order By [DateCreated] DESC 
	END
GO