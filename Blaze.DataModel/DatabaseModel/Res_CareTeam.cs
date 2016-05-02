using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_CareTeam
  {
    public int Res_CareTeamID {get; set;}
    public string FhirId {get; set;}
    public int versionId {get; set;}
    public DateTimeOffset lastUpdated {get; set;}
    public string XmlBlob {get; set;}
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Blaze_RootUrlStore patient_Url { get; set; }
    public int? patient_Url_Blaze_RootUrlStoreID { get; set; }
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual Blaze_RootUrlStore subject_Url { get; set; }
    public int? subject_Url_Blaze_RootUrlStoreID { get; set; }
    public ICollection<Res_CareTeam_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_CareTeam_Index_participant> participant_List { get; set; }
    public ICollection<Res_CareTeam_Index_status> status_List { get; set; }
    public ICollection<Res_CareTeam_Index_type> type_List { get; set; }
   
    public Res_CareTeam()
    {
      this.identifier_List = new HashSet<Res_CareTeam_Index_identifier>();
      this.participant_List = new HashSet<Res_CareTeam_Index_participant>();
      this.status_List = new HashSet<Res_CareTeam_Index_status>();
      this.type_List = new HashSet<Res_CareTeam_Index_type>();
    }
  }
}

