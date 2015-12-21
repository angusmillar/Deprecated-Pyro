using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlForge.Support;

namespace SqlForge.Query
{
  public class Join: StatmentBase
  {
    private const string _JoinCommand = "JOIN";    

    private Queue<String> JoinQueue = new Queue<String>();

    public void AddJoin(SqlTable table, SqlTable onLeft, SqlTable onRight)
    {
      this.ResetCache();

      string item = string.Empty;
      //Must have table a property aliases if joining another table
      item = String.Format("{0} {1} {2} ON {3}.{4} = {5}.{6}", _JoinCommand, table.TableName, table.TableAlias,
        onLeft.TableAlias, onLeft.PropertyName,
        onRight.TableAlias, onRight.PropertyName);

      JoinQueue.Enqueue(item);
    }

    public override string GetStatment()
    {      
      if (CachedStatment != string.Empty)
        return CachedStatment;

      var Statment = new StringBuilder();
      do
      {
        var SqlProp = JoinQueue.Dequeue();
        Statment.Space(2).Append(SqlProp).NewLine();

      } while (JoinQueue.Count != 0);
      CachedStatment = Statment.ToString();
      return CachedStatment;
    }
  }
}
