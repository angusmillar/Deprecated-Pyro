using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Questionnaire
  {
    public int Res_QuestionnaireID {get; set;}
    public string FhirId {get; set;}
    public int versionId {get; set;}
    public DateTimeOffset lastUpdated {get; set;}
    public string XmlBlob {get; set;}
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string publisher_String {get; set;}
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string title_String {get; set;}
    public string version_String {get; set;}
    public ICollection<Res_Questionnaire_Index_code> code_List { get; set; }
    public ICollection<Res_Questionnaire_Index_identifier> identifier_List { get; set; }
   
    public Res_Questionnaire()
    {
      this.code_List = new HashSet<Res_Questionnaire_Index_code>();
      this.identifier_List = new HashSet<Res_Questionnaire_Index_identifier>();
    }
  }
}

