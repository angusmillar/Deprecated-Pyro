using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Procedure : ResourceIndexBase
  {
    public int Res_ProcedureID {get; set;}
    public DateTimeOffset? date_DateTimeOffsetLow {get; set;}
    public DateTimeOffset? date_DateTimeOffsetHigh {get; set;}
    public string encounter_VersionId {get; set;}
    public string encounter_FhirId {get; set;}
    public string encounter_Type {get; set;}
    public virtual ServiceRootURL_Store encounter_Url { get; set; }
    public int? encounter_ServiceRootURL_StoreID { get; set; }
    public string location_VersionId {get; set;}
    public string location_FhirId {get; set;}
    public string location_Type {get; set;}
    public virtual ServiceRootURL_Store location_Url { get; set; }
    public int? location_ServiceRootURL_StoreID { get; set; }
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
    public ICollection<Res_Procedure_History> Res_Procedure_History_List { get; set; }
    public ICollection<Res_Procedure_Index_category> category_List { get; set; }
    public ICollection<Res_Procedure_Index_code> code_List { get; set; }
    public ICollection<Res_Procedure_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Procedure_Index_performer> performer_List { get; set; }
    public ICollection<Res_Procedure_Index__profile> _profile_List { get; set; }
    public ICollection<Res_Procedure_Index__security> _security_List { get; set; }
    public ICollection<Res_Procedure_Index__tag> _tag_List { get; set; }
   
    public Res_Procedure()
    {
      this.category_List = new HashSet<Res_Procedure_Index_category>();
      this.code_List = new HashSet<Res_Procedure_Index_code>();
      this.identifier_List = new HashSet<Res_Procedure_Index_identifier>();
      this.performer_List = new HashSet<Res_Procedure_Index_performer>();
      this._profile_List = new HashSet<Res_Procedure_Index__profile>();
      this._security_List = new HashSet<Res_Procedure_Index__security>();
      this._tag_List = new HashSet<Res_Procedure_Index__tag>();
      this.Res_Procedure_History_List = new HashSet<Res_Procedure_History>();
    }
  }
}

