using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlForge.Support;

namespace SqlForge.Query
{
  public class Delete : StatmentBase
  {
    private const string _DeleteCommand = "DELETE FROM";

    private Queue<String> DeleteQueue = new Queue<String>();

    public void AddTable(SqlTable Table)
    {
      this.ResetCache();
      string item = string.Empty;

      item = String.Format("{0}", Table.TableName);

      Table.ClearProperty();
      DeleteQueue.Enqueue(item);
    }

    public override string GetStatment()
    {
      if (CachedStatment != string.Empty)
        return CachedStatment;

      var Statment = new StringBuilder(_DeleteCommand);
      Statment.NewLine().Space(2);
      do
      {
        var SqlProp = DeleteQueue.Dequeue();
        Statment.Append(SqlProp);

        if (DeleteQueue.Count != 0)
          Statment.Comma().Space();

      } while (DeleteQueue.Count != 0);
      Statment.NewLine();
      CachedStatment = Statment.ToString();
      return CachedStatment;
    }
  }
}
