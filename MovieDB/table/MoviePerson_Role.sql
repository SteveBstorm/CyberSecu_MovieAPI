﻿CREATE TABLE [dbo].[MoviePerson_Role]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	IdPerson INT,
	IdMovie INT,
	Role VARCHAR(100) NOT NULL
)