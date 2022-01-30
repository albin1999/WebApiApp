CREATE PROCEDURE [dbo].[PUser_Get]
	@Id int
AS
begin
	SELECT Id, FirstName, LastName
	from dbo.[User]
	where Id = @Id;
end

