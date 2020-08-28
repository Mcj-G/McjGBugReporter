CREATE PROCEDURE [dbo].[spPriority_GetAll]
	
AS
begin
	set nocount on;

	select [Id], [Name]
	from [dbo].[Priority];

end
