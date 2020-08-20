CREATE TABLE [dbo].[Bug]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProjectId] INT NOT NULL, 
    [CategoryId] INT NOT NULL, 
    [PriorityId] INT NOT NULL, 
    [StatusId] INT NOT NULL, 
    [Topic] NVARCHAR(200) NOT NULL, 
    [Description] TEXT NOT NULL, 
    [FrequencyId] INT NOT NULL, 
    [Visibility] BIT NOT NULL DEFAULT 1, 
    [AssignedUserId] NVARCHAR(128) NULL, 
    [CreatedDate] DATETIME2 NOT NULL, 
    [LastModificationDate] DATETIME2 NULL
)
