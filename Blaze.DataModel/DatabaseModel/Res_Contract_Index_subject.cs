using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Contract_Index_subject
  {
    public int Res_Contract_Index_subjectID {get; set;}
    public string FhirId {get; set;}
    public string Type {get; set;}
    public virtual Aux_RootUrlStore Aux_RootUrlStoreID { get; set; }
    public virtual Res_Contract Res_Contract { get; set; }
   
    public Res_Contract_Index_subject()
    {
    }
  }
}

