using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_MedicationDispense : ResourceIndexBase
  {
    public int Res_MedicationDispenseID {get; set;}
    public string destination_VersionId {get; set;}
    public string destination_FhirId {get; set;}
    public string destination_Type {get; set;}
    public virtual Blaze_RootUrlStore destination_Url { get; set; }
    public int? destination_Url_Blaze_RootUrlStoreID { get; set; }
    public string dispenser_VersionId {get; set;}
    public string dispenser_FhirId {get; set;}
    public string dispenser_Type {get; set;}
    public virtual Blaze_RootUrlStore dispenser_Url { get; set; }
    public int? dispenser_Url_Blaze_RootUrlStoreID { get; set; }
    public string identifier_Code {get; set;}
    public string identifier_System {get; set;}
    public string medication_VersionId {get; set;}
    public string medication_FhirId {get; set;}
    public string medication_Type {get; set;}
    public virtual Blaze_RootUrlStore medication_Url { get; set; }
    public int? medication_Url_Blaze_RootUrlStoreID { get; set; }
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Blaze_RootUrlStore patient_Url { get; set; }
    public int? patient_Url_Blaze_RootUrlStoreID { get; set; }
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public DateTimeOffset? whenhandedover_DateTimeOffset {get; set;}
    public DateTimeOffset? whenprepared_DateTimeOffset {get; set;}
    public ICollection<Res_MedicationDispense_History> Res_MedicationDispense_History_List { get; set; }
    public ICollection<Res_MedicationDispense_Index_code> code_List { get; set; }
    public ICollection<Res_MedicationDispense_Index_prescription> prescription_List { get; set; }
    public ICollection<Res_MedicationDispense_Index_receiver> receiver_List { get; set; }
    public ICollection<Res_MedicationDispense_Index_responsibleparty> responsibleparty_List { get; set; }
    public ICollection<Res_MedicationDispense_Index_type> type_List { get; set; }
    public ICollection<Res_MedicationDispense_Index_profile> profile_List { get; set; }
    public ICollection<Res_MedicationDispense_Index_security> security_List { get; set; }
    public ICollection<Res_MedicationDispense_Index_tag> tag_List { get; set; }
   
    public Res_MedicationDispense()
    {
      this.code_List = new HashSet<Res_MedicationDispense_Index_code>();
      this.prescription_List = new HashSet<Res_MedicationDispense_Index_prescription>();
      this.receiver_List = new HashSet<Res_MedicationDispense_Index_receiver>();
      this.responsibleparty_List = new HashSet<Res_MedicationDispense_Index_responsibleparty>();
      this.type_List = new HashSet<Res_MedicationDispense_Index_type>();
      this.profile_List = new HashSet<Res_MedicationDispense_Index_profile>();
      this.security_List = new HashSet<Res_MedicationDispense_Index_security>();
      this.tag_List = new HashSet<Res_MedicationDispense_Index_tag>();
      this.Res_MedicationDispense_History_List = new HashSet<Res_MedicationDispense_History>();
    }
  }
}

