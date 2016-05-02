using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_ExplanationOfBenefit
  {
    public int Res_ExplanationOfBenefitID {get; set;}
    public string FhirId {get; set;}
    public int versionId {get; set;}
    public DateTimeOffset lastUpdated {get; set;}
    public string XmlBlob {get; set;}
    public ICollection<Res_ExplanationOfBenefit_Index_identifier> identifier_List { get; set; }
   
    public Res_ExplanationOfBenefit()
    {
      this.identifier_List = new HashSet<Res_ExplanationOfBenefit_Index_identifier>();
    }
  }
}

