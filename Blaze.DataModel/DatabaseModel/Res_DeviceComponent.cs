using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_DeviceComponent
  {
    public int Res_DeviceComponentID {get; set;}
    public string FhirId {get; set;}
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}
    public string parent_FhirId {get; set;}
    public string parent_Type {get; set;}
    public virtual Aux_RootUrlStore parent_Aux_RootUrlStoreID { get; set; }
    public string source_FhirId {get; set;}
    public string source_Type {get; set;}
    public virtual Aux_RootUrlStore source_Aux_RootUrlStoreID { get; set; }
    public ICollection<Res_DeviceComponent_Index_type> type_List { get; set; }
   
    public Res_DeviceComponent()
    {
      this.type_List = new HashSet<Res_DeviceComponent_Index_type>();
    }
  }
}

