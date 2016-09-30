CREATE TABLE [dbo].[Events]
(
	[Id] INT IDENTITY (1, 1) NOT NULL,
	[Status] TINYINT NOT NULL,
    [Type] NVARCHAR(10) NOT NULL, 
    [Subject] NVARCHAR(512) NULL, 
    [StartDate] DATETIME NOT NULL, 
    [EndDate] DATETIME NULL, 
    [Place] NVARCHAR(256) NULL, 
    CONSTRAINT [PK_Events] PRIMARY KEY ([Id]) 
)
GO

CREATE INDEX [IX_Events_Type] ON [dbo].[Events] ([Type])

GO

CREATE INDEX [IX_Events_StartDate] ON [dbo].[Events] ([StartDate])

GO

CREATE INDEX [IX_Events_EndDate] ON [dbo].[Events] ([EndDate])
