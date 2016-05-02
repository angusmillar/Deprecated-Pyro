using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_OrderResponse_Index_fulfillment
  {
    public int Res_OrderResponse_Index_fulfillmentID {get; set;}
    public string FhirId {get; set;}
    public string Type {get; set;}
    public virtual Blaze_RootUrlStore Url { get; set; }
    public int? Url_Blaze_RootUrlStoreID { get; set; }
    public virtual Res_OrderResponse Res_OrderResponse { get; set; }
   
    public Res_OrderResponse_Index_fulfillment()
    {
    }
  }
}

