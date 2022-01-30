CREATE PROCEDURE [dbo].[PUser_Insert]
	@FirstName nvarchar(40),
	@LastName nvarchar(40)
AS
begin
	Insert into dbo.[User](FirstName, LastName)
	Values(@FirstName, @LastName);
end
