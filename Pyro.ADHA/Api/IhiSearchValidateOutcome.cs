using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.ADHA.Api
{
  internal class IhiSearchValidateOutcome : IIhiSearchValidateOutcome
  {
    public IhiSearchValidateOutcome(IIhiRequestData RequestDemographics)
    {
      this.SuccessfulQuery = false;
      this.RequestData = RequestDemographics;
      this.ResponseData = new IhiResponseData();
      this.QueryMetadata = new IhiQueryMetadata();
    }

    public bool SuccessfulQuery { get; set; }
    public IIhiRequestData RequestData { get; set; }
    public IIhiResponseData ResponseData { get; set; }
    public IIhiQueryMetadata QueryMetadata { get; set; }
  }
}