/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [id]
      ,[publisher]
      ,[title]
      ,[author]
  FROM [dbLibrary].[dbo].[Books]