CREATE TABLE [dbo].[ContactsSkypes]
(
	[Id] INT IDENTITY (1, 1) NOT NULL, 
    [ContactId] INT NOT NULL, 
    [Skype] NVARCHAR(50) NULL, 
    CONSTRAINT [PK_ContactsSkypes] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_ContactsSkypes_ToContacts] FOREIGN KEY ([ContactId]) REFERENCES [Contacts]([Id]) ON DELETE CASCADE
)

GO

CREATE INDEX [IX_ContactsSkypes_ContactId] ON [dbo].[ContactsSkypes] ([ContactId])
