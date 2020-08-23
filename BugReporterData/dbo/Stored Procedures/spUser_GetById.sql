CREATE PROCEDURE [dbo].[spUser_GetById]
	@Id nvarchar(128) 
AS
begin
	set nocount on;

	select [Id], [FirstName], [LastName], [EmailAddress], [CreatedDate]
	from [dbo].[User]
	where Id = @Id;
end
