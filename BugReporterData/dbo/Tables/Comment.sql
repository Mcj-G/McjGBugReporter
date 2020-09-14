CREATE TABLE [dbo].[Comment]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [BugId] INT NOT NULL, 
    [Content] TEXT NOT NULL, 
    CONSTRAINT [FK_Comment_ToBug] FOREIGN KEY ([BugId]) REFERENCES [Bug]([Id])
)
