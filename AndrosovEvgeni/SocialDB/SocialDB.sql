CREATE DATABASE SocialDB
GO
USE SocialDB

	CREATE TABLE Users
	(
		Id INT PRIMARY KEY IDENTITY,
		[Name] NVARCHAR(40) NOT NULL,
	)

	INSERT INTO Users ([Name])
		VALUES('Tom'),('Bob'),('Eugene'),('Andrey')

	CREATE TABLE Photos
	(
		Id INT PRIMARY KEY IDENTITY,
		PhotoDescription NVARCHAR(40) NOT NULL,
		UserId INT NOT NULL,

		FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE,
	)

	INSERT INTO Photos(UserId,PhotoDescription)
		VALUES (1,'Text'),(2,'MyPhoto'),(2,'My Second Photo'),(3,'My first photo')

		CREATE TABLE Comments
	(
		Id INT PRIMARY KEY IDENTITY,
		CommentText NVARCHAR(40) NOT NULL,
		UserId INT NOT NULL,
		PhotoId INT NOT NULL,

		FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE,
		FOREIGN KEY (PhotoId) REFERENCES Photos(Id)
	)

	INSERT INTO Comments(UserId,PhotoId,CommentText)
		VALUES(1,1,'Test comm'),(1,1,'Test'),(1,2,'Comment 2'),(2,2,'TestComm2')

GO
		CREATE TABLE PhotoLikes
	(
		Id INT PRIMARY KEY IDENTITY,
		PhotoId INT NOT NULL,
		UserId INT NOT NULL,

		FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE,
		FOREIGN KEY (PhotoId) REFERENCES Photos(Id)
	)

GO
		CREATE TABLE ProfileLikes
	(
		Id INT PRIMARY KEY IDENTITY,
		TargetId INT NOT NULL,
		UserId INT NOT NULL,

		FOREIGN KEY (TargetId) REFERENCES Users(Id) ON DELETE CASCADE,
	)

GO
		CREATE TABLE CommentLikes
	(
		Id INT PRIMARY KEY IDENTITY,
		CommentId INT NOT NULL,
		UserId INT NOT NULL,

		FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE,
		FOREIGN KEY (CommentId) REFERENCES Comments(Id) 
	)

GO
CREATE VIEW PhotosWithAuthor AS
SELECT 
Photos.Id,
		Photos.PhotoDescription AS PhotoDescription, 
        Users.[Name] AS Author
FROM Photos 
	JOIN Users ON Users.Id = Photos.UserId

GO 
CREATE VIEW PhotoWithCom AS
SELECT
	Comments.CommentText as Comment,
	Users.[Name] as CommentAuthor,
	PhotosWithAuthor.PhotoDescription,
	PhotosWithAuthor.Author
FROM
	Comments JOIN PhotosWithAuthor ON Comments.PhotoId = PhotosWithAuthor.Id
	JOIN Users ON Comments.UserId = Users.Id
GO

CREATE PROCEDURE AddComment
    @commentText NVARCHAR(20),
    @PhotoId INT,
    @AuthorName NVARCHAR(40) 
	AS
   IF EXISTS (SELECT * FROM Users WHERE Users.[Name] = @AuthorName) 
   AND EXISTS (SELECT * FROM Photos WHERE Photos.Id = @PhotoId) 
  	INSERT INTO Comments(UserId,PhotoId,CommentText)
		VALUES((SELECT Users.Id FROM Users WHERE Users.[Name] = @AuthorName),@PhotoId,@commentText)
	ELSE PRINT 'Error'

GO

CREATE PROCEDURE AddUser
	@userName NVARCHAR(40)
	AS
	IF NOT EXISTS (SELECT * FROM Users Where Users.[Name] = @userName)
	INSERT INTO Users([Name])
		VALUES(@userName)
	ELSE PRINT 'User already exists'

GO

CREATE PROCEDURE LikePhoto
	@photoId INT,
	@userName NVARCHAR(40)
	AS
	 	IF EXISTS (SELECT * FROM Users Where Users.[Name] = @userName)
		BEGIN
			IF EXISTS (SELECT * FROM Photos WHERE Photos.Id = @photoId)
			BEGIN
				IF (NOT EXISTS(SELECT PhotoLikes.PhotoId 
								FROM PhotoLikes 
									JOIN Users 
								ON PhotoLikes.UserId = Users.Id
								WHERE PhotoLikes.PhotoId=@photoId AND @userName = Users.[Name]))
					INSERT INTO PhotoLikes(PhotoId,UserId) 
						VALUES(@photoId,(SELECT Users.Id FROM Users WHERE Users.[Name] = @userName))
				ELSE 
				BEGIN
					PRINT('Лайк уже стоит')
					DELETE FROM PhotoLikes
							WHERE PhotoLikes.Id = (SELECT PhotoLikes.Id 
													FROM PhotoLikes
														JOIN Users
													ON PhotoLikes.UserId = Users.Id
													WHERE PhotoLikes.PhotoId=@photoId AND @userName = Users.[Name])
					PRINT('Лайк снят')
				END
			END
			ELSE PRINT('Фото с таким id нет')
		END
		ELSE PRINT('Такого пользователя нет')

