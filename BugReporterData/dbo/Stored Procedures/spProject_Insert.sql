CREATE PROCEDURE [dbo].[spProject_Insert]
	@Id int output,
	@Name nvarchar(100),
	@Version nvarchar(20)
AS
begin
	set nocount on;

	insert into dbo.Project([Name], [Version])
	values (@Name, @Version);

	select @Id = SCOPE_IDENTITY();

end
