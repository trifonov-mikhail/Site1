CREATE TABLE [dbo].[DownloadUserForms]
(
	ID int NOT NULL Identity(1,1),
	FirstName nvarchar(50),
	LastName nvarchar(50),
	Email nvarchar(300),
	FileID int,
	Url nvarchar(255),
	CreateDate datetime default(getdate())
)
