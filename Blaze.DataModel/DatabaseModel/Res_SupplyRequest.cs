using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_SupplyRequest
  {
    public int Res_SupplyRequestID {get; set;}
    public string FhirId {get; set;}
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string identifier_Code {get; set;}
    public string identifier_System {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Aux_RootUrlStore patient_Aux_RootUrlStoreID { get; set; }
    public string source_FhirId {get; set;}
    public string source_Type {get; set;}
    public virtual Aux_RootUrlStore source_Aux_RootUrlStoreID { get; set; }
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public ICollection<Res_SupplyRequest_Index_kind> kind_List { get; set; }
    public ICollection<Res_SupplyRequest_Index_supplier> supplier_List { get; set; }
   
    public Res_SupplyRequest()
    {
      this.kind_List = new HashSet<Res_SupplyRequest_Index_kind>();
      this.supplier_List = new HashSet<Res_SupplyRequest_Index_supplier>();
    }
  }
}

