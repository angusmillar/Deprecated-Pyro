using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_Communication : ResourceIndexBase
  {
    public int Res_CommunicationID {get; set;}
    public string context_VersionId {get; set;}
    public string context_FhirId {get; set;}
    public string context_Type {get; set;}
    public virtual ServiceRootURL_Store context_Url { get; set; }
    public int? context_ServiceRootURL_StoreID { get; set; }
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual ServiceRootURL_Store patient_Url { get; set; }
    public int? patient_ServiceRootURL_StoreID { get; set; }
    public DateTimeOffset? received_DateTimeOffset {get; set;}
    public string sender_VersionId {get; set;}
    public string sender_FhirId {get; set;}
    public string sender_Type {get; set;}
    public virtual ServiceRootURL_Store sender_Url { get; set; }
    public int? sender_ServiceRootURL_StoreID { get; set; }
    public DateTimeOffset? sent_DateTimeOffset {get; set;}
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string subject_VersionId {get; set;}
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual ServiceRootURL_Store subject_Url { get; set; }
    public int? subject_ServiceRootURL_StoreID { get; set; }
    public ICollection<Res_Communication_History> Res_Communication_History_List { get; set; }
    public ICollection<Res_Communication_Index_based_on> based_on_List { get; set; }
    public ICollection<Res_Communication_Index_category> category_List { get; set; }
    public ICollection<Res_Communication_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Communication_Index_medium> medium_List { get; set; }
    public ICollection<Res_Communication_Index_recipient> recipient_List { get; set; }
    public ICollection<Res_Communication_Index__profile> _profile_List { get; set; }
    public ICollection<Res_Communication_Index__security> _security_List { get; set; }
    public ICollection<Res_Communication_Index__tag> _tag_List { get; set; }
   
    public Res_Communication()
    {
      this.based_on_List = new HashSet<Res_Communication_Index_based_on>();
      this.category_List = new HashSet<Res_Communication_Index_category>();
      this.identifier_List = new HashSet<Res_Communication_Index_identifier>();
      this.medium_List = new HashSet<Res_Communication_Index_medium>();
      this.recipient_List = new HashSet<Res_Communication_Index_recipient>();
      this._profile_List = new HashSet<Res_Communication_Index__profile>();
      this._security_List = new HashSet<Res_Communication_Index__security>();
      this._tag_List = new HashSet<Res_Communication_Index__tag>();
      this.Res_Communication_History_List = new HashSet<Res_Communication_History>();
    }
  }
}

