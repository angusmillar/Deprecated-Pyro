using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.BlazeDbModel
{

  public class Res_ExplanationOfBenefit
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    

    public ICollection<Res_ExplanationOfBenefit_Index_identifier> identifier_List { get; set; }   

    public Res_ExplanationOfBenefit()
    {
      this.identifier_List = new HashSet<Res_ExplanationOfBenefit_Index_identifier>();
    }
  }
}