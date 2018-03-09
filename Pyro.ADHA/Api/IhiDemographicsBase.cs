using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.ADHA.Api 
{
  internal abstract class IhiDemographicsBase
  {
    public string Family { get; set; }
    public string Given { get; set; }
    public char SexChar { get; set; }
    public DateTime? Dob { get; set; }

    public string MedicareNumber { get; set; }
    public string MedicareIRN { get; set; }
    public string DVANumber { get; set; }
    public string IHINumber { get; set; }
  }
}
