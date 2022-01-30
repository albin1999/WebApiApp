if not exists(select 1 from dbo.[User])
begin /* Only runs if it dosent have data in the table */
	insert into dbo.[User] (FirstName, LastName)
	values('Albin', 'Andersson'),
	('Kevin', 'Karlsson'),
	('Erik', 'Eriksson'),
	('Daniel', 'Danielsson');
end