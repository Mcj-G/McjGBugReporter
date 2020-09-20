CREATE PROCEDURE [dbo].[spComment_Insert]
	@Id int output,
	@BugId int,
	@Content text
AS
begin
	set nocount on;

	insert into dbo.Comment(BugId, Content)
	values (@BugId, @Content);

	select @Id = SCOPE_IDENTITY();

	update dbo.Bug
	set LastModificationDate = GETDATE()
	where Id = @BugId;
end
