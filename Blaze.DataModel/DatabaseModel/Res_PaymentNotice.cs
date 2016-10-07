using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_PaymentNotice : ResourceIndexBase
  {
    public int Res_PaymentNoticeID {get; set;}
    public DateTimeOffset? created_DateTimeOffset {get; set;}
    public string organizationidentifier_Code {get; set;}
    public string organizationidentifier_System {get; set;}
    public string organizationreference_VersionId {get; set;}
    public string organizationreference_FhirId {get; set;}
    public string organizationreference_Type {get; set;}
    public virtual ServiceRootURL_Store organizationreference_Url { get; set; }
    public int? organizationreference_ServiceRootURL_StoreID { get; set; }
    public string paymentstatus_Code {get; set;}
    public string paymentstatus_System {get; set;}
    public string provideridentifier_Code {get; set;}
    public string provideridentifier_System {get; set;}
    public string providerreference_VersionId {get; set;}
    public string providerreference_FhirId {get; set;}
    public string providerreference_Type {get; set;}
    public virtual ServiceRootURL_Store providerreference_Url { get; set; }
    public int? providerreference_ServiceRootURL_StoreID { get; set; }
    public string requestidentifier_Code {get; set;}
    public string requestidentifier_System {get; set;}
    public string requestreference_VersionId {get; set;}
    public string requestreference_FhirId {get; set;}
    public string requestreference_Type {get; set;}
    public virtual ServiceRootURL_Store requestreference_Url { get; set; }
    public int? requestreference_ServiceRootURL_StoreID { get; set; }
    public string responseidentifier_Code {get; set;}
    public string responseidentifier_System {get; set;}
    public string responsereference_VersionId {get; set;}
    public string responsereference_FhirId {get; set;}
    public string responsereference_Type {get; set;}
    public virtual ServiceRootURL_Store responsereference_Url { get; set; }
    public int? responsereference_ServiceRootURL_StoreID { get; set; }
    public int? statusdate_Date {get; set;}
    public ICollection<Res_PaymentNotice_History> Res_PaymentNotice_History_List { get; set; }
    public ICollection<Res_PaymentNotice_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_PaymentNotice_Index__profile> _profile_List { get; set; }
    public ICollection<Res_PaymentNotice_Index__security> _security_List { get; set; }
    public ICollection<Res_PaymentNotice_Index__tag> _tag_List { get; set; }
   
    public Res_PaymentNotice()
    {
      this.identifier_List = new HashSet<Res_PaymentNotice_Index_identifier>();
      this._profile_List = new HashSet<Res_PaymentNotice_Index__profile>();
      this._security_List = new HashSet<Res_PaymentNotice_Index__security>();
      this._tag_List = new HashSet<Res_PaymentNotice_Index__tag>();
      this.Res_PaymentNotice_History_List = new HashSet<Res_PaymentNotice_History>();
    }
  }
}

