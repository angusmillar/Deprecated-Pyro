using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pyro.Web.Models.Common
{
  public class ExternalPageLink
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public Uri Url { get; set; }
  }
}