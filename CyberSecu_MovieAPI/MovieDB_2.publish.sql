CREATE DATABASE movieDb
GO
USE movieDB
GO


GO
CREATE TABLE [dbo].[Comments] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Content]  VARCHAR (MAX) NOT NULL,
    [PostDate] DATETIME2 (7) NOT NULL,
    [IdUser]   INT           NULL,
    [IdMovie]  INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Création de Table [dbo].[Genre]...';


GO
CREATE TABLE [dbo].[Genre] (
    [Id]    INT          IDENTITY (1, 1) NOT NULL,
    [Label] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Création de Table [dbo].[Movie]...';


GO
CREATE TABLE [dbo].[Movie] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Title]        VARCHAR (150) NOT NULL,
    [Synopsis]     VARCHAR (MAX) NOT NULL,
    [ReleaseYear]  INT           NOT NULL,
    [IdGenre]      INT           NULL,
    [IdRealisator] INT           NULL,
    [IdScenarist]  INT           NULL,
    [UrlPoster]    VARCHAR (500) NULL,
    [UrlTrailer]   VARCHAR (500) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Création de Table [dbo].[MoviePerson_Role]...';


GO
CREATE TABLE [dbo].[MoviePerson_Role] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [IdPerson] INT           NULL,
    [IdMovie]  INT           NULL,
    [Role]     VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Création de Table [dbo].[Person]...';


GO
CREATE TABLE [dbo].[Person] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Lastname]  VARCHAR (50)  NOT NULL,
    [Firstname] VARCHAR (50)  NOT NULL,
    [ImageUrl]  VARCHAR (400) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Création de Table [dbo].[Role]...';


GO
CREATE TABLE [dbo].[Role] (
    [Id]    INT          IDENTITY (1, 1) NOT NULL,
    [Label] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Création de Table [dbo].[Users]...';


GO
CREATE TABLE [dbo].[Users] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Nickname] VARCHAR (50)  NOT NULL,
    [Email]    VARCHAR (100) NOT NULL,
    [HashPWD]  VARCHAR (250) NOT NULL,
    [RoleId]   INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Création de Contrainte par défaut contrainte sans nom sur [dbo].[Users]...';


GO
ALTER TABLE [dbo].[Users]
    ADD DEFAULT 1 FOR [RoleId];


GO
PRINT N'Création de Clé étrangère [dbo].[FK_User]...';


GO
ALTER TABLE [dbo].[Comments]
    ADD CONSTRAINT [FK_User] FOREIGN KEY ([IdUser]) REFERENCES [dbo].[Users] ([Id]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_Movie]...';


GO
ALTER TABLE [dbo].[Comments]
    ADD CONSTRAINT [FK_Movie] FOREIGN KEY ([IdMovie]) REFERENCES [dbo].[Movie] ([Id]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_Real]...';


GO
ALTER TABLE [dbo].[Movie]
    ADD CONSTRAINT [FK_Real] FOREIGN KEY ([IdRealisator]) REFERENCES [dbo].[Person] ([Id]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_Scenarist]...';


GO
ALTER TABLE [dbo].[Movie]
    ADD CONSTRAINT [FK_Scenarist] FOREIGN KEY ([IdScenarist]) REFERENCES [dbo].[Person] ([Id]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_Genre]...';


GO
ALTER TABLE [dbo].[Movie]
    ADD CONSTRAINT [FK_Genre] FOREIGN KEY ([IdGenre]) REFERENCES [dbo].[Genre] ([Id]);


GO
-- Étape de refactorisation pour mettre à jour le serveur cible avec des journaux de transactions déployés

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'a7ebf12d-42f8-49d5-a731-1234674f4ab1')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('a7ebf12d-42f8-49d5-a731-1234674f4ab1')

GO

GO
/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO Genre (Label) VALUES ('Comedie')
INSERT INTO Genre (Label) VALUES ('Science-Fiction')
INSERT INTO Genre (Label) VALUES ('Horreur')
INSERT INTO Genre (Label) VALUES ('Action')

INSERT INTO Role VALUES ('User'), ('Modo'), ('Admin')

INSERT INTO Users (Nickname, Email, HashPWD, RoleId) VALUES ('Steve', 'steve@mail.com', 'test1234', 3)

INSERT INTO Person (Lastname, Firstname, ImageUrl) VALUES
    ('Astier', 'Alexandre', 'https://www.raindogprod.com/wp-content/uploads/2019/06/Vignette_Alexandre-Astier-DSC_0483-rt.jpg')

INSERT INTO Movie (Title, ReleaseYear, Synopsis, IdGenre, IdRealisator, IdScenarist)
    VALUES ('Kaamelott', '2021', 'Une bande d''abruti qui se met sur la gueule pour un vase', 1, 1, 1)

INSERT INTO Comments (Content, PostDate, IdMovie, IdUser) 
    VALUES ('J''ai connu pire', '2023-09-05', 1, 1)
GO

GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Mise à jour terminée.';


GO
