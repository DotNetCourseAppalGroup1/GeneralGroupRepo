/****** Скрипт для команды SelectTopNRows из среды SSMS  ******/
SELECT TOP (1000) [titleFilm]
      ,[titleHall]
      ,[timeToStart]
  FROM [Cinema].[dbo].[TimeTable]