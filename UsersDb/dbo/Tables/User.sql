CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[FirstName] nvarchar(40) NOT NULL,
	[LastName] nvarchar(40) NOT NULL
)
