using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.DbManager.Tools
{
  /// <summary>
  /// This class facilitates the migration from using EF Migration to now using DbUP. This class is only required once to make that move
  /// where oldere databases only had a EF __MigrationHistory table and not DbUp __SchemaVersions table. This detects this and creates the 
  /// Dbup __SchemaVersions table and populates it with the mirations already perfomed from the EF __MigrationHistory table. 
  /// </summary>
  public class SynchToDbUp
  {
    public void RunMsSQL(string connectionString)
    {      
      string queryString = @"IF (
                                EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = '__MigrationHistory')
	                            )
	                            AND
	                            (
	                            NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = '__SchemaVersions')
	                            )
                            BEGIN
                                CREATE TABLE [dbo].[__SchemaVersions](
	                            [Id] [int] IDENTITY(1,1) NOT NULL,
	                            [ScriptName] [nvarchar](255) NOT NULL,
	                            [Applied] [datetime] NOT NULL,
                                CONSTRAINT [PK___SchemaVersions_Id] PRIMARY KEY CLUSTERED 
                                (
	                              [Id] ASC
                                    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                                ) ON [PRIMARY]

	                            INSERT INTO [dbo].[__SchemaVersions]
                                        ([ScriptName]
                                        ,[Applied])
                                SELECT CONCAT('Pyro.DbManager.SqlScripts.MsSQL.', MigrationId, '.sql'), CURRENT_TIMESTAMP FROM [dbo].[__MigrationHistory]     
                            END";

      using (SqlConnection connection = new SqlConnection(connectionString))
      {        
        SqlCommand command = new SqlCommand(queryString, connection);
        try
        {
          connection.Open();
          int Rows = command.ExecuteNonQuery();
          if (Rows > 0)
            Console.WriteLine("Synched __MigrationHistory table with __SchemaVersions Table");
          connection.Close();
        }
        catch (System.Data.SqlClient.SqlException SqlExec)
        {
          connection.Close();
          if (SqlExec.Number == 4060)
          {
            //4060 Cannot open database "%.*ls" requested by the login. The login failed.
            //If there is no databse at all, but this is fine as DBUp will create it for us and no need to do this migration
          }
          else
          {
            throw SqlExec;
          }          
        }
      }
    }

    public void RunPostgreSQL(string connectionString)
    {
      //Check is the __SchemaVersions table is present
      string queryOne = @"SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'public' AND TABLE_NAME = '__SchemaVersions'";

      //If not then created the move the __SchemaVersions table and move records from the __MigrationHistory table to the __SchemaVersions.
      //This all happen before DbUP even starts.
      string queryTwo =    @"DO
                            $do$
                            BEGIN
                            IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'public' AND TABLE_NAME = '__MigrationHistory') AND 
                               NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'public' AND TABLE_NAME = '__SchemaVersions')
                            THEN	
	                            CREATE TABLE public.""__SchemaVersions""
                                (
                                  schemaversionsid SERIAL PRIMARY KEY,
                                  scriptname character varying(255) COLLATE pg_catalog.""default"" NOT NULL,
                                  applied timestamp without time zone NOT NULL
                                );

                                  INSERT INTO public.""__SchemaVersions""(
	                            scriptname, applied)
	                            SELECT CONCAT('Pyro.DbManager.SqlScripts.PostgreSql.', ""MigrationId"", '.sql'), CURRENT_TIMESTAMP FROM public.""__MigrationHistory"";		
                            END IF;
                                END
                            $do$";

     
      using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
      {

        NpgsqlCommand command = new NpgsqlCommand(queryOne, connection);
        try
        {
          connection.Open();
          var Reader = command.ExecuteReader();
          if (!Reader.HasRows)
          {            
            Console.WriteLine("Synched __MigrationHistory table with __SchemaVersions Table Required");
            Reader.Close();
            command = new NpgsqlCommand(queryTwo, connection);
            int Rows = command.ExecuteNonQuery();
            Console.WriteLine("Synched __MigrationHistory table with __SchemaVersions Table Done");
          }
          connection.Close();
        }
        catch (Npgsql.PostgresException PostgreExec)
        {
          connection.Close();
          if (PostgreExec.SqlState == "3D000")
          {
            //3D000	invalid_catalog_name
            //If there is no databse at all, but this is fine as DBUp will create it for us and no need to do this migration
          }
          else
          {
            Console.WriteLine(PostgreExec.Message);
            throw PostgreExec;
          }          
        }        
      }            
    }
  }
}
