using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_Specimen : ResourceIndexBase
  {
    public int Res_SpecimenID {get; set;}
    public string accession_Code {get; set;}
    public string accession_System {get; set;}
    public DateTimeOffset? collected_DateTimeOffsetLow {get; set;}
    public DateTimeOffset? collected_DateTimeOffsetHigh {get; set;}
    public string collector_VersionId {get; set;}
    public string collector_FhirId {get; set;}
    public string collector_Type {get; set;}
    public virtual ServiceRootURL_Store collector_Url { get; set; }
    public int? collector_ServiceRootURL_StoreID { get; set; }
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual ServiceRootURL_Store patient_Url { get; set; }
    public int? patient_ServiceRootURL_StoreID { get; set; }
    public string subject_VersionId {get; set;}
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual ServiceRootURL_Store subject_Url { get; set; }
    public int? subject_ServiceRootURL_StoreID { get; set; }
    public ICollection<Res_Specimen_History> Res_Specimen_History_List { get; set; }
    public ICollection<Res_Specimen_Index_bodysite> bodysite_List { get; set; }
    public ICollection<Res_Specimen_Index_container> container_List { get; set; }
    public ICollection<Res_Specimen_Index_container_id> container_id_List { get; set; }
    public ICollection<Res_Specimen_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Specimen_Index_parent> parent_List { get; set; }
    public ICollection<Res_Specimen_Index_type> type_List { get; set; }
    public ICollection<Res_Specimen_Index__profile> _profile_List { get; set; }
    public ICollection<Res_Specimen_Index__security> _security_List { get; set; }
    public ICollection<Res_Specimen_Index__tag> _tag_List { get; set; }
   
    public Res_Specimen()
    {
      this.bodysite_List = new HashSet<Res_Specimen_Index_bodysite>();
      this.container_List = new HashSet<Res_Specimen_Index_container>();
      this.container_id_List = new HashSet<Res_Specimen_Index_container_id>();
      this.identifier_List = new HashSet<Res_Specimen_Index_identifier>();
      this.parent_List = new HashSet<Res_Specimen_Index_parent>();
      this.type_List = new HashSet<Res_Specimen_Index_type>();
      this._profile_List = new HashSet<Res_Specimen_Index__profile>();
      this._security_List = new HashSet<Res_Specimen_Index__security>();
      this._tag_List = new HashSet<Res_Specimen_Index__tag>();
      this.Res_Specimen_History_List = new HashSet<Res_Specimen_History>();
    }
  }
}

