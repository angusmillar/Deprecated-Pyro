INSERT INTO [dbo].[_SParamResource]
           ([ServiceSearchParameterId]
           ,[ResourceType])
     VALUES
           ((SELECT [Id]  
             FROM [dbo].[_SearchParam]
             Where [Name] = '_profile')
           ,129)


