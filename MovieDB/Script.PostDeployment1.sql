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

INSERT INTO Users (Nickname, Email, HashPWD, RoleId) VALUES 
    ('Steve', 'steve@mail.com', 'test1234', 3),
    ('Loic', 'loic@mail.com', 'test1234', 1)

INSERT INTO Person (Lastname, Firstname, ImageUrl) VALUES
    ('Astier', 'Alexandre', 'https://www.raindogprod.com/wp-content/uploads/2019/06/Vignette_Alexandre-Astier-DSC_0483-rt.jpg'),
    ('Pitiot', 'Franck', 'https://kifim.b-cdn.net/people/large/1851113.jpg'),
    ('Astier','Lionel','https://photo.astalents.net/media/m/840/84066/la1_550_550.jpg'),
    ('Ford','Harison','https://upload.wikimedia.org/wikipedia/commons/3/34/Harrison_Ford_by_Gage_Skidmore_3.jpg'),
    ('Lucas','Georges','https://m.media-amazon.com/images/M/MV5BMTA0Mjc0NzExNzBeQTJeQWpwZ15BbWU3MDEzMzQ3MDI@._V1_FMjpg_UX1000_.jpg') 


INSERT INTO Movie (Title, ReleaseYear, Synopsis, IdGenre, IdRealisator, IdScenarist, UrlPoster, UrlTrailer)
    VALUES ('Kaamelott', '2021', 'Une bande d''abruti qui se met sur la gueule pour un vase', 1, 1, 1, 'https://i.ebayimg.com/images/g/i7QAAOSw6YxjuZeJ/s-l1200.jpg', 'https://www.youtube.com/watch?v=j7RrsdP-WuM'),
    ('Star wars : A new hope', '1977', 'Ca sert a grand chose d''expliquer ou tout le monde connait ?', 2, 5, 5, 'https://cdn.kobo.com/book-images/ea6a1631-34e8-4369-b777-cf342521d3e0/1200/1200/False/a-new-hope-star-wars-episode-iv.jpg', 'https://www.youtube.com/watch?v=vZ734NWnAHA')

INSERT INTO Comments (Content, PostDate, IdMovie, IdUser) 
    VALUES ('J''ai connu pire', '2023-09-05', 1, 1)

INSERT INTO MoviePerson_Role (IdMovie, IdPerson, Role) VALUES
    (1, 1, 'Arthur Pendragon'),
    (1, 2, 'Perceval de Galles'),
    (1, 3, 'Léodagan de Carmélide'),
    (2, 4, 'Han Solo')