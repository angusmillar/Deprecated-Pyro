using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlForge.Query
{
  public class Query
  {
    public Delete Delete { get; set; }
    public Select Select { get; set; }
    public From From { get; set; }
    public Join Join { get; set; }
    public Where Where { get; set; }
    public GroupBy GroupBy { get; set; }
    public OrderBy OrderBy { get; set; }
    public Paging Paging { get; set; }
    public string CreateQuery()
    {
      if ((Select == null || From == null) && (Delete == null))
        throw new ArgumentException("Must set both Select and From or Delete before calling CreateQuery.");

      StringBuilder Query = new StringBuilder();

      if (Delete != null)
        Query.Append(Delete.GetStatment());

      if (Select != null)
        Query.Append(Select.GetStatment());

      if (From != null)
        Query.Append(From.GetStatment());

      if (Join != null)
        Query.Append(Join.GetStatment());

      if (Where != null)
        Query.Append(Where.GetStatment());

      if (GroupBy != null)
        Query.Append(GroupBy.GetStatment());

      if (OrderBy != null)
        Query.Append(OrderBy.GetStatment());

      if (Paging != null)
        Query.Append(Paging.GetStatment());
      
      return Query.ToString();

    }
  }
}