GO

CREATE PROCEDURE LikeComment
	@commentId INT,
	@userName NVARCHAR(40)
	AS
	 	IF EXISTS (SELECT * FROM Users Where Users.[Name] = @userName)
		BEGIN
			IF EXISTS (SELECT * FROM Comments WHERE Comments.Id = @commentId)
			BEGIN
				IF (NOT EXISTS(SELECT CommentId 
								FROM CommentLikes 
									JOIN Users 
								ON CommentLikes.UserId = Users.Id
								WHERE CommentLikes.CommentId=@commentId AND @userName = Users.[Name]))
					INSERT INTO CommentLikes(CommentId,UserId) 
						VALUES(@commentId,(SELECT Users.Id FROM Users WHERE Users.[Name] = @userName))
				ELSE 
				BEGIN
					PRINT('Лайк уже стоит')
					DELETE FROM CommentLikes
							WHERE CommentLikes.Id = (SELECT CommentLikes.Id
														FROM CommentLikes
															JOIN Users
														ON CommentLikes.UserId = Users.Id 
														WHERE CommentLikes.CommentId=@commentId AND @userName = Users.[Name])
					PRINT('Лайк снят')
				END
			END
			ELSE PRINT('Фото с таким id нет')
		END
		ELSE PRINT('Такого пользователя нет')

GO

CREATE PROCEDURE LikeProfile
	@profileId INT,
	@userName NVARCHAR(40)
	AS
	 	IF EXISTS (SELECT * FROM Users Where Users.[Name] = @userName)
		BEGIN
			IF EXISTS (SELECT * FROM Users WHERE Users.Id = @profileId)
			BEGIN
				IF (NOT EXISTS(SELECT TargetId
								FROM ProfileLikes 
									JOIN Users
								ON ProfileLikes.UserId = Users.Id
								WHERE ProfileLikes.TargetId=@profileId AND @userName = Users.[Name]))
					INSERT INTO ProfileLikes(TargetId,UserId) 
						VALUES(@profileId,(SELECT Users.Id FROM Users WHERE Users.[Name] = @userName))
				ELSE 
				BEGIN
					PRINT('Лайк уже стоит')
					DELETE FROM ProfileLikes
							WHERE ProfileLikes.Id = (SELECT ProfileLikes.Id
														FROM ProfileLikes 
															JOIN Users
														ON ProfileLikes.UserId = Users.Id
														WHERE ProfileLikes.TargetId=@profileId AND @userName = Users.[Name])
					PRINT('Лайк снят')
				END
			END
			ELSE PRINT('Фото с таким id нет')
		END
		ELSE PRINT('Такого пользователя нет')

GO

CREATE PROCEDURE ShowAllLikeComments
	@targetId INT
AS
	IF EXISTS(SELECT Comments.Id
				FROM Comments
				WHERE Comments.Id = @targetId)
		SELECT CommentLikes.CommentId as CommentId,
		UA.[Name] as Liker,
		Comments.CommentText as CommentText,
		U.[Name] as AuthorComment
		FROM CommentLikes 
		JOIN Comments
			ON CommentLikes.CommentId = Comments.Id 
		JOIN Users as U 
			ON Comments.UserId = U.Id 
		JOIN Users as UA 
			on CommentLikes.UserId = UA.Id
		WHERE CommentLikes.CommentId = @targetId

GO

CREATE PROCEDURE ShowAllLikeProfiles
	@targetId INT
AS
	IF EXISTS(SELECT Users.Id
				FROM Users
				WHERE Users.Id = @targetId)
		SELECT ProfileLikes.TargetId as ProfileId,
		UA.[Name] as Liker,
		U.[Name] as [Profile]
		FROM ProfileLikes 
		JOIN Users as UA 
			on ProfileLikes.UserId = UA.Id
		JOIN Users as U
			on ProfileLikes.TargetId = U.Id
		WHERE ProfileLikes.TargetId = @targetId

GO
	SELECT * FROM USERS;

CREATE PROCEDURE ShowUserLikes
	@userName
AS
	


EXEC AddUser 'Tom2';
EXEC AddComment '',4,'Bob';

SELECT * FROM PhotoWithCom