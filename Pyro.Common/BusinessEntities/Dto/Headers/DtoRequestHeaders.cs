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
    private const string _IfNoneExistHeader = "If-None-Exist";
    private const string _IfModifiedSinceHeader = "If-Modified-Since";
    private const string _IfNoneMatchHeader = "If-None-Match";

    public string IfNoneExist { get; set; }
    public string IfModifiedSince { get; set; }
    public string IfNoneMatch { get; set; }

    public DtoRequestHeaders() { }
    public DtoRequestHeaders(System.Net.Http.Headers.HttpRequestHeaders HttpRequestHeaders)
    {
      IEnumerable<string> IfNoneExist;
      if (HttpRequestHeaders.TryGetValues(_IfNoneExistHeader, out IfNoneExist))
        this.IfNoneExist = IfNoneExist.FirstOrDefault();

      IEnumerable<string> IfModifiedSince;
      if (HttpRequestHeaders.TryGetValues(_IfModifiedSinceHeader, out IfModifiedSince))
        this.IfModifiedSince = IfModifiedSince.FirstOrDefault();

      IEnumerable<string> IfNoneMatchHeader;
      if (HttpRequestHeaders.TryGetValues(_IfNoneMatchHeader, out IfNoneMatchHeader))
        this.IfNoneMatch = IfNoneMatchHeader.FirstOrDefault();

    }
  }
}
