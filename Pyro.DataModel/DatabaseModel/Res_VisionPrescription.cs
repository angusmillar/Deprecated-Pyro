using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_VisionPrescription : ResourceIndexBase
  {
    public int Res_VisionPrescriptionID {get; set;}
    public DateTimeOffset? datewritten_DateTimeOffset {get; set;}
    public string encounter_VersionId {get; set;}
    public string encounter_FhirId {get; set;}
    public string encounter_Type {get; set;}
    public virtual ServiceRootURL_Store encounter_Url { get; set; }
    public int? encounter_ServiceRootURL_StoreID { get; set; }
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual ServiceRootURL_Store patient_Url { get; set; }
    public int? patient_ServiceRootURL_StoreID { get; set; }
    public string prescriber_VersionId {get; set;}
    public string prescriber_FhirId {get; set;}
    public string prescriber_Type {get; set;}
    public virtual ServiceRootURL_Store prescriber_Url { get; set; }
    public int? prescriber_ServiceRootURL_StoreID { get; set; }
    public ICollection<Res_VisionPrescription_History> Res_VisionPrescription_History_List { get; set; }
    public ICollection<Res_VisionPrescription_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_VisionPrescription_Index__profile> _profile_List { get; set; }
    public ICollection<Res_VisionPrescription_Index__security> _security_List { get; set; }
    public ICollection<Res_VisionPrescription_Index__tag> _tag_List { get; set; }
   
    public Res_VisionPrescription()
    {
      this.identifier_List = new HashSet<Res_VisionPrescription_Index_identifier>();
      this._profile_List = new HashSet<Res_VisionPrescription_Index__profile>();
      this._security_List = new HashSet<Res_VisionPrescription_Index__security>();
      this._tag_List = new HashSet<Res_VisionPrescription_Index__tag>();
      this.Res_VisionPrescription_History_List = new HashSet<Res_VisionPrescription_History>();
    }
  }
}

