﻿CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	Nickname VARCHAR(50) NOT NULL,
	Email VARCHAR(100) NOT NULL,
	HashPWD VARCHAR(250) NOT NULL,
	RoleId INT DEFAULT 1
)
