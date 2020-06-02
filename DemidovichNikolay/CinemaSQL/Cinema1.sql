USE Movies
DROP DATABASE Cinema
CREATE DATABASE Cinema
USE Cinema 

DROP TABLE Film

CREATE TABLE Film
(
[titleFilm] NVARCHAR(50) UNIQUE NOT NULL,
[ageLimit] CHAR(3) NOT NULL,
[genre] NVARCHAR(50) NOT NULL,
[duration] TIME(0) NOT NULL,
[language] CHAR(3) NOT NULL,
PRIMARY KEY (titleFilm)
);

CREATE TABLE Hall
(
[titleHall] NVARCHAR(50) UNIQUE,
[seatsCount] INT,
[price] MONEY,
PRIMARY KEY (titleHall)
);

CREATE TABLE TimeTable
(
[titleFilm] NVARCHAR(50),
[titleHall] NVARCHAR(50),
[timeToStart] TIME(0),
PRIMARY KEY (titleFilm, titleHall, timeToStart),
FOREIGN KEY (titleFilm) REFERENCES Film (titleFilm),
FOREIGN KEY (titleHall) REFERENCES Hall (titleHall),
);

DROP TABLE TimeTable

CREATE TABLE BoxOffice
(
[titleFilm] NVARCHAR(50),
[titleHall] NVARCHAR(50),
[timeToStart] TIME(0),
[seatNumber] int,
PRIMARY KEY (titleFilm, titleHall, timeToStart, seatNumber),
FOREIGN KEY (titleFilm, titleHall, timeToStart) REFERENCES TimeTable (titleFilm, titleHall, timeToStart)
);

DROP TABLE BoxOffice

INSERT Film VALUES ('������� ����','16+','�������/�����','02:20','RUS');
INSERT Film VALUES ('�� �� ������','16+','�������/�����','01:35','RUS');
INSERT Film VALUES ('������� ������','16+','�������/�����/�������','02:00','RUS');
INSERT Film VALUES ('������������','18+','���������������/�����','01:59','RUS');

DELETE Film 
WHERE genre = '/���������������/�����'

INSERT Hall VALUES ('Small', 30, 24);
INSERT Hall VALUES ('Large', 60, 10);
INSERT Hall VALUES ('VIP', 20, 30);

INSERT TimeTable VALUES ('������� ����', 'Small', '12:10');
INSERT TimeTable VALUES ('�� �� ������', 'Large', '12:20');
INSERT TimeTable VALUES ('������� ������', 'Small', '15:00');
INSERT TimeTable VALUES ('������������', 'Large', '14:25');
INSERT TimeTable VALUES ('������� ����', 'Small', '17:25');
INSERT TimeTable VALUES ('�� �� ������', 'Large', '17:00');
INSERT TimeTable VALUES ('������������', 'Small', '20:15');
INSERT TimeTable VALUES ('������� ������', 'Large', '19:05');
INSERT TimeTable VALUES ('������� ������', 'VIP', '19:30');
INSERT TimeTable VALUES ('�� �� ������', 'Small', '22:45');
INSERT TimeTable VALUES ('������������', 'Large', '21:30');
INSERT TimeTable VALUES ('������� ����', 'VIP', '22:00');

INSERT BoxOffice VALUES ('������� ����', 'VIP', '22:00', 4);
INSERT BoxOffice VALUES ('������� ����', 'VIP', '22:00', 3);
INSERT BoxOffice VALUES ('������� ����', 'VIP', '22:00', 2);
INSERT BoxOffice VALUES ('������� ����', 'VIP', '22:00', 14);
INSERT BoxOffice VALUES ('������� ����', 'VIP', '22:00', 1);
INSERT BoxOffice VALUES ('������� ����', 'VIP', '22:00', 15);
INSERT BoxOffice VALUES ('������� ����', 'VIP', '22:00', 16);
INSERT BoxOffice VALUES ('������� ����', 'VIP', '22:00', 5);
INSERT BoxOffice VALUES ('������� ����', 'VIP', '22:00', 8);
INSERT BoxOffice VALUES ('������� ����', 'VIP', '22:00', 13);
INSERT BoxOffice VALUES ('������� ����', 'VIP', '22:00', 12);
INSERT BoxOffice VALUES ('������� ����', 'VIP', '22:00', 11);
INSERT BoxOffice VALUES ('������� ����', 'VIP', '22:00', 10);
INSERT BoxOffice VALUES ('������� ����', 'VIP', '22:00', 17);
INSERT BoxOffice VALUES ('������� ����', 'VIP', '22:00', 18);
INSERT BoxOffice VALUES ('������� ����', 'VIP', '22:00', 19);
INSERT BoxOffice VALUES ('������� ����', 'VIP', '22:00', 20);
INSERT BoxOffice VALUES ('������� ����', 'VIP', '22:00', 6);
INSERT BoxOffice VALUES ('������� ����', 'VIP', '22:00', 7);
INSERT BoxOffice VALUES ('������� ����', 'VIP', '22:00', 9);

INSERT BoxOffice VALUES ('������� ������', 'VIP', '19:30', 4);
INSERT BoxOffice VALUES ('������� ������', 'VIP', '19:30', 3);
INSERT BoxOffice VALUES ('������� ������', 'VIP', '19:30', 2);
INSERT BoxOffice VALUES ('������� ������', 'VIP', '19:30', 14);
INSERT BoxOffice VALUES ('������� ������', 'VIP', '19:30', 1);
INSERT BoxOffice VALUES ('������� ������', 'VIP', '19:30', 15);
INSERT BoxOffice VALUES ('������� ������', 'VIP', '19:30', 16);
INSERT BoxOffice VALUES ('������� ������', 'VIP', '19:30', 5);
INSERT BoxOffice VALUES ('������� ������', 'VIP', '19:30', 8);
INSERT BoxOffice VALUES ('������� ������', 'VIP', '19:30', 13);
INSERT BoxOffice VALUES ('������� ������', 'VIP', '19:30', 12);
INSERT BoxOffice VALUES ('������� ������', 'VIP', '19:30', 11);
INSERT BoxOffice VALUES ('������� ������', 'VIP', '19:30', 10);
INSERT BoxOffice VALUES ('������� ������', 'VIP', '19:30', 17);
INSERT BoxOffice VALUES ('������� ������', 'VIP', '19:30', 18);
INSERT BoxOffice VALUES ('������� ������', 'VIP', '19:30', 19);
INSERT BoxOffice VALUES ('������� ������', 'VIP', '19:30', 20);
INSERT BoxOffice VALUES ('������� ������', 'VIP', '19:30', 6);
INSERT BoxOffice VALUES ('������� ������', 'VIP', '19:30', 7);
INSERT BoxOffice VALUES ('������� ������', 'VIP', '19:30', 9);

SELECT * FROM Film, Hall, TimeTable
WHERE Film.ageLimit = '18+'

SELECT TimeTable.titleFilm, Film.duration, Film.ageLimit, TimeTable.titleHall, Film.language, TimeTable.timeToStart
FROM TimeTable
JOIN Film ON Film.titleFilm = TimeTable.titleFilm