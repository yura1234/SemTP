CREATE TABLE [dbo].[TourTable]
(
	[Id_tour] INT NOT NULL IDENTITY(1,1),
	[City] NCHAR(50) NOT NULL,
	[DateTourStart] DATE NOT NULL,
	[DateTourEnd] DATE NOT NULL,
	[Price] INT NOT NULL,
	PRIMARY KEY (Id_tour)

);

CREATE TABLE [dbo].[TouristTable]
(
	[Id_tourist] INT NOT NULL IDENTITY(1,1),
	[Name] NCHAR(30) NOT NULL,
	[SecondName] NCHAR(30) NOT NULL,
	[ThirdName] NCHAR(30) NOT NULL,
	[Passport] NCHAR(100) NOT NULL,
	[CreditCard] NCHAR(40) NOT NULL,
	PRIMARY KEY (Id_tourist)

);

CREATE TABLE [dbo].[CardTable]
(
	[Id_card] INT NOT NULL IDENTITY(1,1),
	[Id_Tour] INT NOT NULL,
	[Id_Tourist] INT NOT NULL,
	FOREIGN KEY (Id_Tour) REFERENCES TourTable (Id_tour),
	FOREIGN KEY (Id_Tourist) REFERENCES TouristTable (Id_tourist),
	PRIMARY KEY (Id_card)

);