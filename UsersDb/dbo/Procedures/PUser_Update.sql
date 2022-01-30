CREATE PROCEDURE [dbo].[PUser_Update]
	@Id int,
	@FirstName nvarchar(40),
	@LastName nvarchar(40)
AS
begin
	Update dbo.[User]
	set FirstName = @FirstName, LastName = @LastName
	where Id = @Id;
end
