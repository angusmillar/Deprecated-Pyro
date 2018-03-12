using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.ADHA.Api
{
  public class HiServiceMessage : IHiServiceMessage
  {
    public string Code { get; set; }
    public string Reason { get; set; }
    public string SeverityType { get; set; }  
  }
}
