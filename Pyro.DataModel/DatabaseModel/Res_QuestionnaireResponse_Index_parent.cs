using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_QuestionnaireResponse_Index_parent : ReferenceIndex
  {
    public int Res_QuestionnaireResponse_Index_parentID {get; set;}
    public virtual Res_QuestionnaireResponse Res_QuestionnaireResponse { get; set; }
   
    public Res_QuestionnaireResponse_Index_parent()
    {
    }
  }
}

