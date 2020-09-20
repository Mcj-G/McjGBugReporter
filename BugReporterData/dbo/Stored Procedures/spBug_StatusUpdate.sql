CREATE PROCEDURE [dbo].[spBug_StatusUpdate]
	@BugId int,
	@NewStatusId int
AS
begin
	set nocount on;

	update dbo.Bug
	set StatusId = @NewStatusId, LastModificationDate = GETDATE()
	where Id = @BugId;

end
