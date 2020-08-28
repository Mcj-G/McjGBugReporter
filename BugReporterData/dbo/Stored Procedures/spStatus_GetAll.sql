CREATE PROCEDURE [dbo].[spStatus_GetAll]
	
AS
begin
	set nocount on;

	select [Id], [Name]
	from [dbo].[Status];

end
