using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlForge.Support;

namespace SqlForge.Query
{
  public class GroupBy : StatmentBase
  {
    private const string _OrderByCommand = "GROUP BY";
    private Queue<String> GroupByQueue = new Queue<String>();


    public void AddGroup(SqlTable Property)
    {
      this.ResetCache();

      string item = string.Empty;

      if (Property.TableAlias != string.Empty)
        item = String.Format("{0}.{1}", Property.TableAlias, Property.PropertyName);
      else
        item = String.Format("{0}", Property.PropertyName);

      GroupByQueue.Enqueue(item);

    }

    public override string GetStatment()
    {
      if (this.CachedStatment != string.Empty)
        return this.CachedStatment;

      var Statment = new StringBuilder(_OrderByCommand);
      Statment.NewLine().Space(2);
      do
      {
        var SqlProp = GroupByQueue.Dequeue();
        Statment.Space().Append(SqlProp);

        if (GroupByQueue.Count != 0)
          Statment.Comma();

      } while (GroupByQueue.Count != 0);

      Statment.NewLine();
      this.CachedStatment = Statment.ToString();
      return this.CachedStatment;
    }
  }
}
