using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Questionnaire_History
  {
    public int Res_QuestionnaireID {get; set;}
    public string FhirId {get; set;}
    public int versionId {get; set;}
    public DateTimeOffset lastUpdated {get; set;}
    public string XmlBlob {get; set;}
    public virtual Res_Questionnaire Res_Questionnaire { get; set; }
   
    public Res_Questionnaire_History()
    {
    }
  }
}

