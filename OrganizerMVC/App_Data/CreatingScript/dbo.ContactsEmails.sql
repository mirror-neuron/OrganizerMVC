CREATE TABLE [dbo].[ContactsEmails]
(
	[Id] INT IDENTITY (1, 1) NOT NULL, 
    [ContactId] INT NOT NULL, 
    [Email] NVARCHAR(50) NULL, 
    CONSTRAINT [PK_ContactsEmails] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_ContactsEmails_ToContacts] FOREIGN KEY ([ContactId]) REFERENCES [Contacts]([Id]) ON DELETE CASCADE
)

GO

CREATE INDEX [IX_ContactsEmails_ContactId] ON [dbo].[ContactsEmails] ([ContactId])
