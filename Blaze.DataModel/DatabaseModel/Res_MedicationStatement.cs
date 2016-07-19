using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_MedicationStatement : ResourceIndexBase
  {
    public int Res_MedicationStatementID {get; set;}
    public DateTimeOffset? effective_DateTimeOffset {get; set;}
    public DateTimeOffset? effective_DateTimeOffsetLow {get; set;}
    public DateTimeOffset? effective_DateTimeOffsetHigh {get; set;}
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
    public string source_VersionId {get; set;}
    public string source_FhirId {get; set;}
    public string source_Type {get; set;}
    public virtual Blaze_RootUrlStore source_Url { get; set; }
    public int? source_Url_Blaze_RootUrlStoreID { get; set; }
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public ICollection<Res_MedicationStatement_History> Res_MedicationStatement_History_List { get; set; }
    public ICollection<Res_MedicationStatement_Index_code> code_List { get; set; }
    public ICollection<Res_MedicationStatement_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_MedicationStatement_Index_profile> profile_List { get; set; }
    public ICollection<Res_MedicationStatement_Index_security> security_List { get; set; }
    public ICollection<Res_MedicationStatement_Index_tag> tag_List { get; set; }
   
    public Res_MedicationStatement()
    {
      this.code_List = new HashSet<Res_MedicationStatement_Index_code>();
      this.identifier_List = new HashSet<Res_MedicationStatement_Index_identifier>();
      this.profile_List = new HashSet<Res_MedicationStatement_Index_profile>();
      this.security_List = new HashSet<Res_MedicationStatement_Index_security>();
      this.tag_List = new HashSet<Res_MedicationStatement_Index_tag>();
      this.Res_MedicationStatement_History_List = new HashSet<Res_MedicationStatement_History>();
    }
  }
}

