CREATE PROCEDURE [dbo].[spProject_GetAll]
	
AS
begin
	set nocount on;

	select [Id], [Name], [Version]
	from [dbo].[Project];

end
