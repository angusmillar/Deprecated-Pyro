using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_Account : ResourceIndexBase
  {
    public int Res_AccountID {get; set;}
    public Hl7.Fhir.Model.Quantity.QuantityComparator? balance_Comparator {get; set;}
    public decimal? balance_Quantity {get; set;}
    public string balance_System {get; set;}
    public string balance_Code {get; set;}
    public string balance_Unit {get; set;}
    public string name_String {get; set;}
    public string owner_VersionId {get; set;}
    public string owner_FhirId {get; set;}
    public string owner_Type {get; set;}
    public virtual ServiceRootURL_Store owner_Url { get; set; }
    public int? owner_ServiceRootURL_StoreID { get; set; }
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual ServiceRootURL_Store patient_Url { get; set; }
    public int? patient_ServiceRootURL_StoreID { get; set; }
    public DateTimeOffset? period_DateTimeOffsetLow {get; set;}
    public DateTimeOffset? period_DateTimeOffsetHigh {get; set;}
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string subject_VersionId {get; set;}
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual ServiceRootURL_Store subject_Url { get; set; }
    public int? subject_ServiceRootURL_StoreID { get; set; }
    public ICollection<Res_Account_History> Res_Account_History_List { get; set; }
    public ICollection<Res_Account_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Account_Index_type> type_List { get; set; }
    public ICollection<Res_Account_Index__profile> _profile_List { get; set; }
    public ICollection<Res_Account_Index__security> _security_List { get; set; }
    public ICollection<Res_Account_Index__tag> _tag_List { get; set; }
   
    public Res_Account()
    {
      this.identifier_List = new HashSet<Res_Account_Index_identifier>();
      this.type_List = new HashSet<Res_Account_Index_type>();
      this._profile_List = new HashSet<Res_Account_Index__profile>();
      this._security_List = new HashSet<Res_Account_Index__security>();
      this._tag_List = new HashSet<Res_Account_Index__tag>();
      this.Res_Account_History_List = new HashSet<Res_Account_History>();
    }
  }
}

