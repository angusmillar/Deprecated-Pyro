using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_MedicationAdministration : ResourceIndexBase
  {
    public int Res_MedicationAdministrationID {get; set;}
    public string code_Code {get; set;}
    public string code_System {get; set;}
    public DateTimeOffset? effectivetime_DateTimeOffset {get; set;}
    public string encounter_FhirId {get; set;}
    public string encounter_Type {get; set;}
    public virtual Blaze_RootUrlStore encounter_Url { get; set; }
    public int? encounter_Url_Blaze_RootUrlStoreID { get; set; }
    public string medication_FhirId {get; set;}
    public string medication_Type {get; set;}
    public virtual Blaze_RootUrlStore medication_Url { get; set; }
    public int? medication_Url_Blaze_RootUrlStoreID { get; set; }
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Blaze_RootUrlStore patient_Url { get; set; }
    public int? patient_Url_Blaze_RootUrlStoreID { get; set; }
    public string practitioner_FhirId {get; set;}
    public string practitioner_Type {get; set;}
    public virtual Blaze_RootUrlStore practitioner_Url { get; set; }
    public int? practitioner_Url_Blaze_RootUrlStoreID { get; set; }
    public string prescription_FhirId {get; set;}
    public string prescription_Type {get; set;}
    public virtual Blaze_RootUrlStore prescription_Url { get; set; }
    public int? prescription_Url_Blaze_RootUrlStoreID { get; set; }
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string wasnotgiven_Code {get; set;}
    public string wasnotgiven_System {get; set;}
    public ICollection<Res_MedicationAdministration_Index_meta_profile> meta_profile_List { get; set; }
    public ICollection<Res_MedicationAdministration_Index_meta_security> meta_security_List { get; set; }
    public ICollection<Res_MedicationAdministration_Index_meta_tag> meta_tag_List { get; set; }
    public ICollection<Res_MedicationAdministration_History> Res_MedicationAdministration_History_List { get; set; }
    public ICollection<Res_MedicationAdministration_Index_device> device_List { get; set; }
    public ICollection<Res_MedicationAdministration_Index_identifier> identifier_List { get; set; }
   
    public Res_MedicationAdministration()
    {
      this.device_List = new HashSet<Res_MedicationAdministration_Index_device>();
      this.identifier_List = new HashSet<Res_MedicationAdministration_Index_identifier>();
      this.meta_tag_List = new HashSet<Res_MedicationAdministration_Index_meta_tag>();
      this.meta_security_List = new HashSet<Res_MedicationAdministration_Index_meta_security>();
      this.meta_profile_List = new HashSet<Res_MedicationAdministration_Index_meta_profile>();
      this.Res_MedicationAdministration_History_List = new HashSet<Res_MedicationAdministration_History>();
    }
  }
}

