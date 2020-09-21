CREATE PROCEDURE [dbo].[spProject_Delete]
	@Id int
AS
begin
	set nocount on;

	delete from dbo.Project
	where Id = @Id;

end
