using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.Enum
{
  public static class ServiceEnums
  {
    public enum ServiceRequestType { None, Read, Search, Create, Update, Delete, History, Metadata };
  }
}
