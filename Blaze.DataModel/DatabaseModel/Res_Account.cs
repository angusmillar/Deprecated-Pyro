using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Account : ResourceIndexBase
  {
    public int Res_AccountID {get; set;}
    public int? balance_Comparator {get; set;}
    public decimal? balance_Quantity {get; set;}
    public string balance_System {get; set;}
    public string balance_Code {get; set;}
    public string name_String {get; set;}
    public string owner_VersionId {get; set;}
    public string owner_FhirId {get; set;}
    public string owner_Type {get; set;}
    public virtual Blaze_RootUrlStore owner_Url { get; set; }
    public int? owner_Url_Blaze_RootUrlStoreID { get; set; }
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Blaze_RootUrlStore patient_Url { get; set; }
    public int? patient_Url_Blaze_RootUrlStoreID { get; set; }
    public DateTimeOffset? period_DateTimeOffsetLow {get; set;}
    public DateTimeOffset? period_DateTimeOffsetHigh {get; set;}
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string subject_VersionId {get; set;}
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual Blaze_RootUrlStore subject_Url { get; set; }
    public int? subject_Url_Blaze_RootUrlStoreID { get; set; }
    public ICollection<Res_Account_History> Res_Account_History_List { get; set; }
    public ICollection<Res_Account_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Account_Index_type> type_List { get; set; }
    public ICollection<Res_Account_Index_profile> profile_List { get; set; }
    public ICollection<Res_Account_Index_security> security_List { get; set; }
    public ICollection<Res_Account_Index_tag> tag_List { get; set; }
   
    public Res_Account()
    {
      this.identifier_List = new HashSet<Res_Account_Index_identifier>();
      this.type_List = new HashSet<Res_Account_Index_type>();
      this.profile_List = new HashSet<Res_Account_Index_profile>();
      this.security_List = new HashSet<Res_Account_Index_security>();
      this.tag_List = new HashSet<Res_Account_Index_tag>();
      this.Res_Account_History_List = new HashSet<Res_Account_History>();
    }
  }
}

