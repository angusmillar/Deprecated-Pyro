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
    public string beneficiaryreference_FhirId {get; set;}
    public string beneficiaryreference_Type {get; set;}
    public virtual Blaze_RootUrlStore beneficiaryreference_Url { get; set; }
    public int? beneficiaryreference_Url_Blaze_RootUrlStoreID { get; set; }
    public string dependent_Code {get; set;}
    public string dependent_System {get; set;}
    public string group_Code {get; set;}
    public string group_System {get; set;}
    public string issueridentifier_Code {get; set;}
    public string issueridentifier_System {get; set;}
    public string issuerreference_FhirId {get; set;}
    public string issuerreference_Type {get; set;}
    public virtual Blaze_RootUrlStore issuerreference_Url { get; set; }
    public int? issuerreference_Url_Blaze_RootUrlStoreID { get; set; }
    public string plan_Code {get; set;}
    public string plan_System {get; set;}
    public string planholderidentifier_Code {get; set;}
    public string planholderidentifier_System {get; set;}
    public string planholderreference_FhirId {get; set;}
    public string planholderreference_Type {get; set;}
    public virtual Blaze_RootUrlStore planholderreference_Url { get; set; }
    public int? planholderreference_Url_Blaze_RootUrlStoreID { get; set; }
    public string sequence_Code {get; set;}
    public string sequence_System {get; set;}
    public string subplan_Code {get; set;}
    public string subplan_System {get; set;}
    public string type_Code {get; set;}
    public string type_System {get; set;}
    public ICollection<Res_Coverage_Index_meta_profile> meta_profile_List { get; set; }
    public ICollection<Res_Coverage_Index_meta_security> meta_security_List { get; set; }
    public ICollection<Res_Coverage_Index_meta_tag> meta_tag_List { get; set; }
    public ICollection<Res_Coverage_History> Res_Coverage_History_List { get; set; }
    public ICollection<Res_Coverage_Index_identifier> identifier_List { get; set; }
   
    public Res_Coverage()
    {
      this.identifier_List = new HashSet<Res_Coverage_Index_identifier>();
      this.meta_tag_List = new HashSet<Res_Coverage_Index_meta_tag>();
      this.meta_security_List = new HashSet<Res_Coverage_Index_meta_security>();
      this.meta_profile_List = new HashSet<Res_Coverage_Index_meta_profile>();
      this.Res_Coverage_History_List = new HashSet<Res_Coverage_History>();
    }
  }
}

