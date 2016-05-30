using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_SupplyRequest : ResourceIndexBase
  {
    public int Res_SupplyRequestID {get; set;}
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string identifier_Code {get; set;}
    public string identifier_System {get; set;}
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Blaze_RootUrlStore patient_Url { get; set; }
    public int? patient_Url_Blaze_RootUrlStoreID { get; set; }
    public string source_VersionId {get; set;}
    public string source_FhirId {get; set;}
    public string source_Type {get; set;}
    public virtual Blaze_RootUrlStore source_Url { get; set; }
    public int? source_Url_Blaze_RootUrlStoreID { get; set; }
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public ICollection<Res_SupplyRequest_History> Res_SupplyRequest_History_List { get; set; }
    public ICollection<Res_SupplyRequest_Index_kind> kind_List { get; set; }
    public ICollection<Res_SupplyRequest_Index_supplier> supplier_List { get; set; }
    public ICollection<Res_SupplyRequest_Index_profile> profile_List { get; set; }
    public ICollection<Res_SupplyRequest_Index_security> security_List { get; set; }
    public ICollection<Res_SupplyRequest_Index_tag> tag_List { get; set; }
   
    public Res_SupplyRequest()
    {
      this.kind_List = new HashSet<Res_SupplyRequest_Index_kind>();
      this.supplier_List = new HashSet<Res_SupplyRequest_Index_supplier>();
      this.profile_List = new HashSet<Res_SupplyRequest_Index_profile>();
      this.security_List = new HashSet<Res_SupplyRequest_Index_security>();
      this.tag_List = new HashSet<Res_SupplyRequest_Index_tag>();
      this.Res_SupplyRequest_History_List = new HashSet<Res_SupplyRequest_History>();
    }
  }
}

