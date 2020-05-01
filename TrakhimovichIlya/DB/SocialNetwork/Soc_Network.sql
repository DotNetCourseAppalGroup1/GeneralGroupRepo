CREATE DATABASE Soc_Network;
GO

USE Soc_Network;
GO

CREATE TABLE Users
(Id INT IDENTITY(1,1),
Name NVARCHAR(15) NOT NULL,
Age TINYINT NOT NULL,
CONSTRAINT PK_Users_Id PRIMARY KEY (Id),
CONSTRAINT CK_Users_Age CHECK(Age > 10)
)
GO

CREATE TABLE Photos
(
Id INT IDENTITY(1,1),
Name NVARCHAR(20) NOT NULL,
UserId INT NOT NULL,
CONSTRAINT PK_Photos_Id PRIMARY KEY (Id),
CONSTRAINT FK_Photos_To_Users FOREIGN KEY (UserId) REFERENCES Users (Id)
)
GO

CREATE TABLE Comments
(
Id INT IDENTITY(1,1) NOT NULL,
[Text] NVARCHAR(100) NOT NULL,
UserId INT NOT NULL,
PhotoId INT NOT NULL,
CONSTRAINT PK_Comments_Id PRIMARY KEY (Id),
CONSTRAINT FK_Comments_To_Users FOREIGN KEY (UserId) REFERENCES Users (Id) ON DELETE CASCADE,
CONSTRAINT FK_Comments_To_Photos FOREIGN KEY (PhotoId) REFERENCES Photos (Id) ON DELETE CASCADE
)
GO

CREATE PROC AddUser
 @name NVARCHAR(15), 
 @age TINYINT
AS
INSERT INTO Users 
VALUES (@name, @age)
GO

CREATE PROC AddComment
 @text NVARCHAR(100),
 @user_id INT,
 @photo_id INT
 AS
IF (SELECT COUNT(*) FROM Users WHERE Id = @user_id) = 1 /* check if user exists */
	BEGIN
		IF (SELECT COUNT(*) FROM Photos WHERE Id = @photo_id) = 1 /* check if photo exists */
			Begin
				INSERT INTO Comments
				VALUES(@text, @user_id, @photo_id)
			END
		ELSE
			PRINT 'Photo dont exist'
	END
ELSE
PRINT 'User dont exist'
GO

CREATE TABLE Likes_Photos
(
UserId INT NOT NULL,
PhotoId INT NOT NULL,
CONSTRAINT PK_Likes_Photos_LikeId_PhotoId PRIMARY KEY (UserId, PhotoId)
)
GO

ALTER TABLE Likes_Photos
ADD CONSTRAINT FK_Likes_Photos_To_Users FOREIGN KEY (UserId) REFERENCES Users (Id)
GO

ALTER TABLE Likes_Photos
ADD CONSTRAINT FK_Likes_Photos_To_Photos FOREIGN KEY (PhotoId) REFERENCES Photos (Id)
GO

CREATE TABLE Likes_Comments
(
UserId INT NOT NULL,
CommentId INT NOT NULL,
CONSTRAINT PK_Likes_Comments_UserId_CommentId PRIMARY KEY (UserId, CommentID),
CONSTRAINT FK_Likes_Comments_To_Users FOREIGN KEY (UserId) REFERENCES Users (Id),
CONSTRAINT FK_Likes_Comments_To_Comments FOREIGN KEY (CommentId) REFERENCES Comments (Id)
)
GO

/* like the photo */
CREATE PROC Like_Photo
@user_id INT,
@photo_id INT
AS
IF (SELECT COUNT(*) FROM Users WHERE Id = @user_id) = 1 /* check if user exists */
	BEGIN
		IF (SELECT COUNT(*) FROM Photos WHERE Id = @photo_id) = 1 /* check if photo exists */
			BEGIN
				IF (SELECT COUNT(*) FROM Likes_Photos WHERE UserId = @user_id AND PhotoId = @photo_id) = 0 /* check if like photo dont exists */
					BEGIN
						INSERT INTO Likes_Photos
						VALUES (@user_id, @photo_id)
					END
				ELSE PRINT 'This phtoto has a like from this user'
			END
		ELSE PRINT 'Photo dont exist'
	END
ELSE PRINT 'User dont exist'
GO

/* like the comment */
CREATE PROC Like_Comment
@user_id INT,
@coment_id INT
AS
IF (SELECT COUNT(*) FROM Users WHERE Id = @user_id) = 1 /* check if user exists */
	BEGIN
		IF (SELECT COUNT(*) FROM Comments WHERE Id = @coment_id) = 1 /* check if comment exists */
			BEGIN
				IF (SELECT COUNT(*) FROM Likes_Comments WHERE UserId = @user_id AND CommentId = @coment_id) = 0 /* check if like photo dont exists */
					BEGIN
						INSERT INTO Likes_Comments
						VALUES (@user_id, @coment_id)
					END
				ELSE PRINT 'This comment has a like from this user'
			END
		ELSE PRINT 'Comment dont exist'
	END
ELSE PRINT 'User dont exist'
GO

/* total number of comments for each user */
CREATE VIEW TotalUserComment
AS SELECT u.Name, COUNT(c.UserId) as total_comments 
FROM Users u
LEFT JOIN Comments AS c ON c.UserId = u.Id
GROUP BY u.Name
GO

/* photos that the user liked */
CREATE VIEW LikedPhotos ([User], Photo)
AS SELECT
u.Name + ' like photo: ', p.Name
FROM Users u
JOIN Likes_Photos AS lp ON lp.UserId = u.Id
JOIN Photos AS p ON p.Id = lp.PhotoId
GO

/* Total number likes of the photo */
CREATE VIEW TotalPhotoLike
AS SELECT 
p.Name Photo_Name, count(*) total_likes
FROM Photos p
JOIN Likes_Photos AS lp ON p.Id = lp.PhotoId
group by p.Name
GO

/* Doesnt work :( */
CREATE VIEW UserActivity (UserId, [User], Total_comments_from_user, total_likes_comment, total_likes_photo)
AS SELECT
u.Id, u.Name, COUNT(c.UserId), COUNT(lp.UserId), COUNT(lp.UserId)
FROM Users u
LEFT JOIN Comments c ON c.UserId = u.Id
LEFT JOIN Likes_Comments lc on lc.UserId = u.Id
LEFT JOIN Likes_Photos lp ON lp.UserId = u.Id
GROUP BY u.Id, u.Name
GO

/* UserActivity separately */
/*1 - total likes on comments by the user */
select Users.Id, Users.Name, COUNT(*) as total_likes
from Users
join Likes_Comments on users.Id = Likes_Comments.UserId
group by Users.Id, Users.Name

/*2 - total comments by the user */
select u.Id, u.Name, count(*) as total_comments
from users u
join Comments c on u.Id = c.UserId
group by u.Name, u.Id

/*3 - total likes on photos by the user */
select u.id, u.Name, count(*) as total_likes
from Users u
join Likes_Photos lp On lp.UserId = u.Id
group by u.id, u.Name

