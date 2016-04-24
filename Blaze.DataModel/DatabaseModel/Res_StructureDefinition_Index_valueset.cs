using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_StructureDefinition_Index_valueset
  {
    public int Res_StructureDefinition_Index_valuesetID {get; set;}
    public string FhirId {get; set;}
    public string Type {get; set;}
    public virtual Aux_RootUrlStore Aux_RootUrlStoreID { get; set; }
    public virtual Res_StructureDefinition Res_StructureDefinition { get; set; }
   
    public Res_StructureDefinition_Index_valueset()
    {
    }
  }
}

