CREATE PROCEDURE [dbo].[PUser_GetAll]
as
begin
	SELECT Id, FirstName, LastName
	FROM dbo.[User];
end
