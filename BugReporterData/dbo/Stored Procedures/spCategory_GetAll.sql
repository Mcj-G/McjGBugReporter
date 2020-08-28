CREATE PROCEDURE [dbo].[spCategory_GetAll]
	
AS
begin
	set nocount on;

	select [Id], [Name]
	from [dbo].[Category];

end