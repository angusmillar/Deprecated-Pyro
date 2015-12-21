using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlForge.Support;

namespace SqlForge.Query
{
  public class OrderBy : StatmentBase
  {
    private const string _OrderByCommand = "ORDER BY";
    private Queue<String> OrderByQueue = new Queue<String>();


    public void AddOrder(SqlTable Property, Enums.SortOrder SortOrder = Enums.SortOrder.Ascending)
    {
      this.ResetCache();

      string item = string.Empty;

      if (Property.TableAlias != string.Empty)
        item = String.Format("{0}.{1} {2}", Property.TableAlias, Property.PropertyName, StringSupport.SortOrderToString(SortOrder));
      else
        item = String.Format("{0} {1}", Property.PropertyName, StringSupport.SortOrderToString(SortOrder));

      OrderByQueue.Enqueue(item);

    }
    
    public override string GetStatment()
    {
      if (this.CachedStatment != string.Empty)
        return this.CachedStatment;

      var Statment = new StringBuilder(_OrderByCommand);
      Statment.NewLine().Space(2);
      do
      {
        var SqlProp = OrderByQueue.Dequeue();
        Statment.Space().Append(SqlProp);

        if (OrderByQueue.Count != 0)
          Statment.Comma();

      } while (OrderByQueue.Count != 0);

      Statment.NewLine();
      this.CachedStatment = Statment.ToString();
      return this.CachedStatment;
    }
  }
}
