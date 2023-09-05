CREATE TABLE [dbo].[Movie]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	Title VARCHAR(150) NOT NULL,
	Synopsis VARCHAR(MAX) NOT NULL,
	ReleaseYear INT NOT NULL,
	IdGenre INT,
	IdRealisator INT,
	IdScenarist INT
	CONSTRAINT FK_Real FOREIGN KEY (IdRealisator) REFERENCES Person(Id),
	[UrlPoster] VARCHAR(500) NULL, 
    [UrlTrailer] VARCHAR(500) NULL, 
    CONSTRAINT FK_Scenarist FOREIGN KEY (IdScenarist) REFERENCES Person(Id),
	CONSTRAINT FK_Genre FOREIGN KEY (IdGenre) REFERENCES Genre(Id)


)
