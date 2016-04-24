using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_DetectedIssue_Index_category
  {
    public int Res_DetectedIssue_Index_categoryID {get; set;}
    public string Code {get; set;}
    public string System {get; set;}
    public virtual Res_DetectedIssue Res_DetectedIssue { get; set; }
   
    public Res_DetectedIssue_Index_category()
    {
    }
  }
}

