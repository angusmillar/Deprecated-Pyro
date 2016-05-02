using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_EpisodeOfCare
  {
    public int Res_EpisodeOfCareID {get; set;}
    public string FhirId {get; set;}
    public int versionId {get; set;}
    public DateTimeOffset lastUpdated {get; set;}
    public string XmlBlob {get; set;}
    public string care_manager_FhirId {get; set;}
    public string care_manager_Type {get; set;}
    public virtual Blaze_RootUrlStore care_manager_Url { get; set; }
    public int? care_manager_Url_Blaze_RootUrlStoreID { get; set; }
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string organization_FhirId {get; set;}
    public string organization_Type {get; set;}
    public virtual Blaze_RootUrlStore organization_Url { get; set; }
    public int? organization_Url_Blaze_RootUrlStoreID { get; set; }
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Blaze_RootUrlStore patient_Url { get; set; }
    public int? patient_Url_Blaze_RootUrlStoreID { get; set; }
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public ICollection<Res_EpisodeOfCare_Index_condition> condition_List { get; set; }
    public ICollection<Res_EpisodeOfCare_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_EpisodeOfCare_Index_incomingreferral> incomingreferral_List { get; set; }
    public ICollection<Res_EpisodeOfCare_Index_team_member> team_member_List { get; set; }
    public ICollection<Res_EpisodeOfCare_Index_type> type_List { get; set; }
   
    public Res_EpisodeOfCare()
    {
      this.condition_List = new HashSet<Res_EpisodeOfCare_Index_condition>();
      this.identifier_List = new HashSet<Res_EpisodeOfCare_Index_identifier>();
      this.incomingreferral_List = new HashSet<Res_EpisodeOfCare_Index_incomingreferral>();
      this.team_member_List = new HashSet<Res_EpisodeOfCare_Index_team_member>();
      this.type_List = new HashSet<Res_EpisodeOfCare_Index_type>();
    }
  }
}

