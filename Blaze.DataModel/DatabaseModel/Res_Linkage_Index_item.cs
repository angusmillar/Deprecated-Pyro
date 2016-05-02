using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Linkage_Index_item
  {
    public int Res_Linkage_Index_itemID {get; set;}
    public string FhirId {get; set;}
    public string Type {get; set;}
    public virtual Blaze_RootUrlStore Url { get; set; }
    public int? Url_Blaze_RootUrlStoreID { get; set; }
    public virtual Res_Linkage Res_Linkage { get; set; }
   
    public Res_Linkage_Index_item()
    {
    }
  }
}

