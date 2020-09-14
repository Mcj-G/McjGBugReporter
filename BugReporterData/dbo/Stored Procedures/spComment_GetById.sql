CREATE PROCEDURE [dbo].[spComment_GetById]
	@BugId int 
AS
begin
	set nocount on;

	select [Id], [BugId], [Content]
	from [dbo].[Comment]
	where BugId = @BugId;
end
