using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_CareTeam : ResourceIndexBase
  {
    public int Res_CareTeamID {get; set;}
    public DateTimeOffset? date_DateTimeOffsetLow {get; set;}
    public DateTimeOffset? date_DateTimeOffsetHigh {get; set;}
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
    public ICollection<Res_CareTeam_History> Res_CareTeam_History_List { get; set; }
    public ICollection<Res_CareTeam_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_CareTeam_Index_participant> participant_List { get; set; }
    public ICollection<Res_CareTeam_Index_status> status_List { get; set; }
    public ICollection<Res_CareTeam_Index_type> type_List { get; set; }
    public ICollection<Res_CareTeam_Index__profile> _profile_List { get; set; }
    public ICollection<Res_CareTeam_Index__security> _security_List { get; set; }
    public ICollection<Res_CareTeam_Index__tag> _tag_List { get; set; }
   
    public Res_CareTeam()
    {
      this.identifier_List = new HashSet<Res_CareTeam_Index_identifier>();
      this.participant_List = new HashSet<Res_CareTeam_Index_participant>();
      this.status_List = new HashSet<Res_CareTeam_Index_status>();
      this.type_List = new HashSet<Res_CareTeam_Index_type>();
      this._profile_List = new HashSet<Res_CareTeam_Index__profile>();
      this._security_List = new HashSet<Res_CareTeam_Index__security>();
      this._tag_List = new HashSet<Res_CareTeam_Index__tag>();
      this.Res_CareTeam_History_List = new HashSet<Res_CareTeam_History>();
    }
  }
}

