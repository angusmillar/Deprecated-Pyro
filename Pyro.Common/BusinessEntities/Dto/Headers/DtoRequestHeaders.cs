using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Interfaces.Dto.Headers;

namespace Pyro.Common.BusinessEntities.Dto.Headers
{
  public class DtoRequestHeaders : IDtoRequestHeaders
  {
    public string IfNoneExist { get; set; }

    public DtoRequestHeaders() { }
    public DtoRequestHeaders(System.Net.Http.Headers.HttpRequestHeaders HttpRequestHeaders)
    {
      IEnumerable<string> IfNoneExist;
      if (HttpRequestHeaders.TryGetValues("If-None-Exist", out IfNoneExist))
      this.IfNoneExist = IfNoneExist.FirstOrDefault();
    }
  }
}
