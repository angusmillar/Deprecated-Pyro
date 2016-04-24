using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_ConceptMap_Index_sourcecode
  {
    public int Res_ConceptMap_Index_sourcecodeID {get; set;}
    public string Code {get; set;}
    public string System {get; set;}
    public virtual Res_ConceptMap Res_ConceptMap { get; set; }
   
    public Res_ConceptMap_Index_sourcecode()
    {
    }
  }
}

