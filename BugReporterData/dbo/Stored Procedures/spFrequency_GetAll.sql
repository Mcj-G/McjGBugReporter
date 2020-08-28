CREATE PROCEDURE [dbo].[spFrequency_GetAll]
	
AS
begin
	set nocount on;

	select [Id], [Name]
	from [dbo].[Frequency]

end
