using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Encounter_Index_incomingreferral
  {
    public int Res_Encounter_Index_incomingreferralID {get; set;}
    public string FhirId {get; set;}
    public string Type {get; set;}
    public virtual Aux_RootUrlStore Aux_RootUrlStoreID { get; set; }
    public virtual Res_Encounter Res_Encounter { get; set; }
   
    public Res_Encounter_Index_incomingreferral()
    {
    }
  }
}

