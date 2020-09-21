CREATE PROCEDURE [dbo].[spProject_Update]
	@Id int,
	@Name nvarchar(100),
	@Version nvarchar(20)
AS
begin
	set nocount on;

	update dbo.Project
	set [Name] = @Name, [Version] = @Version
	where Id = @Id;

end
