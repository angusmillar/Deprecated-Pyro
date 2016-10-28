using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Encounter_Index_practitioner : ReferenceIndex
  {
    public int Res_Encounter_Index_practitionerID {get; set;}
    public virtual Res_Encounter Res_Encounter { get; set; }
   
    public Res_Encounter_Index_practitioner()
    {
    }
  }
}

