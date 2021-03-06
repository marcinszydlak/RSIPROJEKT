﻿DROP TABLE RezerwacjeMiejsca;
DROP TABLE Rezerwacje;
DROP TABLE Seanse;
DROP TABLE Sale;
DROP TABLE Klienci;
DROP TABLE Filmy;
CREATE TABLE Filmy
(
	FilmID int IDENTITY(1,1) PRIMARY KEY,
	Tytul varchar(50) NOT NULL,
	Rezyser varchar(50) NOT NULL,
	RokWydania int NOT NULL,
	Obsada varchar(300) NOT NULL,
	Opis varchar(500) NOT NULL,
	Ocena decimal(12,2) NOT NULL,
	Zdjecie varbinary NULL
);
CREATE TABLE Klienci
(
	KlientID int IDENTITY(1,1) PRIMARY KEY, 
	Imie varchar(50) NOT NULL,
	Nazwisko varchar(50) NOT NULL,
	Login varchar(50) NOT NULL,
	Haslo varchar(50) NOT NULL
);
CREATE TABLE Sale
(
	SalaID int IDENTITY(1,1) PRIMARY KEY,
	IloscRzedow int NOT NULL,
	IloscMiejscWRzedzie int NOT NULL
);
CREATE TABLE Seanse
(
	SeansID int IDENTITY(1,1) PRIMARY KEY,
	FilmID int NOT NULL FOREIGN KEY REFERENCES Filmy(FilmID),
	DataSeansu datetime NOT NULL,
	SalaID int NOT NULL FOREIGN KEY REFERENCES Sale(SalaID)
);
CREATE TABLE Rezerwacje
(
	RezerwacjaID int IDENTITY(1,1) PRIMARY KEY,
	SeansID int NOT NULL FOREIGN KEY REFERENCES Seanse(SeansID) ,
	KlientID int NOT NULL FOREIGN KEY REFERENCES Klienci(KlientID),
	DataRezerwacji datetime NOT NULL
);
CREATE TABLE RezerwacjeMiejsca
(
	RezerwacjaMiejsceID int IDENTITY(1,1) PRIMARY KEY,
	RezerwacjaID int NOT NULL FOREIGN KEY REFERENCES Rezerwacje(RezerwacjaID),
	Rzad int NOT NULL,
	Miejsce int NOT NULL
);

INSERT INTO Filmy(Tytul,Rezyser,RokWydania,Obsada,Opis,Ocena) VALUES
('Rambo', 'Ted Kotcheff', 1982, 'Sylvester Stallone, Richard Crenna, Brian Dennehy, Jack Starrett, Bill McKenney','Dramat wojenny',7.36),
('Rambo II', 'George Pan Cosmatos', 1985, 'Sylvester Stallone, Richard Crenna, Charles Napier, Steven Berkoff','Dramat wojenny',7.49),
('Rambo III',' 	Peter MacDonald', 1988, 'Sylvester Stallone, Richard Crenna, Charles Napier, Marc de Jonge','Dramat sensacyjny',8.02),
('John Rambo','Sylvester Stallone',2008,'Sylvester Stallone, Julie Benz','Dramat sensacyjny',9.04);
INSERT INTO Klienci (Imie,Nazwisko,Login,Haslo) VALUES
('Adam','Adamski','AAdamski','AAA'),
('Bartosz','Bartoszewski','BBartoszewski','BBB'),
('Cezary','Czarkowski','CCzarkowski','CCC'),
('Damian','Damka','DDamka','DDD');
INSERT INTO Sale(IloscRzedow,IloscMiejscWRzedzie) VALUES
(12,18),(10,20),(16,24)
INSERT INTO Seanse(FilmID,DataSeansu,SalaID) VALUES
(1,GETDATE(),1),
(2,'20170529',1),
(3,'20170530',1),
(2,'20170530',2),
(3,'20170601',2),
(3,'20170602',3),
(1,'20170602',3),
(1,'20170603',3)
INSERT INTO Rezerwacje(SeansID,DataRezerwacji,KlientID) VALUES
(1,GETDATE(),1),
(1,GETDATE(),2),
(1,GETDATE(),3),
(1,GETDATE(),4),
(2,GETDATE(),1),
(2,GETDATE(),2),
(2,GETDATE(),3),
(2,GETDATE(),4),
(2,GETDATE(),1),
(3,GETDATE(),2),
(3,GETDATE(),3)
INSERT INTO RezerwacjeMiejsca(RezerwacjaID,Rzad,Miejsce) VALUES
(1,1,2),
(1,1,3),
(1,1,4),
(2,1,1),
(2,1,5),
(2,1,6),
(2,1,7),
(3,4,7),
(3,6,8),
(3,6,8),
(4,7,11),
(4,7,12)
