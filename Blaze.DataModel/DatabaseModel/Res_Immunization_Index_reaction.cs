using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Immunization_Index_reaction
  {
    public int Res_Immunization_Index_reactionID {get; set;}
    public string FhirId {get; set;}
    public string Type {get; set;}
    public virtual Aux_RootUrlStore Aux_RootUrlStoreID { get; set; }
    public virtual Res_Immunization Res_Immunization { get; set; }
   
    public Res_Immunization_Index_reaction()
    {
    }
  }
}

