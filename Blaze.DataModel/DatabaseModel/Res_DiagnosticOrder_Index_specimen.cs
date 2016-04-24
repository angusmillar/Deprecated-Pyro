using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_DiagnosticOrder_Index_specimen
  {
    public int Res_DiagnosticOrder_Index_specimenID {get; set;}
    public string FhirId {get; set;}
    public string Type {get; set;}
    public virtual Aux_RootUrlStore Aux_RootUrlStoreID { get; set; }
    public virtual Res_DiagnosticOrder Res_DiagnosticOrder { get; set; }
   
    public Res_DiagnosticOrder_Index_specimen()
    {
    }
  }
}

