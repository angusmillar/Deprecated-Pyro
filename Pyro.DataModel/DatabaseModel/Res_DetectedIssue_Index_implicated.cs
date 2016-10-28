using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_DetectedIssue_Index_implicated : ReferenceIndex
  {
    public int Res_DetectedIssue_Index_implicatedID {get; set;}
    public virtual Res_DetectedIssue Res_DetectedIssue { get; set; }
   
    public Res_DetectedIssue_Index_implicated()
    {
    }
  }
}

