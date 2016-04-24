using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_MedicationAdministration
  {
    public int Res_MedicationAdministrationID {get; set;}
    public string FhirId {get; set;}
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}
    public string code_Code {get; set;}
    public string code_System {get; set;}
    public DateTimeOffset? effectivetime_DateTimeOffset {get; set;}
    public string encounter_FhirId {get; set;}
    public string encounter_Type {get; set;}
    public virtual Aux_RootUrlStore encounter_Aux_RootUrlStoreID { get; set; }
    public string medication_FhirId {get; set;}
    public string medication_Type {get; set;}
    public virtual Aux_RootUrlStore medication_Aux_RootUrlStoreID { get; set; }
    public string notgiven_Code {get; set;}
    public string notgiven_System {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Aux_RootUrlStore patient_Aux_RootUrlStoreID { get; set; }
    public string practitioner_FhirId {get; set;}
    public string practitioner_Type {get; set;}
    public virtual Aux_RootUrlStore practitioner_Aux_RootUrlStoreID { get; set; }
    public string prescription_FhirId {get; set;}
    public string prescription_Type {get; set;}
    public virtual Aux_RootUrlStore prescription_Aux_RootUrlStoreID { get; set; }
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public ICollection<Res_MedicationAdministration_Index_device> device_List { get; set; }
    public ICollection<Res_MedicationAdministration_Index_identifier> identifier_List { get; set; }
   
    public Res_MedicationAdministration()
    {
      this.device_List = new HashSet<Res_MedicationAdministration_Index_device>();
      this.identifier_List = new HashSet<Res_MedicationAdministration_Index_identifier>();
    }
  }
}

