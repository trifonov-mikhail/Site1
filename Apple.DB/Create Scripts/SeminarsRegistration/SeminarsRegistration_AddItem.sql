IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'SeminarsRegistration_AddItem')
BEGIN
	DROP  Procedure  SeminarsRegistration_AddItem
END

GO

CREATE Procedure SeminarsRegistration_AddItem
(
	@FIO nvarchar(255),
	@CompanyName nvarchar(255),
	@JobTitle nvarchar(255),
	@Email nvarchar(255),
	@JobAction int,
	@TypeId int = 1,
	@Site nvarchar(500) = NULL
) AS
    IF NOT EXISTS(SELECT * FROM SeminarsRegistration WHERE [Email] = @Email)
    BEGIN
        INSERT INTO SeminarsRegistration
	    ([FIO], [CompanyName], [JobTitle], [Email], [JobAction], TypeId, Site)
	    VALUES(@FIO, @CompanyName, @JobTitle, @Email, @JobAction, @TypeId, @Site);
	    select scope_identity(); 
	END
	ELSE
	BEGIN 
	   SELECT -1
	END
GO