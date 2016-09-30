CREATE TABLE [dbo].[Contacts]
(
	[Id] INT IDENTITY (1, 1) NOT NULL, 
    [Surname] NVARCHAR(50) NOT NULL, 
    [Name] NVARCHAR(50) NULL, 
	[Patronymic] NVARCHAR(50) NULL, 
    [Birthday] DATE NULL, 
    [Organization] NVARCHAR(50) NULL, 
    [Position] NVARCHAR(50) NULL, 
    CONSTRAINT [PK_Contacts] PRIMARY KEY ([ID])
)

GO

CREATE INDEX [IX_Contacts_Surname] ON [dbo].[Contacts] ([Surname])

GO

CREATE INDEX [IX_Contacts_Name] ON [dbo].[Contacts] ([Name])

GO

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

GO

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

GO

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

GO

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