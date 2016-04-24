using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Procedure
  {
    public int Res_ProcedureID {get; set;}
    public string FhirId {get; set;}
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string encounter_FhirId {get; set;}
    public string encounter_Type {get; set;}
    public virtual Aux_RootUrlStore encounter_Aux_RootUrlStoreID { get; set; }
    public string location_FhirId {get; set;}
    public string location_Type {get; set;}
    public virtual Aux_RootUrlStore location_Aux_RootUrlStoreID { get; set; }
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Aux_RootUrlStore patient_Aux_RootUrlStoreID { get; set; }
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual Aux_RootUrlStore subject_Aux_RootUrlStoreID { get; set; }
    public ICollection<Res_Procedure_Index_code> code_List { get; set; }
    public ICollection<Res_Procedure_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Procedure_Index_performer> performer_List { get; set; }
   
    public Res_Procedure()
    {
      this.code_List = new HashSet<Res_Procedure_Index_code>();
      this.identifier_List = new HashSet<Res_Procedure_Index_identifier>();
      this.performer_List = new HashSet<Res_Procedure_Index_performer>();
    }
  }
}

