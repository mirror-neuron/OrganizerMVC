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