CREATE TABLE [dbo].[Bug]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProjectId] INT NOT NULL, 
    [CategoryId] INT NOT NULL, 
    [PriorityId] INT NOT NULL, 
    [StatusId] INT NOT NULL DEFAULT 1, 
    [Topic] NVARCHAR(200) NOT NULL, 
    [Description] TEXT NOT NULL, 
    [FrequencyId] INT NOT NULL,
    [AssignedUserId] NVARCHAR(128) NULL, 
    [CreatedDate] DATETIME2 NOT NULL, 
    [LastModificationDate] DATETIME2 NULL DEFAULT getdate(), 
    CONSTRAINT [FK_Bug_ToProject] FOREIGN KEY ([ProjectId]) REFERENCES [Project]([Id]), 
    CONSTRAINT [FK_Bug_ToCategory] FOREIGN KEY ([CategoryId]) REFERENCES [Category]([Id]), 
    CONSTRAINT [FK_Bug_ToPriority] FOREIGN KEY ([PriorityId]) REFERENCES [Priority]([Id]), 
    CONSTRAINT [FK_Bug_ToStatus] FOREIGN KEY ([StatusId]) REFERENCES [Status]([Id]), 
    CONSTRAINT [FK_Bug_ToFrequency] FOREIGN KEY ([FrequencyId]) REFERENCES [Frequency]([Id]), 
    CONSTRAINT [FK_Bug_ToUser] FOREIGN KEY ([AssignedUserId]) REFERENCES [User]([Id])
)
