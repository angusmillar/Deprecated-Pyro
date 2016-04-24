using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_SupplyDelivery_Index_receiver
  {
    public int Res_SupplyDelivery_Index_receiverID {get; set;}
    public string FhirId {get; set;}
    public string Type {get; set;}
    public virtual Aux_RootUrlStore Aux_RootUrlStoreID { get; set; }
    public virtual Res_SupplyDelivery Res_SupplyDelivery { get; set; }
   
    public Res_SupplyDelivery_Index_receiver()
    {
    }
  }
}

