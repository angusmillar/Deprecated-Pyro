using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Pyro.Web.Areas.FhirClientPage.Models
{
  public class FhirClientViewModel
  {

    [Display(Name = "Server Url")]
    [DataType(DataType.Text)]
    public string ServiceBaseRoot
    {
      get
      {
        return Pyro.Common.Cache.WebConfigProperties.ServiceBaseURL();
      }
    }
  }
}