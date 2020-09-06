CREATE PROCEDURE [dbo].[spBug_GetAll]
	
AS
begin
	set nocount on;

	select [bug].[Id], 
		[proj].[Name] as [ProjectName], 
		[proj].[Version] as [ProjectVersion],
		[cat].[Name] as [CategoryName], 
		[pr].[Name] as [PriorityName],
		[st].[Name] as [StatusName], 
		[bug].[Topic], 
		[bug].[Description],
		[fr].[Name] as [FrequencyName], 
		[u].[EmailAddress] as [AssignedUserMail], 
		[bug].[CreatedDate], 
		[bug].[LastModificationDate]
	from (((((([dbo].[Bug] as [bug]
	full outer join [dbo].[User] as [u] on [bug].[AssignedUserId] = [u].[Id])
	inner join [dbo].[Status] as [st] on [bug].[StatusId] = [st].[Id])
	inner join [dbo].[Priority] as [pr] on [bug].[PriorityId] = [pr].[Id])
	inner join [dbo].[Frequency] as [fr] on [bug].[FrequencyId] = [fr].[Id])
	inner join [dbo].[Category] as [cat] on [bug].[CategoryId] = [cat].[Id])
	inner join [dbo].[Project] as [proj] on [bug].[ProjectId] = [proj].[Id]);

end
