using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Medication_Index_ingredient
  {
    public int Res_Medication_Index_ingredientID {get; set;}
    public string FhirId {get; set;}
    public string Type {get; set;}
    public virtual Aux_RootUrlStore Aux_RootUrlStoreID { get; set; }
    public virtual Res_Medication Res_Medication { get; set; }
   
    public Res_Medication_Index_ingredient()
    {
    }
  }
}

