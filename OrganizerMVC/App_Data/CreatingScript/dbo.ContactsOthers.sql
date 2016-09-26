CREATE TABLE [dbo].[ContactsOthers]
(
	[Id] INT IDENTITY (1, 1) NOT NULL, 
    [ContactId] INT NOT NULL, 
    [Other] NVARCHAR(500) NULL, 
    CONSTRAINT [PK_ContactsOthers] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_ContactsOthers_ToContacts] FOREIGN KEY ([ContactId]) REFERENCES [Contacts]([Id]) ON DELETE CASCADE
)

GO

CREATE INDEX [IX_ContactsOthers_ContactId] ON [dbo].[ContactsOthers] ([ContactId])
