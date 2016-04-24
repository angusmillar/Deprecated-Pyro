using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Coverage
  {
    public int Res_CoverageID {get; set;}
    public string FhirId {get; set;}
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}
    public string dependent_Code {get; set;}
    public string dependent_System {get; set;}
    public string group_Code {get; set;}
    public string group_System {get; set;}
    public string issuer_FhirId {get; set;}
    public string issuer_Type {get; set;}
    public virtual Aux_RootUrlStore issuer_Aux_RootUrlStoreID { get; set; }
    public string plan_Code {get; set;}
    public string plan_System {get; set;}
    public string sequence_Code {get; set;}
    public string sequence_System {get; set;}
    public string subplan_Code {get; set;}
    public string subplan_System {get; set;}
    public string type_Code {get; set;}
    public string type_System {get; set;}
    public ICollection<Res_Coverage_Index_identifier> identifier_List { get; set; }
   
    public Res_Coverage()
    {
      this.identifier_List = new HashSet<Res_Coverage_Index_identifier>();
    }
  }
}

