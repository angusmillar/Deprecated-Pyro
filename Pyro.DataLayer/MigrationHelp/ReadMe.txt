###############################################################################################
########################### Migration Command Help File #######################################
###############################################################################################
This file contains Entity Framework Migration command help for creating and running 
Entity Franework Migrations. As we have many database providers 'Microsoft SQL Server' and 
'PostgreSQL' each needs a migration created when there are any databse changes. 
Below are helper examples for creating these commands.

Note: If you uses the '-ConfigurationTypeName ConfigurationMsSql' and yet have the PostgreSQL
connection string active in the Pyro.ConsoleServer.App_Data/Connctions.config file, becuase 
you forgot to align the migration database you wanted to migrate with the connection string 
you have set. The you will see an error:

'Unable to generate an explicit migration because the following explicit migrations are 
 pending:...etc'

This is because the migration it is attempting to hit the wrong database and if it succeeds in 
connectiong it will read that database's __MigrationHistory table, yet that table will have the 
wrong ContextKey property in this table. It will therefore belive it needs to perform all migration 
from the beginging. When you see this you should first check that you have the correct 
connectionstring set in te Connctions.config file for the migration you are trying to create.

###############################################################################################
###### Microsoft SQL Server ###################################################################
###############################################################################################

  Key Elements:
  -ConfigurationTypeName ConfigurationMsSql
  -ConnectionProviderName System.Data.SqlClient
  -ConnectionString "Server=R90G68H5\SQLEXPRESS;Database=PyroConsole;User Id=Pyro;Password=prometheus;"


  ##Add Migration to Microsoft SQL Server
Add-Migration -Name [Migration Name] -ConfigurationTypeName ConfigurationMsSql 

  ## Generate Migration SQL Script for the migration named [Migration Name] for Microsoft SQL Server
Update-Database -TargetMigration [Migration Name] -Script -ConfigurationTypeName ConfigurationMsSql 

  ## Update the database to the latest migration for Microsoft SQL Server
Update-Database -Script -ConfigurationTypeName ConfigurationMsSql 

  ## Perform the Migration Script for migration named [Migration Name] for Microsoft SQL Server
Update-Database -TargetMigration [Migration Name] -Script -ConfigurationTypeName ConfigurationMsSql 

  ## Generate a script to migrate the database from a specified start migration for Microsoft SQL Server
  ## named [Source Migration Name] to a specified target migration named [Target Migration Name]
Update-Database -SourceMigration [Source Migration Name] -TargetMigration [Target Migration Name] -Script -ConfigurationTypeName ConfigurationMsSql 

###############################################################################################
###### PostgreSQL #############################################################################
###############################################################################################

  Key Elements:
  -ConfigurationTypeName ConfigurationPostgre
  -ConnectionProviderName Npgsql
  -ConnectionString "Server=127.0.0.1;Port=5432;Database=PyroConsole2;User Id=postgres;Password=sa"

##Add Migration to PostgreSQL
Add-Migration -Name [Migration Name] -ConfigurationTypeName ConfigurationPostgre 

  ## Generate Migration SQL Script for the migration named [Migration Name] for PostgreSQL database
Update-Database -TargetMigration [Migration Name] -Script -ConfigurationTypeName ConfigurationPostgre 

  ## Update the database to the latest migration for PostgreSQL
Update-Database -Script -ConfigurationTypeName ConfigurationPostgre 

  ## Perform the Migration Script for migration named [Migration Name] to PostgreSQL database
Update-Database -TargetMigration [Migration Name] -Script -ConfigurationTypeName ConfigurationPostgre 

  ## Generate a script to migrate the database from a specified start migration for PostgreSQL
  ## named [Source Migration Name] to a specified target migration named [Target Migration Name]
Update-Database -SourceMigration [Source Migration Name] -TargetMigration [Target Migration Name] -Script -ConfigurationTypeName ConfigurationPostgre 

