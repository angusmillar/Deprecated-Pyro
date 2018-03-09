using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.ADHA.Api
{
  internal class IhiResponseData : IhiDemographicsBase, IIhiResponseData
  {
    public string IHIStatus { get; set; }
    public string IHIRecordStatus { get; set; }
  }
}
