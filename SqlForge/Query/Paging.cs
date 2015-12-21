using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlForge.Support;

namespace SqlForge.Query
{
  public class Paging : StatmentBase
  {
    public int PageNumber { get; private set; }
    public int RowsPerPage { get; private set; }

    public Paging(int PageNumber, int RowsPerPage)
    {
      this.ResetCache();
      this.PageNumber = PageNumber;
      this.RowsPerPage = RowsPerPage;
    }

    public override string GetStatment()
    {
      if (this.CachedStatment != string.Empty)
        return this.CachedStatment;

      if (this.PageNumber == 0 || this.RowsPerPage == 0)
        throw new ArgumentException("PageNumber or RowsPerPage can not be zero when calling Paging for SqlQueryForge.");

      int OffsetInteger = (this.PageNumber - 1) * this.RowsPerPage;
      var Statment = new StringBuilder();

      //Example:
      //OFFSET ((@PageNumber - 1) * @RowspPage) ROWS
      //FETCH NEXT @RowspPage ROWS ONLY;

      Statment.Offset().Space().Append(OffsetInteger.ToString()).Space().Rows().Space();
      Statment.Fetch().Space().Next().Space().Append(this.RowsPerPage).Space().Rows().Space().Only();

      Statment.NewLine();
      this.CachedStatment = Statment.ToString();
      return this.CachedStatment;
    }
  }
}
