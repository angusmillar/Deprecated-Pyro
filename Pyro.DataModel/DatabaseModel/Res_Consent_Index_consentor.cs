using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_Consent_Index_consentor : ReferenceIndex
  {
    public int Res_Consent_Index_consentorID {get; set;}
    public virtual Res_Consent Res_Consent { get; set; }
   
    public Res_Consent_Index_consentor()
    {
    }
  }
}

