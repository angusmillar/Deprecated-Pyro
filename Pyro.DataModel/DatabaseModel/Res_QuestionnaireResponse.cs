using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_QuestionnaireResponse : ResourceIndexBase
  {
    public int Res_QuestionnaireResponseID {get; set;}
    public string author_VersionId {get; set;}
    public string author_FhirId {get; set;}
    public string author_Type {get; set;}
    public virtual ServiceRootURL_Store author_Url { get; set; }
    public int? author_ServiceRootURL_StoreID { get; set; }
    public DateTimeOffset? authored_DateTimeOffset {get; set;}
    public string context_VersionId {get; set;}
    public string context_FhirId {get; set;}
    public string context_Type {get; set;}
    public virtual ServiceRootURL_Store context_Url { get; set; }
    public int? context_ServiceRootURL_StoreID { get; set; }
    public string identifier_Code {get; set;}
    public string identifier_System {get; set;}
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual ServiceRootURL_Store patient_Url { get; set; }
    public int? patient_ServiceRootURL_StoreID { get; set; }
    public string questionnaire_VersionId {get; set;}
    public string questionnaire_FhirId {get; set;}
    public string questionnaire_Type {get; set;}
    public virtual ServiceRootURL_Store questionnaire_Url { get; set; }
    public int? questionnaire_ServiceRootURL_StoreID { get; set; }
    public string source_VersionId {get; set;}
    public string source_FhirId {get; set;}
    public string source_Type {get; set;}
    public virtual ServiceRootURL_Store source_Url { get; set; }
    public int? source_ServiceRootURL_StoreID { get; set; }
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string subject_VersionId {get; set;}
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual ServiceRootURL_Store subject_Url { get; set; }
    public int? subject_ServiceRootURL_StoreID { get; set; }
    public ICollection<Res_QuestionnaireResponse_History> Res_QuestionnaireResponse_History_List { get; set; }
    public ICollection<Res_QuestionnaireResponse_Index_based_on> based_on_List { get; set; }
    public ICollection<Res_QuestionnaireResponse_Index_parent> parent_List { get; set; }
    public ICollection<Res_QuestionnaireResponse_Index__profile> _profile_List { get; set; }
    public ICollection<Res_QuestionnaireResponse_Index__security> _security_List { get; set; }
    public ICollection<Res_QuestionnaireResponse_Index__tag> _tag_List { get; set; }
   
    public Res_QuestionnaireResponse()
    {
      this.based_on_List = new HashSet<Res_QuestionnaireResponse_Index_based_on>();
      this.parent_List = new HashSet<Res_QuestionnaireResponse_Index_parent>();
      this._profile_List = new HashSet<Res_QuestionnaireResponse_Index__profile>();
      this._security_List = new HashSet<Res_QuestionnaireResponse_Index__security>();
      this._tag_List = new HashSet<Res_QuestionnaireResponse_Index__tag>();
      this.Res_QuestionnaireResponse_History_List = new HashSet<Res_QuestionnaireResponse_History>();
    }
  }
}

