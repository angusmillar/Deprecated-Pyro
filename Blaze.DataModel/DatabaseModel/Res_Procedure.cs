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
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string encounter_FhirId {get; set;}
    public string encounter_Type {get; set;}
    public virtual Blaze_RootUrlStore encounter_Url { get; set; }
    public int? encounter_Url_Blaze_RootUrlStoreID { get; set; }
    public string location_FhirId {get; set;}
    public string location_Type {get; set;}
    public virtual Blaze_RootUrlStore location_Url { get; set; }
    public int? location_Url_Blaze_RootUrlStoreID { get; set; }
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Blaze_RootUrlStore patient_Url { get; set; }
    public int? patient_Url_Blaze_RootUrlStoreID { get; set; }
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual Blaze_RootUrlStore subject_Url { get; set; }
    public int? subject_Url_Blaze_RootUrlStoreID { get; set; }
    public ICollection<Res_Procedure_Index_meta_profile> meta_profile_List { get; set; }
    public ICollection<Res_Procedure_Index_meta_security> meta_security_List { get; set; }
    public ICollection<Res_Procedure_Index_meta_tag> meta_tag_List { get; set; }
    public ICollection<Res_Procedure_History> Res_Procedure_History_List { get; set; }
    public ICollection<Res_Procedure_Index_code> code_List { get; set; }
    public ICollection<Res_Procedure_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Procedure_Index_performer> performer_List { get; set; }
   
    public Res_Procedure()
    {
      this.code_List = new HashSet<Res_Procedure_Index_code>();
      this.identifier_List = new HashSet<Res_Procedure_Index_identifier>();
      this.performer_List = new HashSet<Res_Procedure_Index_performer>();
      this.meta_tag_List = new HashSet<Res_Procedure_Index_meta_tag>();
      this.meta_security_List = new HashSet<Res_Procedure_Index_meta_security>();
      this.meta_profile_List = new HashSet<Res_Procedure_Index_meta_profile>();
      this.Res_Procedure_History_List = new HashSet<Res_Procedure_History>();
    }
  }
}

