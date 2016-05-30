using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_AllergyIntolerance : ResourceIndexBase
  {
    public int Res_AllergyIntoleranceID {get; set;}
    public string category_Code {get; set;}
    public string category_System {get; set;}
    public string criticality_Code {get; set;}
    public string criticality_System {get; set;}
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public DateTimeOffset? last_date_DateTimeOffset {get; set;}
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Blaze_RootUrlStore patient_Url { get; set; }
    public int? patient_Url_Blaze_RootUrlStoreID { get; set; }
    public string recorder_VersionId {get; set;}
    public string recorder_FhirId {get; set;}
    public string recorder_Type {get; set;}
    public virtual Blaze_RootUrlStore recorder_Url { get; set; }
    public int? recorder_Url_Blaze_RootUrlStoreID { get; set; }
    public string reporter_VersionId {get; set;}
    public string reporter_FhirId {get; set;}
    public string reporter_Type {get; set;}
    public virtual Blaze_RootUrlStore reporter_Url { get; set; }
    public int? reporter_Url_Blaze_RootUrlStoreID { get; set; }
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string type_Code {get; set;}
    public string type_System {get; set;}
    public ICollection<Res_AllergyIntolerance_History> Res_AllergyIntolerance_History_List { get; set; }
    public ICollection<Res_AllergyIntolerance_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_AllergyIntolerance_Index_manifestation> manifestation_List { get; set; }
    public ICollection<Res_AllergyIntolerance_Index_onset> onset_List { get; set; }
    public ICollection<Res_AllergyIntolerance_Index_route> route_List { get; set; }
    public ICollection<Res_AllergyIntolerance_Index_severity> severity_List { get; set; }
    public ICollection<Res_AllergyIntolerance_Index_substance> substance_List { get; set; }
    public ICollection<Res_AllergyIntolerance_Index_profile> profile_List { get; set; }
    public ICollection<Res_AllergyIntolerance_Index_security> security_List { get; set; }
    public ICollection<Res_AllergyIntolerance_Index_tag> tag_List { get; set; }
   
    public Res_AllergyIntolerance()
    {
      this.identifier_List = new HashSet<Res_AllergyIntolerance_Index_identifier>();
      this.manifestation_List = new HashSet<Res_AllergyIntolerance_Index_manifestation>();
      this.onset_List = new HashSet<Res_AllergyIntolerance_Index_onset>();
      this.route_List = new HashSet<Res_AllergyIntolerance_Index_route>();
      this.severity_List = new HashSet<Res_AllergyIntolerance_Index_severity>();
      this.substance_List = new HashSet<Res_AllergyIntolerance_Index_substance>();
      this.profile_List = new HashSet<Res_AllergyIntolerance_Index_profile>();
      this.security_List = new HashSet<Res_AllergyIntolerance_Index_security>();
      this.tag_List = new HashSet<Res_AllergyIntolerance_Index_tag>();
      this.Res_AllergyIntolerance_History_List = new HashSet<Res_AllergyIntolerance_History>();
    }
  }
}

