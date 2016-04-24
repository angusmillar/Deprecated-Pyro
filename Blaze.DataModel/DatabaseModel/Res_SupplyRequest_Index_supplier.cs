using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_SupplyRequest_Index_supplier
  {
    public int Res_SupplyRequest_Index_supplierID {get; set;}
    public string FhirId {get; set;}
    public string Type {get; set;}
    public virtual Aux_RootUrlStore Aux_RootUrlStoreID { get; set; }
    public virtual Res_SupplyRequest Res_SupplyRequest { get; set; }
   
    public Res_SupplyRequest_Index_supplier()
    {
    }
  }
}

