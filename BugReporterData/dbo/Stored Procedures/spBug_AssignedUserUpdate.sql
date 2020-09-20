CREATE PROCEDURE [dbo].[spBug_AssignedUserUpdate]
	@BugId int,
	@UserId nvarchar(128)
AS
begin
	set nocount on;

	update dbo.Bug
	set AssignedUserId = @UserId, LastModificationDate = GETDATE()
	where Id = @BugId;

end
