using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.SqlServer;

namespace Pyro.DataLayer.DbModel.DbMicrosoftSQLServer
{
  public class CustomSqlServerMigrationSqlGenerator : SqlServerMigrationSqlGenerator
  {
    protected override void Generate(AlterColumnOperation alterColumnOperation)
    {
      base.Generate(alterColumnOperation);
      AnnotationValues values;
      if (alterColumnOperation.Column.Annotations.TryGetValue("CaseSensitive", out values))
      {
        if (values.NewValue != null && values.NewValue.ToString() == "True")
        {
          using (var writer = Writer())
          {
            if (alterColumnOperation.Column.IsNullable.HasValue && !alterColumnOperation.Column.IsNullable.Value)
            {
              writer.WriteLine(
                "ALTER TABLE {0} ALTER COLUMN {1} NVARCHAR({2}) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL",
                alterColumnOperation.Table,
                alterColumnOperation.Column.Name,
                alterColumnOperation.Column.MaxLength);
            }
            else
            {
              writer.WriteLine(
                "ALTER TABLE {0} ALTER COLUMN {1} NVARCHAR({2}) COLLATE SQL_Latin1_General_CP1_CS_AS NULL",
                alterColumnOperation.Table,
                alterColumnOperation.Column.Name,
                alterColumnOperation.Column.MaxLength);
            }
            Statement(writer);
          }
        }
      }
    }

    protected override void Generate(AddColumnOperation addColumnOperation)
    {
      base.Generate(addColumnOperation);
      AnnotationValues values;
      if (addColumnOperation.Column.Annotations.TryGetValue("CaseSensitive", out values))
      {
        if (values.NewValue != null && values.NewValue.ToString() == "True")
        {
          using (var writer = Writer())
          {
            if (addColumnOperation.Column.IsNullable.HasValue && !addColumnOperation.Column.IsNullable.Value)
            {
              writer.WriteLine(
                  "ALTER TABLE {0} ALTER COLUMN {1} NVARCHAR({2}) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL",
                  addColumnOperation.Table,
                  addColumnOperation.Column.Name,
                  addColumnOperation.Column.MaxLength);
            }
            else
            {
              writer.WriteLine(
                  "ALTER TABLE {0} ALTER COLUMN {1} NVARCHAR({2}) COLLATE SQL_Latin1_General_CP1_CS_AS NULL",
                  addColumnOperation.Table,
                  addColumnOperation.Column.Name,
                  addColumnOperation.Column.MaxLength);
            }
            Statement(writer);
          }
        }
      }
    }

    //protected override void Generate(CreateTableOperation createTableOperation)
    //{
    //  base.Generate(createTableOperation);
    //  AnnotationValues values;
    //  foreach(var Col in createTableOperation.Columns)
    //  {
    //    if (Col.Annotations.TryGetValue("CaseSensitive", out values))
    //    {
    //      if (values.NewValue != null && values.NewValue.ToString() == "True")
    //      {
    //        using (var writer = Writer())
    //        {
    //          if (Col.IsNullable.HasValue && Col.IsNullable.Value)
    //          {
    //            writer.WriteLine(
    //              "ALTER TABLE {0} ALTER COLUMN {1} NVARCHAR({2}) COLLATE SQL_Latin1_General_CP1_CS_AS",
    //              Col.,
    //              Col.Column.Name,
    //              Col.Column.MaxLength);
    //          }
    //          else
    //          {
    //            writer.WriteLine(
    //                "ALTER TABLE {0} ALTER COLUMN {1} NVARCHAR({2}) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL",
    //                Col.Table,
    //                Col.Column.Name,
    //                Col.Column.MaxLength);
    //          }
    //          Statement(writer);
    //        }
    //      }
    //    }
    //  }  
    //}


  }
}


//This method works even if you use auto migrations. But the limitation is our overridden 
//“Genarated” method runs when a column is altered.That means if we add a new column and 
//at the same time if we add the “CaseSensitive” annotation for that column, the collation 
//change will not be applied when we do migrations. To enable it, we need to 
//override “ Generate(AddColumnOperation addColumnOperation)” method and 
//“Generate(CreateTableOperation createTableOperation)” method.
//We can put the same logic after “base.Generate(addColumnOperation)” and 
//“base.Generate(createTableOperation)” methods.