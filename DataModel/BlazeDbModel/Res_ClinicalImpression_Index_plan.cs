using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace DataModel.BlazeDbModel
{

  public class Res_ClinicalImpression_Index_plan
  {
    public int Id {get; set;}
    public string FhirId {get; set;}     
    public string Type {get; set;}     
    public string Url {get; set;}     
    
    //Keyed
    public virtual Res_ClinicalImpression Res_ClinicalImpression { get; set; }                     
  }
}