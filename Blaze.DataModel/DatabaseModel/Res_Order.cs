using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Order : ResourceIndexBase
  {
    public int Res_OrderID {get; set;}
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual ServiceRootURL_Store patient_Url { get; set; }
    public int? patient_ServiceRootURL_StoreID { get; set; }
    public string source_VersionId {get; set;}
    public string source_FhirId {get; set;}
    public string source_Type {get; set;}
    public virtual ServiceRootURL_Store source_Url { get; set; }
    public int? source_ServiceRootURL_StoreID { get; set; }
    public string subject_VersionId {get; set;}
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual ServiceRootURL_Store subject_Url { get; set; }
    public int? subject_ServiceRootURL_StoreID { get; set; }
    public string target_VersionId {get; set;}
    public string target_FhirId {get; set;}
    public string target_Type {get; set;}
    public virtual ServiceRootURL_Store target_Url { get; set; }
    public int? target_ServiceRootURL_StoreID { get; set; }
    public ICollection<Res_Order_History> Res_Order_History_List { get; set; }
    public ICollection<Res_Order_Index_detail> detail_List { get; set; }
    public ICollection<Res_Order_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Order_Index_when> when_List { get; set; }
    public ICollection<Res_Order_Index_when_code> when_code_List { get; set; }
    public ICollection<Res_Order_Index__profile> _profile_List { get; set; }
    public ICollection<Res_Order_Index__security> _security_List { get; set; }
    public ICollection<Res_Order_Index__tag> _tag_List { get; set; }
   
    public Res_Order()
    {
      this.detail_List = new HashSet<Res_Order_Index_detail>();
      this.identifier_List = new HashSet<Res_Order_Index_identifier>();
      this.when_List = new HashSet<Res_Order_Index_when>();
      this.when_code_List = new HashSet<Res_Order_Index_when_code>();
      this._profile_List = new HashSet<Res_Order_Index__profile>();
      this._security_List = new HashSet<Res_Order_Index__security>();
      this._tag_List = new HashSet<Res_Order_Index__tag>();
      this.Res_Order_History_List = new HashSet<Res_Order_History>();
    }
  }
}

