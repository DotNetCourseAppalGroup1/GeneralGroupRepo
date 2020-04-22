IF DB_ID('CinemaDB') is NULL
BEGIN
	CREATE DATABASE CinemaDB
	PRINT('DB Created')
END
ELSE
	PRINT('DB Already exists')
GO
USE CinemaDB

IF OBJECT_ID('Films') is NULL
BEGIN
	CREATE TABLE Films
	(
		Id INT IDENTITY,
		[Name] NVARCHAR(40) NOT NULL,
		DefaultPrice REAL NOT NULL,

		CONSTRAINT PK_FILMS_ID PRIMARY KEY (Id)
	)

	INSERT INTO Films ([Name], DefaultPrice)
		VALUES('Marvel',10)
	INSERT INTO Films ([Name], DefaultPrice)
		VALUES('DC',20)
	INSERT INTO Films ([Name], DefaultPrice)
		VALUES('Avengers6', 17)
	INSERT INTO Films ([Name], DefaultPrice)
		VALUES('Marvel5',100)
	INSERT INTO Films ([Name], DefaultPrice)
		VALUES('DC',200)
	INSERT INTO Films ([Name], DefaultPrice)
		VALUES('Avengers6', 10)
	INSERT INTO Films ([Name], DefaultPrice)
		VALUES('Marvel3',14)
	INSERT INTO Films ([Name], DefaultPrice)
		VALUES('DC',20)
	INSERT INTO Films ([Name], DefaultPrice)
		VALUES('Avengers2', 15)
	INSERT INTO Films ([Name], DefaultPrice)
		VALUES('Marvel',10)
	INSERT INTO Films ([Name], DefaultPrice)
		VALUES('DC',20)
	INSERT INTO Films ([Name], DefaultPrice)
		VALUES('Avengers6', 19)
	INSERT INTO Films ([Name], DefaultPrice)
		VALUES('Marvel',10)
	INSERT INTO Films ([Name], DefaultPrice)
		VALUES('DC4',20)
	INSERT INTO Films ([Name], DefaultPrice)
		VALUES('Avengers', 15)
	INSERT INTO Films ([Name], DefaultPrice)
		VALUES('Marvel5',10)
	INSERT INTO Films ([Name], DefaultPrice)
		VALUES('DC',20)
	INSERT INTO Films ([Name], DefaultPrice)
		VALUES('Avengers', 15)
END

IF OBJECT_ID('DaysCoefficients') is NULL
BEGIN
	CREATE TABLE DaysCoefficients
	(
		Id INT IDENTITY NOT NULL,
		[Day] NVARCHAR(30) NOT NULL,
		Coefficient FLOAT NOT NULL,

		CONSTRAINT PK_DAYS_COEFFICIENTS_ID PRIMARY KEY (Id)
	)

	INSERT INTO DaysCoefficients([Day],Coefficient)
		VALUES('Monday',1.5)
	INSERT INTO DaysCoefficients([Day],Coefficient)
		VALUES('Tuesday',2)
	INSERT INTO DaysCoefficients([Day],Coefficient)
		VALUES('Sunday',1)
END

IF OBJECT_ID('TimeCoefficient') is NULL
BEGIN
	CREATE TABLE TimeCoefficient
	(
		IntervalBegin INT NOT NULL,
		IntervalEnd INT NOT NULL,
		Coefficient FLOAT NOT NULL
	)

	INSERT INTO TimeCoefficient (IntervalBegin, IntervalEnd, Coefficient)
		VALUES(12,23,1.5);
	INSERT INTO TimeCoefficient (IntervalBegin, IntervalEnd, Coefficient)
		VALUES(1,11, 2);
END

IF OBJECT_ID('Tickets') is NULL
BEGIN
	CREATE TABLE Tickets
	(
		Id INT IDENTITY,
		TimeBegin INTEGER NOT NULL DEFAULT 1,
		DayId INT NOT NULL DEFAULT 1,
		TicketsPrice REAL NOT NULL DEFAULT 1,
		FilmId INTEGER NOT NULL DEFAULT 1,

		CONSTRAINT PK_TICKETS_ID PRIMARY KEY (Id),
		CONSTRAINT FK_TICKETS_FILM_ID FOREIGN KEY (FilmId) REFERENCES Films(Id) ON DELETE CASCADE,
		CONSTRAINT FK_TICKETS_DAY_ID FOREIGN KEY (DayId) REFERENCES DaysCoefficients(Id) ON DELETE CASCADE
	)

	INSERT INTO Tickets(DayId,FilmId,TimeBegin)
		VALUES(3,2,11)
	INSERT INTO Tickets(DayId,FilmId,TimeBegin)
		VALUES(1,1,17)
	INSERT INTO Tickets(DayId,FilmId,TimeBegin)
		VALUES(2,1,19)
	INSERT INTO Tickets(DayId,FilmId,TimeBegin)
		VALUES(2,3,4)
END

SELECT 
	TicketsPrice*Films.DefaultPrice*DaysCoefficients.Coefficient as TotalPrice,
	TimeBegin,
	Films.[Name] AS FilmName,
	DaysCoefficients.[Day] AS FilmDate
FROM Tickets 
	JOIN Films ON Films.Id = Tickets.FilmId
	JOIN DaysCoefficients on DaysCoefficients.Id = Tickets.DayId
