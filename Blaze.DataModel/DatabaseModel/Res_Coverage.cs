using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Coverage : ResourceIndexBase
  {
    public int Res_CoverageID {get; set;}
    public string beneficiaryidentifier_Code {get; set;}
    public string beneficiaryidentifier_System {get; set;}
    public string beneficiaryreference_VersionId {get; set;}
    public string beneficiaryreference_FhirId {get; set;}
    public string beneficiaryreference_Type {get; set;}
    public virtual ServiceRootURL_Store beneficiaryreference_Url { get; set; }
    public int? beneficiaryreference_ServiceRootURL_StoreID { get; set; }
    public string dependent_Code {get; set;}
    public string dependent_System {get; set;}
    public string group_Code {get; set;}
    public string group_System {get; set;}
    public string issueridentifier_Code {get; set;}
    public string issueridentifier_System {get; set;}
    public string issuerreference_VersionId {get; set;}
    public string issuerreference_FhirId {get; set;}
    public string issuerreference_Type {get; set;}
    public virtual ServiceRootURL_Store issuerreference_Url { get; set; }
    public int? issuerreference_ServiceRootURL_StoreID { get; set; }
    public string plan_Code {get; set;}
    public string plan_System {get; set;}
    public string planholderidentifier_Code {get; set;}
    public string planholderidentifier_System {get; set;}
    public string planholderreference_VersionId {get; set;}
    public string planholderreference_FhirId {get; set;}
    public string planholderreference_Type {get; set;}
    public virtual ServiceRootURL_Store planholderreference_Url { get; set; }
    public int? planholderreference_ServiceRootURL_StoreID { get; set; }
    public string sequence_Code {get; set;}
    public string sequence_System {get; set;}
    public string subplan_Code {get; set;}
    public string subplan_System {get; set;}
    public string type_Code {get; set;}
    public string type_System {get; set;}
    public ICollection<Res_Coverage_History> Res_Coverage_History_List { get; set; }
    public ICollection<Res_Coverage_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Coverage_Index_profile> profile_List { get; set; }
    public ICollection<Res_Coverage_Index_security> security_List { get; set; }
    public ICollection<Res_Coverage_Index_tag> tag_List { get; set; }
   
    public Res_Coverage()
    {
      this.identifier_List = new HashSet<Res_Coverage_Index_identifier>();
      this.profile_List = new HashSet<Res_Coverage_Index_profile>();
      this.security_List = new HashSet<Res_Coverage_Index_security>();
      this.tag_List = new HashSet<Res_Coverage_Index_tag>();
      this.Res_Coverage_History_List = new HashSet<Res_Coverage_History>();
    }
  }
}

