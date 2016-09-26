CREATE TABLE [dbo].[ContactsPhones]
(
	[Id] INT IDENTITY (1, 1) NOT NULL, 
    [ContactId] INT NOT NULL, 
	[Type] NVARCHAR(50) NULL, 
    [Phone] NVARCHAR(50) NULL, 
    CONSTRAINT [PK_ContactsPhones] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_ContactsPhones_ToContacts] FOREIGN KEY ([ContactId]) REFERENCES [Contacts]([Id]) ON DELETE CASCADE
)

GO

CREATE INDEX [IX_ContactsPhones_ContactId] ON [dbo].[ContactsPhones] ([ContactId])