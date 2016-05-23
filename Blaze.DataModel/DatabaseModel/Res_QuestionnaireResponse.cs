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
    public string author_FhirId {get; set;}
    public string author_Type {get; set;}
    public virtual Blaze_RootUrlStore author_Url { get; set; }
    public int? author_Url_Blaze_RootUrlStoreID { get; set; }
    public DateTimeOffset? authored_DateTimeOffset {get; set;}
    public string encounter_FhirId {get; set;}
    public string encounter_Type {get; set;}
    public virtual Blaze_RootUrlStore encounter_Url { get; set; }
    public int? encounter_Url_Blaze_RootUrlStoreID { get; set; }
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Blaze_RootUrlStore patient_Url { get; set; }
    public int? patient_Url_Blaze_RootUrlStoreID { get; set; }
    public string questionnaire_FhirId {get; set;}
    public string questionnaire_Type {get; set;}
    public virtual Blaze_RootUrlStore questionnaire_Url { get; set; }
    public int? questionnaire_Url_Blaze_RootUrlStoreID { get; set; }
    public string source_FhirId {get; set;}
    public string source_Type {get; set;}
    public virtual Blaze_RootUrlStore source_Url { get; set; }
    public int? source_Url_Blaze_RootUrlStoreID { get; set; }
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual Blaze_RootUrlStore subject_Url { get; set; }
    public int? subject_Url_Blaze_RootUrlStoreID { get; set; }
    public ICollection<Res_QuestionnaireResponse_Index_meta_profile> meta_profile_List { get; set; }
    public ICollection<Res_QuestionnaireResponse_Index_meta_security> meta_security_List { get; set; }
    public ICollection<Res_QuestionnaireResponse_Index_meta_tag> meta_tag_List { get; set; }
    public ICollection<Res_QuestionnaireResponse_History> Res_QuestionnaireResponse_History_List { get; set; }
   
    public Res_QuestionnaireResponse()
    {
      this.meta_tag_List = new HashSet<Res_QuestionnaireResponse_Index_meta_tag>();
      this.meta_security_List = new HashSet<Res_QuestionnaireResponse_Index_meta_security>();
      this.meta_profile_List = new HashSet<Res_QuestionnaireResponse_Index_meta_profile>();
      this.Res_QuestionnaireResponse_History_List = new HashSet<Res_QuestionnaireResponse_History>();
    }
  }
}

