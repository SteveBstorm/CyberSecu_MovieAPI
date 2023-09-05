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