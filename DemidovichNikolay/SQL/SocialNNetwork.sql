CREATE DATABASE SocialNetwork
USE master
DROP DATABASE SocialNetwork
GO

USE SocialNetwork

DROP TABLE Users

CREATE TABLE Users
(
Id INT IDENTITY,
UserName NVARCHAR(50) NOT NULL DEFAULT ('Unknown'),
PRIMARY KEY (Id)
);

SELECT * FROM Users

DROP TABLE Photos

CREATE TABLE Photos
(
Id INT IDENTITY,
IdUsers INT,
PhotoDescription NVARCHAR(100),
PRIMARY KEY (Id), 
FOREIGN KEY (IdUsers) REFERENCES Users (Id)
);

SELECT * FROM Photos

DROP TABLE PhotoLikes

CREATE TABLE PhotoLikes
(
Id INT PRIMARY KEY IDENTITY,
IdPhotos INT  ,
IdWhoMakeLike INT,
FOREIGN KEY (IdPhotos) REFERENCES Photos (Id),
FOREIGN KEY (IdWhoMakeLike) REFERENCES Users(Id) 
);

SELECT * FROM PhotoLikes

DROP TABLE Comments

CREATE TABLE Comments
(
Id INT PRIMARY KEY IDENTITY(1,1),
IdPhotos INT NOT NULL,
CommentText NVARCHAR(50) NOT NULL,
IdWhoMakeComment INT NOT NULL,
FOREIGN KEY (IdPhotos) REFERENCES Photos (Id),
FOREIGN KEY (IdWhoMakeComment) REFERENCES Users (Id),
);

SELECT * FROM Comments 

DROP TABLE CommentLike

CREATE TABLE CommentLike
(
Id INT PRIMARY KEY IDENTITY,
IdComment INT NOT NULL,
IdWhoMakeLike INT NOT NULL
FOREIGN KEY (IdComment) REFERENCES Comments (Id),
FOREIGN KEY (IdWhoMakeLike) REFERENCES Users(Id)
);

SELECT * FROM CommentLike

INSERT INTO Users
VALUES 
('Mikali'),
('Vasja'),
('Olja'),
('Masha'),
('Veranika'),
('Vanja')

SELECT * FROM Users
ORDER BY UserName
OFFSET 5 ROWS

INSERT INTO Photos
VALUES
(2,'First photo by Vasja'),
(4,'First photo by Masha'),
(1,'First photo by Mikalai'),
(3,'First photo by Olja'),
(4,'Second photo by Masha'),
(4,'Third photo by Masha'),
(4,'Fourth photo by Masha'),
(6,'First photo by Vanja'),
(5,'First photo by Veranika'),
(2,'Second photo by Vasja')

SELECT * FROM Photos
ORDER BY PhotoDescription
OFFSET 2 ROWS
FETCH NEXT 3 ROWS ONLY;

INSERT INTO PhotoLikes
VALUES 
(2,1),
(3,1),
(4,2),
(5,1),
(5,2),
(6,3),
(2,3),
(4,1),
(5,3),
(5,4),
(5,5),
(5,6),
(6,5)

ALTER TABLE Comments
DROP COLUMN IdWhoMakeLike

INSERT INTO Comments
VALUES
(2,'It is amaizing, Where have you made this picture?',1),
(4,'Olja, you so buetiful, I love your smile ::))))?',2),
(4,'Thank you! It was Madrid, fiveyears ago)',4),
(2,'Kiss Kiss',4),
(6,'We should to meet!!!))',3),
(6,'Agree, I miss without you:((',4)

SELECT * FROM Comments 
WHERE IdWhoMakeComment = 4 OR IdPhotos = 6

INSERT INTO CommentLike
VALUES 
(1,4),
(2,5),
(3,1),
(4,2),
(5,3)

SELECT COUNT(*) FROM CommentLike 
WHERE IdPhotos = 2

DROP TABLE Statistic

CREATE TABLE Statistic
(
Id INT IDENTITY PRIMARY KEY,
UserId INT NOT NULL REFERENCES Users(Id) ON DELETE CASCADE,
PhotoId NVARCHAR(50) NOT NULL REFERENCES Photos(Id) ON DELETE CASCADE,
)

INSERT INTO Statistic 
VALUES 
(
(SELECT UserName FROM Users WHERE Id = 1),
(SELECT PhotoDescription FROM Photos WHERE IdUsers = 1)
)
DROP TABLE CommentLike
DROP TABLE Comments
DROP TABLE PhotoLikes
DROP TABLE Photos
DROP TABLE Users
