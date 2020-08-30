CREATE PROCEDURE [dbo].[spBug_Insert]
	@Id int output,
	@ProjectId int,
	@CategoryId int,
	@PriorityId int,
	@Topic nvarchar(200),
	@Description text,
	@FrequencyId int,
	@CreatedDate datetime2
AS
begin
	set nocount on;

	insert into dbo.Bug ([ProjectId], [CategoryId], [PriorityId], [Topic], [Description], [FrequencyId], [CreatedDate])
	values (@ProjectId, @CategoryId, @PriorityId, @Topic, @Description, @FrequencyId, @CreatedDate);

	select @Id = SCOPE_IDENTITY();

end
