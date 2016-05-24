using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Questionnaire : ResourceIndexBase
  {
    public int Res_QuestionnaireID {get; set;}
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string publisher_String {get; set;}
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string title_String {get; set;}
    public string version_String {get; set;}
    public ICollection<Res_Questionnaire_History> Res_Questionnaire_History_List { get; set; }
    public ICollection<Res_Questionnaire_Index_code> code_List { get; set; }
    public ICollection<Res_Questionnaire_Index_context> context_List { get; set; }
    public ICollection<Res_Questionnaire_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Questionnaire_Index_profile> profile_List { get; set; }
    public ICollection<Res_Questionnaire_Index_security> security_List { get; set; }
    public ICollection<Res_Questionnaire_Index_tag> tag_List { get; set; }
   
    public Res_Questionnaire()
    {
      this.code_List = new HashSet<Res_Questionnaire_Index_code>();
      this.context_List = new HashSet<Res_Questionnaire_Index_context>();
      this.identifier_List = new HashSet<Res_Questionnaire_Index_identifier>();
      this.profile_List = new HashSet<Res_Questionnaire_Index_profile>();
      this.security_List = new HashSet<Res_Questionnaire_Index_security>();
      this.tag_List = new HashSet<Res_Questionnaire_Index_tag>();
      this.Res_Questionnaire_History_List = new HashSet<Res_Questionnaire_History>();
    }
  }
}

