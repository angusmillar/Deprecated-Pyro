using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_Provenance : ResourceIndexBase
  {
    public int Res_ProvenanceID {get; set;}
    public DateTimeOffset? end_DateTimeOffset {get; set;}
    public string location_VersionId {get; set;}
    public string location_FhirId {get; set;}
    public string location_Type {get; set;}
    public virtual ServiceRootURL_Store location_Url { get; set; }
    public int? location_ServiceRootURL_StoreID { get; set; }
    public DateTimeOffset? start_DateTimeOffset {get; set;}
    public ICollection<Res_Provenance_History> Res_Provenance_History_List { get; set; }
    public ICollection<Res_Provenance_Index_agent> agent_List { get; set; }
    public ICollection<Res_Provenance_Index_entity> entity_List { get; set; }
    public ICollection<Res_Provenance_Index_entity_type> entity_type_List { get; set; }
    public ICollection<Res_Provenance_Index_patient> patient_List { get; set; }
    public ICollection<Res_Provenance_Index_sig> sig_List { get; set; }
    public ICollection<Res_Provenance_Index_target> target_List { get; set; }
    public ICollection<Res_Provenance_Index_userid> userid_List { get; set; }
    public ICollection<Res_Provenance_Index__profile> _profile_List { get; set; }
    public ICollection<Res_Provenance_Index__security> _security_List { get; set; }
    public ICollection<Res_Provenance_Index__tag> _tag_List { get; set; }
   
    public Res_Provenance()
    {
      this.agent_List = new HashSet<Res_Provenance_Index_agent>();
      this.entity_List = new HashSet<Res_Provenance_Index_entity>();
      this.entity_type_List = new HashSet<Res_Provenance_Index_entity_type>();
      this.patient_List = new HashSet<Res_Provenance_Index_patient>();
      this.sig_List = new HashSet<Res_Provenance_Index_sig>();
      this.target_List = new HashSet<Res_Provenance_Index_target>();
      this.userid_List = new HashSet<Res_Provenance_Index_userid>();
      this._profile_List = new HashSet<Res_Provenance_Index__profile>();
      this._security_List = new HashSet<Res_Provenance_Index__security>();
      this._tag_List = new HashSet<Res_Provenance_Index__tag>();
      this.Res_Provenance_History_List = new HashSet<Res_Provenance_History>();
    }
  }
}

