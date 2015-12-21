using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlForge.Support
{
  public class SqlTable
  {
    public SqlTable(string TableName, string TableAlias)
    {
      this.TableName = TableName;
      this.TableAlias = TableAlias;
      _PropertyName = string.Empty;
      _PropertyAlias = string.Empty;
    }

    public string TableName { get; set; }
    public string TableAlias { get; set; }

    private string _PropertyName;
    public string PropertyName
    {
      get
      {
        return _PropertyName;
      }
    }

    private string _PropertyAlias;
    public string PropertyAlias
    {
      get
      {
        return _PropertyAlias;
      }
    }

    public void ClearProperty()
    {
      _PropertyName = string.Empty;
      _PropertyAlias = string.Empty;
    }

    public SqlTable Prop(string PropertyName, string PropertyAlias = "")
    {

      _PropertyAlias = PropertyAlias;
      _PropertyName = PropertyName;
      return this;
    }

  }
}
