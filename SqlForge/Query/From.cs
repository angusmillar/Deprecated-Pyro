using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlForge.Support;

namespace SqlForge.Query
{
  public class From : StatmentBase
  {
    private const string _FromCommand = "FROM";    

    private Queue<String> FromQueue = new Queue<String>();

    public void AddTable(SqlTable Table)
    {
      this.ResetCache();
      string item = string.Empty;
      if (Table.TableAlias != string.Empty)
        item = String.Format("{0} {1}", Table.TableName, Table.TableAlias);
      else
        item = String.Format("{0}", Table.TableName);
      FromQueue.Enqueue(item);
    }

    public override string GetStatment()
    {
      if (CachedStatment != string.Empty)
        return CachedStatment;

      var Statment = new StringBuilder(_FromCommand);

      do
      {
        var SqlProp = FromQueue.Dequeue();
        Statment.Space().Append(SqlProp);

        if (FromQueue.Count != 0)
          Statment.Comma();

      } while (FromQueue.Count != 0);
      Statment.NewLine();
      
      CachedStatment = Statment.ToString();
      return CachedStatment;
    }
  }
}
