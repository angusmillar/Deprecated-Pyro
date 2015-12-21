using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlForge.Support;

namespace SqlForge.Query
{
  public class Select : StatmentBase
  {
    private const string _SelectCommand = "SELECT";

    private Queue<String> SelectQueue = new Queue<String>();

    public void AddProp(SqlTable Prop)
    {
      this.ResetCache();
      string item = string.Empty;

      if (Prop.TableAlias != string.Empty)
        item = String.Format("{0}.{1}", Prop.TableAlias, Prop.PropertyName);
      else
        item = String.Format("{0}", Prop.PropertyName);

      if (Prop.PropertyAlias != string.Empty)
        item = String.Format("{0} AS {1}", item, Prop.PropertyAlias);

      Prop.ClearProperty();
      SelectQueue.Enqueue(item);
    }

    public void AddPropCount(SqlTable Prop)
    {
      this.ResetCache();
      string item = string.Empty;

      item = "COUNT(";
      if (Prop.TableAlias != string.Empty)
        item = String.Format("{0}{1}.{2})", item, Prop.TableAlias, Prop.PropertyName);
      else
        item = String.Format("{0}{1})", item, Prop.PropertyName);

      if (Prop.PropertyAlias != string.Empty)
        item = String.Format("{0} AS {1}", item, Prop.PropertyName);

      Prop.ClearProperty();
      SelectQueue.Enqueue(item);
    }

    public void AddCountAll(string AliasAs = "")
    {
      this.ResetCache();
      string item = string.Empty;
      item = "COUNT(*)";

      if (AliasAs != string.Empty)
        item = String.Format("{0} AS {2}", item, AliasAs);

      SelectQueue.Enqueue(item);
    }

    public void AddSelectAll()
    {
      this.ResetCache();
      string item = string.Empty;
      item = "*";

      SelectQueue.Enqueue(item);
    }

    public override string GetStatment()
    {
      if (CachedStatment != string.Empty)
        return CachedStatment;

      var Statment = new StringBuilder(_SelectCommand);
      Statment.NewLine().Space(2);
      do
      {        
        var SqlProp = SelectQueue.Dequeue();
        Statment.Append(SqlProp);

        if (SelectQueue.Count != 0)
          Statment.Comma().Space();

      } while (SelectQueue.Count != 0);
      Statment.NewLine();
      CachedStatment = Statment.ToString();
      return CachedStatment;
    }
  }
}
